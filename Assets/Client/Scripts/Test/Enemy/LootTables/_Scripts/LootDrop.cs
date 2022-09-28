using UnityEngine;

public class LootDrop : MonoBehaviour
{
    private EnemyHealth enemy;

    [SerializeField] private LootTable lootTable;
    [SerializeField] private float itemDispersion;

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

                for (int i = quantity - 1; i >= 0 ; i--)
                {
                    Drop(loot);
                }
            }
        }
    }

    void Drop(Loot loot)
    {
        Instantiate(loot.Item.ItemPrefab,
                        new(
                            transform.position.x + Random.Range(-itemDispersion, itemDispersion),
                            transform.position.y + Random.Range(-itemDispersion, itemDispersion),
                            0),
                        Quaternion.identity);

        Debug.Log("Item dropped");
    }
}
