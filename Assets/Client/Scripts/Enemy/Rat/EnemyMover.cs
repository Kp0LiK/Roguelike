using System;
using System.Collections;
using System.Collections.Generic;
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _homePosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRange;
    [SerializeField] private float _minRange;
    
    private Transform _targetPosition;

    private void Awake()
    {
        _targetPosition = FindObjectOfType<TopDownCharacterController>().transform;
    }

    private void Update()
    {
        if (Vector3.Distance(_targetPosition.position, transform.position) <= _maxRange &&
            Vector3.Distance(_targetPosition.position, transform.position) >= _minRange)
        {
            PlayerDetector();
        }
        else
        {
            GoHome();
        }
    }

    private void PlayerDetector()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition.transform.position,
            _speed * Time.deltaTime);
    }

    private void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, _homePosition.transform.position,
            _speed * Time.deltaTime);
    }
}
