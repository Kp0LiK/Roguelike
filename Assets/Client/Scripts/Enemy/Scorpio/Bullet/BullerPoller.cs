using System;
using UnityEngine;

public class BullerPoller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, _layerMask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<HealthManager>().HurtPlayer(_damage);
            }

            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
}
