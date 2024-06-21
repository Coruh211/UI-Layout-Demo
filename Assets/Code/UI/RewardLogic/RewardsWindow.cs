using System.Collections.Generic;
using Code.Inventory;
using Code.UI.TooltipLogic;
using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.RewardLogic
{
    public class RewardsWindow : BaseWindow
    {
        public float LongPressTime => longPressTime;
        
        [Header("General")]
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private Button closeButton;
        [Header("Rewards")]
        [SerializeField] private RewardCell rewardCellPrefab;
        [SerializeField] private RectTransform scrollViewContent;
        [SerializeField] private RectTransform scrollContainer;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform freeContainer;
        [Header("ToolTip")]
        [SerializeField] private float longPressTime = 1f;
        
        private TooltipWindow _tooltipWindow;
        private List<InventoryItem> _currentItems = new List<InventoryItem>();
        private readonly List<RewardCell> _activeCells = new List<RewardCell>();

        protected override void Awake()
        {
            base.Awake();
            closeButton.onClick.AddListener(Hide);
        }

        protected override void OnShow(object[] args)
        {
            titleText.text = (string)args[0];
            _currentItems = (List<InventoryItem>)args[1];
            
            SpawnCells();
        }

        private void SpawnCells()
        {
            bool isFitsOnTargetSize = scrollViewContent.rect.width >= _currentItems.Count * GetCellWidth();
            
            for (int i = 0; i < _currentItems.Count; i++)
            {
                var cell = LeanPool.Spawn(rewardCellPrefab, isFitsOnTargetSize ? freeContainer : scrollContainer);
                cell.Initialize(_currentItems[i], this);
                _activeCells.Add(cell);
            }
        }
        
        private float GetCellWidth() => 
            rewardCellPrefab.GetComponent<RectTransform>().rect.width;
        
        private void DesawnCells()
        {
            for (int i = 0; i < _activeCells.Count; i++)
            {
                LeanPool.Despawn(_activeCells[i].gameObject);
            }

            _activeCells.Clear();
        }
        
        public void ShowTooltip(InventoryItem targetItem)
        {
            if (_tooltipWindow == null)
            {
                _tooltipWindow = Get<TooltipWindow>();
            }
            
            scrollRect.enabled = false;
            _tooltipWindow.Show(targetItem);
        }
        
        public void HideTooltip()
        {
            scrollRect.enabled = true;
            _tooltipWindow.Hide();
        }
        
        protected override void OnHide()
        {
            DesawnCells();
        }

        
    }
}