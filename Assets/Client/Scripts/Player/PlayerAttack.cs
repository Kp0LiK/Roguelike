using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _damageLayerMask;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _timeBetweenAttack;
    [Range(0, 180)][SerializeField] private float _attackAngle;
    [SerializeField] private Vector3 _attackOffset;
    [SerializeField] private Vector3 _attackDirection;
    [SerializeField] private Vector3 _enemyDirection;
 
    private float _timer;

    public static Vector3 attackDir;
    public static Vector3 enemyDir;

    private void Update()
    {
        float fireHorizontal = Input.GetAxisRaw("Mouse X");
        float fireVertical = Input.GetAxisRaw("Mouse Y");

        Vector3 mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        _attackDirection = (mousePosition - new Vector3(transform.position.x - _attackOffset.x, transform.position.y - _attackOffset.y, 0));
        attackDir = _attackDirection;

        Debug.DrawLine(transform.position - _attackOffset, _attackDirection, Color.blue);

        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
    

    private void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            if (_timer <= 0)
            {
                Collider2D[] enemies =
                    Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _damageLayerMask);
                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        Vector2 enemyDirection = (enemies[i].transform.position - transform.position);
                        enemyDir = enemyDirection;

                        if (Vector2.Angle(enemyDirection, _attackDirection) <= _attackAngle)
                        {
                            enemies[i].GetComponent<DamageableObject>().ApplyDamage(_damage);
                        }
                    }
                }

                _timer = _timeBetweenAttack;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}