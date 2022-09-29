using UnityEngine;

[CreateAssetMenu(fileName = "NewDefaultItem", menuName = "Inventory/Items/Default")]
public class DefaultItem : ItemSO
{
    private void Awake()
    {
        ItemName = "Default";
        ItemType = ItemType.Default;
    }

    public override void PickUp()
    {
        throw new System.NotImplementedException();
    }

    public override void Drop(ItemSO item, Vector2 position, float itemsDispersion, int iterations)
    {
        if (iterations < 0) return;
        for (int i = iterations; i >= 0; i--)
        {
	        Instantiate(item.ItemPrefab,
	                    new(
	                    position.x + Random.Range(-itemsDispersion, itemsDispersion),
	                    position.y + Random.Range(-itemsDispersion, itemsDispersion),
	                    0),
	                    Quaternion.identity);
            Debug.Log($"Item {item.ItemName} dropped");
        }
    }
}
