using System.Collections.Generic;
using csharp.Models;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<InventoryItem> _items;

        public GildedRose(IList<InventoryItem> Items)
        {
            this._items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var i in _items)
            {
                i.UpdateQuality();
            }
        }
    }
}