using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _protection;
    [SerializeField] private float _shield;
    [Range(0, 180)][SerializeField] private float _shieldAngle; 
    [SerializeField] private float healCount;
    private float _maxHealth = 10;

    private Vector2 _attackDirection;
    private Vector2 _enemyDirection;

    private void Update()
    {
        _attackDirection = PlayerAttack.attackDir;
        _enemyDirection = PlayerAttack.enemyDir;

        if (Input.GetKeyDown("h"))
        {
            HealPlayer(healCount);
        }
    }

    public void HurtPlayer(int damage)
    {
<<<<<<< HEAD:Assets/Client/Scripts/Player/HealthManager.cs
        var player = GetComponent<LevelManager>();
        _currentHealth -= damage;
=======
        if (Input.GetMouseButton(1) || Vector3.Angle(_attackDirection, _enemyDirection) <= _shieldAngle)
        {
            _currentHealth -= Mathf.Clamp((damage - _shield) * (100 / (100 + _protection)), 0, _currentHealth);
        }
        else
        {
            _currentHealth -= Mathf.Clamp(damage * (100 / (100 + _protection)), 0, _currentHealth);
        }

>>>>>>> 7036206 (Attack/Defence system):Assets/Client/Scripts/HealthManager.cs
        if (_currentHealth <= 0)
        {
            player.Die();
            _currentHealth = 10;
        }
    }

    private void HealPlayer(float healCount)
    {
        _currentHealth += Mathf.Clamp(healCount, 0, _maxHealth - _currentHealth);
    }
}
