using UnityEngine;

namespace Code.Inventory
{
    public class InventoryItem
    {
        public readonly string Title;
        public readonly string Description;
        public readonly Sprite Icon;

        public InventoryItem(string title, string description, Sprite icon)
        {
            Title = title;
            Description = description;
            Icon = icon;
        }
    }
}