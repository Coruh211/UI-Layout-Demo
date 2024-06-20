using Code.Inventory;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.UI.RewardLogic
{
    public class RewardCell : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        
        private InventoryItem _currentInventoryItem;
        
        public void Initialize(InventoryItem inventoryItem)
        {
            _currentInventoryItem = inventoryItem;

            SetInfo();
        }

        private void SetInfo()
        {
            iconImage.sprite = _currentInventoryItem.Icon;
        }
    }
}