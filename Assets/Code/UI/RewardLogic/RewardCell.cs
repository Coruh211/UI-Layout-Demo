using Code.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.UI.RewardLogic
{
    public class RewardCell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image iconImage;
        
        private InventoryItem _currentInventoryItem;
        private RewardsWindow _rewardsWindow;

        private bool _isLongPress = false;
        private float _longPressTime = 1f;

        public void Initialize(InventoryItem inventoryItem, RewardsWindow rewardsWindow)
        {
            _currentInventoryItem = inventoryItem;
            _rewardsWindow = rewardsWindow;
            _longPressTime = rewardsWindow.LongPressTime;
            SetInfo();
        }

        private void SetInfo()
        {
            iconImage.sprite = _currentInventoryItem.Icon;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isLongPress = false;
            
            Invoke(nameof(ShowTooltip), _longPressTime);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            CancelInvoke(nameof(ShowTooltip));
        }

        private void ShowTooltip()
        {
            _isLongPress = true;
            _rewardsWindow.ShowTooltip(_currentInventoryItem);
        }
    }
}