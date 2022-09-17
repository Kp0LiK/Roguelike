using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _damageLayerMask;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _timeBetweenAttack;

    private float _timer;

    private void Update()
    {
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
    

    private  void Attack()
    {
        if (Input.GetKey(KeyCode.J))
        {
            if (_timer <= 0)
            {
                Collider2D[] enemies =
                    Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _damageLayerMask);
                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<DamageableObject>().ApllyDamage(_damage);
                    }
                }

                _timer = _timeBetweenAttack;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }
}