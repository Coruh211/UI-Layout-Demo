using System.Collections.Generic;
using Code.Inventory;
using Code.UI.RewardLogic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.UI
{
    public class MainWindow : BaseWindow
    {
        [SerializeField] private Button rewards1Button;
        [SerializeField] private Button rewards2Button;

        [SerializeField, Space] private Sprite[] rewardIcons;


        protected override void Awake()
        {
            base.Awake();
            rewards1Button.onClick.AddListener(Inventory1);
            rewards2Button.onClick.AddListener(Inventory2);
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
                new(MakeTitle(1), MakeDesc(1), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(2), MakeDesc(2), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(3), MakeDesc(3), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(4), MakeDesc(4), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(5), MakeDesc(5), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(6), MakeDesc(6), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(7), MakeDesc(7), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(8), MakeDesc(8), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(9), MakeDesc(9), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(10), MakeDesc(10), rewardIcons[Random.Range(0, rewardIcons.Length)]),
            });
        }


        private void Inventory2()
        {
            Get<RewardsWindow>().Show("Rewards From Other Place", new List<InventoryItem>()
            {
                new(MakeTitle(1), MakeDesc(1), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(2), MakeDesc(2), rewardIcons[Random.Range(0, rewardIcons.Length)]),
                new(MakeTitle(3), MakeDesc(3), rewardIcons[Random.Range(0, rewardIcons.Length)]),
            });
        }
    }
}