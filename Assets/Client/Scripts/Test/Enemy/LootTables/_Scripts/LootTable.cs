using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/LootTable")]
public class LootTable : ScriptableObject
{
    [field: SerializeField] public List<Loot> Items { get; protected set; }

    private void Awake()
    {
        if (Items.Count <= 0) Items.Add(new());
    }

    public int PickLoot(Loot loot)
    {
        loot = new();

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Percent >= Random.Range(0, 100f))
            {
                loot = Items[i];
                return Random.Range(Items[i].QuantityRange.x, Items[i].QuantityRange.y);
            }
        }
        return 0;
    }
}
