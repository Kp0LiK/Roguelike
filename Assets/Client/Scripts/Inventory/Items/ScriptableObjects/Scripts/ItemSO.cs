using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Sprite _inventoryIcon;
    [SerializeField] private ItemType _itemType;

    public string ItemName { get => _itemName; protected set => _itemName = value; }
    public GameObject ItemPrefab { get => _itemPrefab; protected set => _itemPrefab = value; }
    public Sprite InventoryIcon { get => _inventoryIcon; protected set => _inventoryIcon = value; }
    public ItemType ItemType { get => _itemType; protected set => _itemType = value; }

    [TextArea(10, 20)]
    public string description;
}