using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask _damageLayerMask;
    private float _cooldownTimer = 0f;
    [SerializeField] private List<Damage> _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _attackRange;

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

    private float Attack(List<Damage> damage, Transform attackPoint, LayerMask damageLayerMask, float cooldown, float attackRange)
    {
        Collider2D[] enemies =
        Physics2D.OverlapCircleAll(attackPoint.position, _attackRange, _damageLayerMask);
        if (enemies.Length != 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (_cooldownTimer <= 0 && enemies[i] != null)
                {
                    _cooldownTimer = cooldown;
                    enemies[i].GetComponent<IDamageable>().TakeDamage(_damage);
                }
            }
        }
        return 0;
    }
}
