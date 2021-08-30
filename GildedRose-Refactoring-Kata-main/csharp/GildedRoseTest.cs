using NUnit.Framework;
using System.Collections.Generic;
using csharp.Models;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<InventoryItem> Items = new List<InventoryItem> { new InventoryItem { InventoryItemCategory = ItemCategory.Common, Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItems();
            Assert.AreEqual("foo", Items[0].Name);
        }
    }
}