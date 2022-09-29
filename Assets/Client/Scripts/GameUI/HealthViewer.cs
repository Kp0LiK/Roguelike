using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private HealthManager _healthManager;

    private void Awake()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    private void OnEnable()
    {
        _healthManager.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _healthManager.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _slider.DOValue(health, 0.5f);
    }
}
