using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewPowerRing", menuName = "Inventory/Items/PowerRing")]
public class PowerRing : DefaultItem
{
    [SerializeField] private List<Damage> _damageProperties;
    [SerializeField] private ItemType slot;

    // public event UnityAction<ItemSO> Equipped;

    private void Awake()
    {
        ItemName = "Ring";
        ItemType = ItemType.Ring;
    }

    public void Equip()
    {
        throw new System.NotImplementedException();
    }

}
