using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRingOfResistance", menuName = "Inventory/Items/RingOfResistance")]
public class RingOfResistance : ItemSO
{
    [SerializeField] private List<Damage> _resistanceProperties;

    private void Awake()
    {
        ItemName = "Ring";
        ItemType = ItemType.Ring;
    }
}
