using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth = 10;

    public void HurtPlayer(int damage)
    {
        var player = GetComponent<LevelManager>();
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            player.Die();
            _currentHealth = 10;
        }
    }
}
