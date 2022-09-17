using System;
using Cainos.PixelArtTopDown_Basic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _startShot;
    [SerializeField] private float _offset;
    [SerializeField, Range(0, 10)] private float _range;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startShotPoint;
    [SerializeField] private CircleCollider2D _circleCollider;

    private float _timeShots;
    private Vector3 _difference;
    private Transform _target;

    private void OnValidate()
    {
        if (_circleCollider != null)
        {
            _circleCollider.radius = _range;
        }
    }

    private void Update()
    {
        if (_target == null)
            return;

        var direction = _target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        if (_timeShots <= 0)
        {
            Shoot();
        }
        else
        {
            _timeShots -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TopDownCharacterController player))
        {
            _target = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out TopDownCharacterController player))
        {
            _target = null;
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _startShotPoint.position, transform.rotation);
        _timeShots = _startShot;
    }
}