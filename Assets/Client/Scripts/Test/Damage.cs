using UnityEngine;

[System.Serializable]
public struct Damage
{
    [SerializeField] private DamageType type;
    [SerializeField] private float amount;

    public DamageType Type { get => type; }
    public float Amount { get => amount; }

    public Damage(DamageType type)
    {
        this.type = type;
        amount = 0f;
    }

    public Damage(DamageType type, float amount)
    {
        this.type = type;
        this.amount = amount;
    }
}