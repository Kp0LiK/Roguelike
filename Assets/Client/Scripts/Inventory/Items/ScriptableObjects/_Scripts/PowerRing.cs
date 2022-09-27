using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerRing", menuName = "Inventory/Items/PowerRing")]
public class PowerRing : ItemSO
{
    [SerializeField] private List<Damage> _damageProperties;

    private void Awake()
    {
        ItemName = "Ring";
        ItemType = ItemType.Ring;
    }
}
