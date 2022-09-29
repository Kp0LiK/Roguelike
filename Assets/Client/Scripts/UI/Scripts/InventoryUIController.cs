using UnityEngine;

namespace InventoryUI
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField] InventoryUI inventoryUI;

        private void Awake()
        {
            inventoryUI.InitializeInventoryUI(10);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (inventoryUI.isActiveAndEnabled)
                {
                    inventoryUI.Hide();
                }
                else
                {
                    inventoryUI.Show();
                }
            }
        }
    }
}