using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewPowerRing", menuName = "Inventory/Items/PowerRing")]
public class PowerRing : ItemSO, IEquipable
{
    [SerializeField] private List<Damage> _damageProperties;
    [SerializeField] private ItemType slot;

    public event UnityAction<ItemSO> Equipped;

    private void Awake()
    {
        ItemName = "Ring";
        ItemType = ItemType.Ring;
    }

    public override void PickUp()
    {
        throw new System.NotImplementedException();
    }

    public void Equip()
    {
        throw new System.NotImplementedException();
    }

}
