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
}
