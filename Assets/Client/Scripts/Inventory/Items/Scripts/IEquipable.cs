using UnityEngine.Events;

public interface IEquipable
{
    public event UnityAction<ItemSO> Equipped;

    public void Equip();
}
