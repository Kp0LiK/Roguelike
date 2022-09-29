using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private float _invincibility;
    [SerializeField] private float _invincibilityTimer;
    [SerializeField] private DamageSensitivities damageSensitivities;

    public event UnityAction Died;

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
        Died?.Invoke();
        Destroy(gameObject);
    }
}
