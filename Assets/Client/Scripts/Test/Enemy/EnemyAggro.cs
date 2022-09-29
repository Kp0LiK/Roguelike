using Cainos.PixelArtTopDown_Basic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private Transform _homePosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxAggro;
    [SerializeField] private float _minAggro;
    
    private Transform _target;

    private void Awake()
    {
        _target = FindObjectOfType<TopDownCharacterController>().transform;
    }

    private void Update()
    {
        if (Vector3.Distance(_target.position, transform.position) <= _maxAggro &&
            Vector3.Distance(_target.position, transform.position) >= _minAggro)
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
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position,
            _speed * Time.deltaTime);
    }

    private void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, _homePosition.transform.position,
            _speed * Time.deltaTime);
    }
}
