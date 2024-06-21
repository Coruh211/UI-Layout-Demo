using System;
using Code.Inventory;
using Code.UI.RewardLogic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.UI.TooltipLogic
{
    public class TooltipWindow : BaseWindow
    {
        [Header("Tooltip Window Settings")]
        [SerializeField] private RectTransform windowRect;
        [SerializeField] private Vector2 minSize;
        [SerializeField] private Vector2 maxSize;
        [Header("Information")]
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Image iconImage;
        
        private InventoryItem _currentItem;
        private InventoryItem _lastItem;
        private RewardsWindow _rewardWindow;

        protected override void OnShow(object[] args)
        {
            _lastItem = _currentItem;
            _currentItem = (InventoryItem)args[0];

            if (_lastItem == _currentItem)
            {
                return;
            }
            
            SetInformation();
            ResizeWindow();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (_rewardWindow == null)
                {
                    _rewardWindow = Get<RewardsWindow>();
                }
                
                _rewardWindow.HideTooltip();
            }
        }

        private void ResizeWindow()
        {
            var size = descriptionText.GetPreferredValues();
            
            var rect = windowRect.rect;
            rect.size = new Vector2(Mathf.Clamp(size.x, minSize.x, maxSize.x), Mathf.Clamp(size.y, minSize.y, maxSize.y));
            windowRect.sizeDelta = rect.size;
        }

        private void SetInformation()
        {
            nameText.text = _currentItem.Title;
            descriptionText.text = _currentItem.Description;
            iconImage.sprite = _currentItem.Icon;
        }
        
        private void SetDefaultValues()
        {
            var rect = windowRect.rect;
            rect.size = new Vector2(minSize.x, minSize.y);
            windowRect.sizeDelta = rect.size;
        }
        
        protected override void OnHide()
        {
            SetDefaultValues();
        }
    }
}