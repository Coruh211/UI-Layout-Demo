using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Code.Inventory;
using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.UI.RewardLogic
{
    public class RewardsWindow : BaseWindow
    {
        [Header("General")]
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private Button closeButton;
        [Header("Rewards")]
        [SerializeField] private RewardCell rewardCellPrefab;
        [SerializeField] private RectTransform scrollViewContent;
        [SerializeField] private RectTransform scrollContainer;
        [SerializeField] private RectTransform freeContainer;
        
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
            
            ActivateCells();
        }

        private void ActivateCells()
        {
            bool isFitsOnTargetSize = scrollViewContent.rect.width >= _currentItems.Count * GetCellWidth();
            
            for (int i = 0; i < _currentItems.Count; i++)
            {
                var cell = LeanPool.Spawn(rewardCellPrefab, isFitsOnTargetSize ? freeContainer : scrollContainer);
                cell.Initialize(_currentItems[i]);
                _activeCells.Add(cell);
            }
        }

        private float GetCellWidth()
        {
            return rewardCellPrefab.GetComponent<RectTransform>().rect.width;
        }
        
        protected override void OnHide()
        {
            for (int i = 0; i < _activeCells.Count; i++)
            {
                LeanPool.Despawn(_activeCells[i].gameObject);
            }
            _activeCells.Clear();
        }
    }
}