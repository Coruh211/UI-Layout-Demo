using System.Collections.Generic;
using Code.Inventory;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : BaseWindow
{
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;

    [SerializeField, Space] private Sprite[] _icons;


    protected override void Awake()
    {
        base.Awake();
        _button1.onClick.AddListener(Inventory1);
        _button2.onClick.AddListener(Inventory2);
    }

    protected override void OnShow(object[] args)
    {
    }

    protected override void OnHide()
    {
    }

    string MakeTitle(int index)
    {
        return index % 2 == 1 ? $"Title {index}" : $"A Very long long Title {index}";
    }

    string MakeDesc(int index)
    {
        return index % 2 == 0
            ? $@"{index} Указывая тип основной деятельности (аналог ОКВЭД), нужно указывать наиболее широкую область деятельности. 
Выбирая из выпадающего списка тип деятельности нужно пользоваться переводчиком, но я приведу примеры: 
Компьютерное программирование и связанная деятельность, 
Веб-сервисы, 
аудио видео услуги, 
Дизайнерская / проектная деятельность 
и так далее"
            : $"#{index} Short Description";
    }

    private void Inventory1()
    {
        Get<RewardsWindow>().Show("Reward 1", new List<InventoryItem>()
        {
            new(MakeTitle(1), MakeDesc(1), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(2), MakeDesc(2), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(3), MakeDesc(3), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(4), MakeDesc(4), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(5), MakeDesc(5), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(6), MakeDesc(6), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(7), MakeDesc(7), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(8), MakeDesc(8), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(9), MakeDesc(9), _icons[Random.Range(0, _icons.Length)]),
            new(MakeTitle(10), MakeDesc(10), _icons[Random.Range(0, _icons.Length)]),
        });
    }


    private void Inventory2()
    {
        Get<RewardsWindow>().Show("Rewards From Other Place", new List<InventoryItem>()
            {
                new(MakeTitle(1), MakeDesc(1), _icons[Random.Range(0, _icons.Length)]),
                new(MakeTitle(2), MakeDesc(2), _icons[Random.Range(0, _icons.Length)]),
                new(MakeTitle(3), MakeDesc(3), _icons[Random.Range(0, _icons.Length)]),
            });
    }
}