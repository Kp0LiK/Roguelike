using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private float _invincibility;
    [SerializeField] private float _invincibilityTimer;
    [SerializeField] private DamageSensitivities damageSensitivities;

    // private void Awake()
    // {
    //     if (_protection[0].Type != DamageType.Default)
    //     {
    //         _protection.Insert(0, new Property(DamageType.Default));
    //         Debug.LogWarning(@"Default protection (EnemyHealth._protection) has been not assigned. 
    //         Default protection of zero amount was assigned automatically");
    //     }

    //     if (_weaknesses == null)
    //     {
    //         _weaknesses.Insert(0, new Property(DamageType.None));
    //         Debug.LogWarning(@"EnemyHealth._weakness can not be null. 
    //         Empty EnemyHealth._weakness element was assigned.");
    //     }
    // }

    private void Update()
    {
        _invincibilityTimer -= Time.deltaTime;
        if (_health <= 0) Die();
    }

    public float TakeDamage(List<Damage> damage)
    {
        float actualDamage = 0;

        if (_invincibilityTimer <= 0)
        {
            for (int i = 0; i < damage.Count; i++)
            {
                actualDamage += damageSensitivities.CalculateDamage(damage[i].Type, damage[i].Amount);
            }
            _invincibilityTimer = _invincibility;
            _health -= actualDamage;
        }
        return actualDamage;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
