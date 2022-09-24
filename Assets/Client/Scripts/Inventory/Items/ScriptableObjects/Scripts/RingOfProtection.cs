using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRingOfProtection", menuName = "Inventory/Items/RingOfProtection")]
public class RingOfProtection : ItemSO
{
    [SerializeField] private List<Property> _properties;

    private void Awake()
    {
        ItemName = "Ring";
        ItemType = ItemType.Ring;
    }
}
