using UnityEngine;

public class LootDrop : MonoBehaviour
{
    private EnemyHealth enemy;

    [SerializeField] private LootTable lootTable;
    [SerializeField] private float itemsDispersion;

    void OnEnable()
    {
        enemy = gameObject.GetComponent<EnemyHealth>();
        enemy.Died += OnEnemyDied;
    }

    void OnDisable()
    {
        enemy.Died -= OnEnemyDied;
    }

    void OnEnemyDied()
    {
        if (lootTable != null)
        {
            foreach (Loot loot in lootTable.Items)
            {
                int quantity = lootTable.PickLoot(loot);

                loot.Item.Drop(loot.Item, transform.position, itemsDispersion, quantity);
            }
        }
    }
}
