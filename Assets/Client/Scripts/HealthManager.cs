using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth = 10;

    public void HurtPlayer(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
