using System.Collections.Generic;
using csharp.Models;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<InventoryItem> _items;

        public GildedRose(IList<InventoryItem> items)
        {
            this._items = items;
        }

        public void UpdateItems()
        {
            foreach (var i in _items)
            {
                i.UpdateInventory();
            }
        }
    }
}