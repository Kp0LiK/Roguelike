using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask _damageLayerMask;
    private float _cooldownTimer = 0f;
    [SerializeField] private Transform _target;
    private EnemyAggro aggro;
    [SerializeField] private List<Property> _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _attackRange;

    private void OnEnable()
    {
        aggro = GetComponent<EnemyAggro>();
        aggro.PlayerDetected += OnPlayerDetected;
    }

    private void Awake()
    {
        // if (_damage[0].Type != DamageType.Default)
        // {
        //     _damage.Insert(0, new Property(DamageType.Default));
        //     Debug.LogWarning(@"Default damage (EnemyAttack.Damage) has been not assigned. 
        //     Default damage of zero amount was assigned automatically");
        // }
    }

    private void Update()
    {
        _cooldownTimer -= Mathf.Clamp(Time.deltaTime, 0, _cooldownTimer);
        Attack(_damage, transform, _damageLayerMask, _cooldown, _attackRange);
    }

    public float Attack(List<Property> damage, Transform attackPoint, LayerMask damageLayerMask, float cooldown, float attackRange)
    {
        Collider2D[] enemies =
        Physics2D.OverlapCircleAll(attackPoint.position, _attackRange, _damageLayerMask);
        if (enemies.Length != 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (_cooldownTimer <= 0 && enemies[i] != null 
                    && enemies[i].TryGetComponent<IDamageable>(out IDamageable enemy))
                {
                    _cooldownTimer = cooldown;
                    enemy.TakeDamage(_damage);
                }
            }
        }
        return 0;
    }

    private void OnDisable()
    {
        aggro.PlayerDetected -= OnPlayerDetected;
    }

    public void OnPlayerDetected(Transform target)
    {
        _target = target;
    }
}
