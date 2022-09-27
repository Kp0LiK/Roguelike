using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Sprite _inventoryIcon;
    [SerializeField] private GameObject _itemPrefab;

    public ItemType ItemType { get => _itemType; protected set => _itemType = value; }
    public string ItemName { get => _itemName; protected set => _itemName = value; }
    public Sprite InventoryIcon { get => _inventoryIcon; set => _inventoryIcon = value; }
    public GameObject ItemPrefab { get => _itemPrefab; protected set => _itemPrefab = value; }

    [TextArea(10, 20)]
    public string description;
}