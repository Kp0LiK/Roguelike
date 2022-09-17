using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] private GameObject _barrier;
    [SerializeField] private float _health;

    public float Health => _health;

    public void ApllyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        _barrier.SetActive(false);
    }
}