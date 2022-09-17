using System;
using System.Collections;
using System.Collections.Generic;
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    private HealthManager _healthManager;
    private float _waitToAttack;
    private bool _isAttack;

    private void Awake()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    private void Update()
    {
        if (_isAttack)
        {
            _waitToAttack -= Time.deltaTime;
            if (_waitToAttack <= 0)
            {
                _healthManager.HurtPlayer(_damage);
                _waitToAttack = 1f;
            }
        }
    }
    

    private void OnCollisionStay2D(Collision2D other)
    {
        _isAttack = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isAttack = false;
    }
}
