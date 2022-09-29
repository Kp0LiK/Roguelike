using System;
using UnityEngine;

public class HealthReciever : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out HealthManager player)) return;
        if (Math.Abs(player.Health - 10) < 0.01f)
        {
            return;
        }
            
        player.HealthAdd(_health);
        Destroy(gameObject);
    }
}
