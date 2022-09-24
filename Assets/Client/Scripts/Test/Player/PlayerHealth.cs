using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private float _invincibility;
    [SerializeField] private float _invincibilityTimer;
    [SerializeField] private List<Property> _weaknesses;
    [SerializeField] private List<Property> _protection;
    [SerializeField] float foundMatches;

    private void Awake()
    {
        if (_protection[0].Type != DamageType.Default)
        {
            _protection.Insert(0, new Property(DamageType.Default));
            Debug.LogWarning(@"Default protection (PlayerHealth.Protection) has been not assigned. 
            Default protection of zero amount was assigned automatically");
        }
        
        if (_weaknesses == null)
        {
            _weaknesses.Insert(0, new Property(DamageType.None));
            Debug.LogWarning(@"PlayerHealth._weakness can not be null. 
            Empty PlayerHealth._weakness element was assigned.");
        }
    }

    private void Update()
    {
        _invincibilityTimer -= Time.deltaTime;
    }

    public float TakeDamage(List<Property> damage)
    {
        float actualDamage = 0;
        foundMatches = 0;

        for (int i = 0; i < damage.Count; i++)
        {
            if (_invincibilityTimer <= 0)
            {
                for (int j = 0; j < _weaknesses.Count; j++)
                for (int k = 0; k < _protection.Count; k++)
                {
                    if (damage[i].Type == _weaknesses[j].Type)
                    {
                        actualDamage += Mathf.Clamp(damage[i].Amount * (100 / (100 - _weaknesses[j].Amount)), 0, _health);
                        foundMatches++;
                        _invincibilityTimer = _invincibility;
                    }
                    if (damage[i].Type == _protection[k].Type)
                    {
                        actualDamage += Mathf.Clamp(damage[i].Amount * (100 / (100 + _protection[k].Amount)), 0, _health);
                        foundMatches++;
                        _invincibilityTimer = _invincibility;
                    }
                }
                if (foundMatches > 0)
                {
                    _health -= actualDamage / foundMatches;
                    return actualDamage / foundMatches;
                }
                actualDamage = Mathf.Clamp(damage[i].Amount * (100 / (100 + _protection[0].Amount)), 0, _health);
                _invincibilityTimer = _invincibility;
                _health -= actualDamage;
                return actualDamage;
            }
        }
        return actualDamage;
    }

    private void Die()
    {
        if (_health <= 0) gameObject.SetActive(false);
    }
}
