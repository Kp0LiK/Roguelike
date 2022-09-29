using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth = 10;
    public int Health => _currentHealth;
    public event UnityAction<int> HealthChanged;

    public void HurtPlayer(int damage)
    {
        var player = GetComponent<LevelManager>();
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _currentHealth = _maxHealth;
        }
        UpdateHealth();
    }
    
    public void UpdateHealth() => HealthChanged?.Invoke(_currentHealth);
    
    public void HealthAdd(int health)
    {
        if (_currentHealth < 10)
        {
            _currentHealth += health;
        }
        
        UpdateHealth();
    }
}
