using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    [SerializeField] private List<InventoryItem> _inventory;

    [field: SerializeField][field: Min(0)] public int Size { get; protected set; }
    [field: SerializeField] public Transform InventoryCarrier { get; protected set; }

    [SerializeField] private int _itemsDispersion;

    public void Initialize()
    {
        _inventory = new List<InventoryItem>(new InventoryItem[Size]);
    }

    private bool IsInventoryFull()
        => _inventory.Where( item => !item.IsNotEmpty).Any();
    
    public bool AddItem(ItemSO item, int quantity)
    {
        if (quantity < 0) return false;

        if (item.IsStackable)
        {
            return AddStackableItem(item, quantity);
        }
        item.Drop(item, InventoryCarrier.position,
                _itemsDispersion, quantity - 1);
        return AddNonStackableItem(item);
    }

    private bool AddStackableItem(ItemSO item, int quantity)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (!_inventory[i].IsNotEmpty)
            {
                _inventory[i].Item.Drop(item, InventoryCarrier.position, 1,
                    _inventory[i].Quantity + quantity - _inventory[i].Item.MaxStack);
                
                _inventory[i] = new(item, _inventory[i].Item.MaxStack);
                return true;
            }
            if (_inventory[i].Item == item)
            {
                _inventory[i].Item.Drop(item, InventoryCarrier.position, 1,
                    _inventory[i].Quantity + quantity - _inventory[i].Item.MaxStack);

                _inventory[i].ChangeQuantity(
                    Mathf.Clamp(
                        _inventory[i].Quantity + quantity, 0, _inventory[i].Item.MaxStack
                    ));
                return true;
            }
        }
        return false;
    }

    public bool AddNonStackableItem(ItemSO item)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (!_inventory[i].IsNotEmpty)
            {
                _inventory[i] = new(item, 1);
                return true;
            }
            if (_inventory[i].Item == item)
            {
                _inventory[i] = new(item, 1);
            }
        }
        return false;
    }

    public bool RemoveItem(ItemSO item, int quantity)
    {
        for (int i = _inventory.Count - 1; i >= 0; i--)
        {
            if (_inventory[i].Item == item && _inventory[i].IsNotEmpty)
            {
                if (_inventory[i].Quantity >= quantity)
                {
                    _inventory[i].ChangeQuantity(
                        Mathf.Clamp(
                            _inventory[i].Quantity + quantity, 0, _inventory[i].Item.MaxStack
                        ));
                    return true;
                }
                _inventory[i] = new();
                return true;
            }
        }
        return false;
    }

    public Dictionary<int, InventoryItem> GetCurrentState()
    {
        Dictionary<int, InventoryItem> result =
            new Dictionary<int, InventoryItem>();

        for (int i = 0; i < _inventory.Count; i++)
        {
            if (!_inventory[i].IsNotEmpty)
                continue;
            result[i] = _inventory[i];
        }
        return result;
    }
}
