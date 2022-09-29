using System.Collections.Generic;
using UnityEngine;

namespace InventoryUI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private UIInventorySlot _slotPrefab;
        [SerializeField] private RectTransform _contentPanel;

        List<UIInventorySlot> uiInventory;

        public void InitializeInventoryUI(int inventorySize)
        {
            uiInventory = new List<UIInventorySlot>(inventorySize);
            uiInventory.ForEach( item =>
            {
                UIInventorySlot uiSlot =
                    Instantiate(_slotPrefab, Vector3.zero, Quaternion.identity);
                uiSlot.transform.SetParent(_contentPanel);
                uiInventory.Add(uiSlot);
            });
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}