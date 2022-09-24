using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAttack : MonoBehaviour, IAttacking
{
    [SerializeField] private CircleCollider2D attackTrigger2D;
    private float _cooldownTimer = 0f;
    [SerializeField] private Transform _target;
    private EnemyAggro aggro;
    [SerializeField] private List<Property> _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _attackRange;
    [SerializeField][Range(0, 180)] private float _attackAngle;

    private void OnEnable()
    {
        aggro = GetComponent<EnemyAggro>();
        aggro.PlayerDetected += OnPlayerDetected;
    }

    private void Awake()
    {
        if (_damage[0].Type != DamageType.Default)
        {
            _damage.Insert(0, new Property(DamageType.Default));
            Debug.LogWarning(@"Default damage (EnemyAttack.Damage) has been not assigned. 
            Default damage of zero amount was assigned automatically");
        }

        if (attackTrigger2D == null)
        {
            attackTrigger2D = gameObject.AddComponent<CircleCollider2D>();
            attackTrigger2D.radius = _attackRange;
            attackTrigger2D.isTrigger = true;
        }
    }

    private void Update()
    {
        _cooldownTimer -= Mathf.Clamp(Time.deltaTime, 0, _cooldownTimer);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other is IDamageable && Input.GetMouseButton(0)
            && other.transform == _target)
        {
            Attack(other.transform, _damage, _cooldown, _attackAngle);
        }
    }

    public float Attack(Transform enemy, List<Property> damage, float cooldown, float attackAngle)
    {
        if (_cooldownTimer <= 0 && enemy != null)
        {
            _cooldownTimer = cooldown;
            return enemy.GetComponent<IDamageable>().TakeDamage(damage);
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
