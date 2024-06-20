using System.Collections.Generic;
using System.Linq;
using Code.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardsWindow : BaseWindow
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _rewardsText;
    
    protected override void Awake()
    {
        base.Awake();
        _closeButton.onClick.AddListener(Hide);
    }

    protected override void OnShow(object[] args)
    {
        _titleText.text = (string)args[0];

        var items = (List<InventoryItem>)args[1];

        _rewardsText.text = string.Join("\n", items.Select(x => $"{x.Title}"));
    }

    protected override void OnHide()
    {
    }
    

}