using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewRingOfResistance", menuName = "Inventory/Items/RingOfResistance")]
public class RingOfResistance : DefaultItem
{
    [SerializeField] private List<Damage> _resistanceProperties;

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
