using UnityEngine;

[System.Serializable]
public struct Property
{
    [SerializeField] private DamageType type;
    [SerializeField] private float amount;

    public DamageType Type { get => type; }
    public float Amount { get => amount; }

    public Property(DamageType type)
    {
        this.type = type;
        amount = 0f;
    }

    public Property(DamageType type, int amount)
    {
        this.type = type;
        this.amount = amount;
    }


}