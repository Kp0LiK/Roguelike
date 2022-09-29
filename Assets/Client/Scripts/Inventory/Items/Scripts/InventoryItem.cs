using UnityEngine;

[System.Serializable]
public struct InventoryItem
{
    [SerializeField] private ItemSO item;
    [SerializeField][Min(0)] private int quantity;
    private bool isNotEmpty;

    public ItemSO Item => item;
    public int Quantity => quantity;
    public bool IsNotEmpty => isNotEmpty;

    public InventoryItem(ItemSO item)
    {
        this.item = item;
        quantity = 0;
        isNotEmpty = true;
    }

    public InventoryItem(ItemSO item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
        isNotEmpty = true;
    }

    public InventoryItem ChangeQuantity(int newQuantity)
    {
        if (newQuantity <= item.MaxStack - Quantity)
            return new InventoryItem(
                this.item = this.Item,
                this.quantity = newQuantity
            );
        throw new System.ArgumentOutOfRangeException(@"
        The new value must not be greater than ItemSO.MaxStack
        and less than 0");
    }
}
