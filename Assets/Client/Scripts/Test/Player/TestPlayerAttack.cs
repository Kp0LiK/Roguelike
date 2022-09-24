using System.Collections.Generic;
using UnityEngine;

public class TestPlayerAttack : MonoBehaviour, IAttacking
{
    [SerializeField] private Transform _attackPoint;
    private Vector3 _attackDirection;
    private Vector3 _attackOffset;
    private int _attackStreak;
    private float _cooldownTimer = 0f;
    [SerializeField] private CircleCollider2D attackTrigger2D;
    [SerializeField] private List<Property> _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _attackRange;
    [SerializeField][Range(0, 180)] private float _attackAngle;

    private void Awake()
    {
        if (_damage[0].Type != DamageType.Default)
        {
            _damage.Insert(0, new Property(DamageType.Default));
            Debug.LogWarning(@"Default damage (PlayerAttack.Damage) has been not assigned. 
            Default damage of zero amount was assigned automatically");
        }

        if (attackTrigger2D == null)
        {
            attackTrigger2D = gameObject.AddComponent<CircleCollider2D>();
            attackTrigger2D.radius = _attackRange;
            attackTrigger2D.isTrigger = true;
        }
    }

    private void Update()
    {
        float fireHorizontal = Input.GetAxisRaw("Mouse X");
        float fireVertical = Input.GetAxisRaw("Mouse Y");

        Vector3 mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        _attackDirection = (mousePosition - new Vector3(transform.position.x - _attackOffset.x, transform.position.y - _attackOffset.y, 0));

        attackTrigger2D.radius = _attackRange;

        _cooldownTimer -= Mathf.Clamp(Time.deltaTime, 0, _cooldownTimer);

        Debug.DrawLine(transform.position - _attackOffset, _attackDirection, Color.blue);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other is IDamageable && Input.GetMouseButton(0))
        {
            Attack(other.transform, _damage, _cooldown, _attackAngle);
        }
    }

    public float Attack(Transform enemy, List<Property> damage, float cooldown, float attackAngle)
    {
        if (_cooldownTimer <= 0 && enemy != null &&
            Vector2.Angle(enemy.transform.position - transform.position, _attackDirection) <= attackAngle)
        {
            _cooldownTimer = cooldown;
            enemy.GetComponent<IDamageable>().TakeDamage(damage);
        }
        return 0;
    }
}
