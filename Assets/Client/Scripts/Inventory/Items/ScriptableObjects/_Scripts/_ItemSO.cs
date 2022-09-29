using UnityEngine;

public abstract class ItemSO : ScriptableObject, IPickUpable
{

    [field: SerializeField] public ItemType ItemType { get; protected set; }
    [field: SerializeField] public string ItemName { get; protected set; }
    [field: SerializeField] public Sprite InventoryIcon { get; protected set; }
    [field: SerializeField] public GameObject ItemPrefab { get; protected set; }
    [field: SerializeField] public bool IsStackable { get; protected set; }
    [field: SerializeField] public int MaxStack { get; protected set; }

    [TextArea(10, 20)]
    public string description;

    public abstract void PickUp();
    public abstract void Drop(ItemSO item, Vector2 position, float itemsDispersion, int iterations);
}