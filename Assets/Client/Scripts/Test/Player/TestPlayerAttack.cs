using System.Collections.Generic;
using UnityEngine;

public class TestPlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _damageLayerMask;
    private Vector3 _attackDirection;
    private Vector3 _attackOffset;
    private int _attackStreak;
    [SerializeField] private List<Damage> _damage;
    [SerializeField] private float _damageInflicted = 0f;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _cooldownTimer = 0f;
    [SerializeField] private float _attackRange;
    [SerializeField][Range(0, 180)] private float _attackAngle;
    [SerializeField] private float angle;

    private void Awake()
    {
        if (_damage[0].Type != DamageType.Default)
        {
            _damage.Insert(0, new Damage(DamageType.Default));
            Debug.LogWarning(@"Default damage (PlayerAttack.Damage) has been not assigned. 
            Default damage of zero amount was assigned automatically");
        }
    }

    private void Update()
    {
        float fireHorizontal = Input.GetAxisRaw("Mouse X");
        float fireVertical = Input.GetAxisRaw("Mouse Y");

        Vector3 mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        _attackDirection = (mousePosition - new Vector3(transform.position.x - _attackOffset.x, transform.position.y - _attackOffset.y, 0));

        _cooldownTimer -= Mathf.Clamp(Time.deltaTime, 0, _cooldownTimer);

        if (Input.GetMouseButton(0))
        {
	        _damageInflicted = Attack(_damage, _attackPoint, _damageLayerMask, _cooldown, _attackRange);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        Debug.DrawLine(transform.position - _attackOffset, _attackDirection, Color.blue);
    }

    private float Attack(List<Damage> damage, Transform attackPoint, LayerMask damageLayerMask, float cooldown, float attackRange)
    {
        Collider2D[] enemies =
        Physics2D.OverlapCircleAll(attackPoint.position, attackRange, damageLayerMask);
        if (enemies.Length != 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                angle = Vector2.Angle(enemies[i].transform.position - attackPoint.position, _attackDirection);
                if (_cooldownTimer <= 0 && angle <= _attackAngle)
                {
                    _cooldownTimer = cooldown;
                    return enemies[i].GetComponent<IDamageable>().TakeDamage(_damage);
                }
            }
            return 0;
        }
        return -1;
    }
}
