using UnityEngine;

[System.Serializable]
public class Loot
{
    [field: SerializeField] public ItemSO Item { get; protected set; }
    [Space]

    [SerializeField][Range(0f, 100f)] private float _percent;
    [SerializeField][Min(0)] private Vector2Int _quantityRange;

    public float Percent { get => _percent; }
    public Vector2Int QuantityRange { get => _quantityRange; }
}