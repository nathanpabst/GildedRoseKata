using System;
using System.Collections.Generic;
using csharp.Models;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Gilded Rose Inventory Tracker");

            IList<InventoryItem> inventoryItems = new List<InventoryItem>{
                new InventoryItem {InventoryItemCategory = ItemCategory.Common, Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new InventoryItem {InventoryItemCategory = ItemCategory.Cheese, Name = "Aged Brie", SellIn = 2, Quality = 0},
                new InventoryItem {InventoryItemCategory = ItemCategory.Common, Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new InventoryItem {InventoryItemCategory = ItemCategory.Legendary, Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new InventoryItem {InventoryItemCategory = ItemCategory.Legendary, Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new InventoryItem
                {
                    InventoryItemCategory = ItemCategory.BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new InventoryItem
                {
                    InventoryItemCategory = ItemCategory.BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new InventoryItem
                {
                    InventoryItemCategory = ItemCategory.BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new InventoryItem
                {
                    InventoryItemCategory = ItemCategory.Conjured,
                    Name = "Conjured Mana Cake",
                    SellIn = 3,
                    Quality = 6
                }
            };

            var app = new GildedRose(inventoryItems);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var j in inventoryItems)
                {
                    System.Console.WriteLine(j);
                }
                Console.WriteLine("");
                app.UpdateItems();
            }

            Console.WriteLine("Press the Enter key to exit");
            Console.ReadLine();
        }
    }
}