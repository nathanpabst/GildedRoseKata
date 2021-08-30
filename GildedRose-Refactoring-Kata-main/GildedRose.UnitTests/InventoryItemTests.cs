using System;
using System.Collections;
using System.Collections.Generic;
using csharp.Models;
using csharp;

using NUnit.Framework;

namespace csharp.UnitTests
{
    [TestFixture]
    public class InventoryItemTests
    {
        /// <summary>
        /// Cheese Item unit tests
        /// </summary>
        [Test]
        public void UpdateInventory_CheeseQualityIncreasesByOneIfLessThanFifty_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Cheese,
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 1
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(2));
            Assert.That(i.SellIn, Is.EqualTo(1));
        }

        [Test]
        public void UpdateInventory_CheeseQualityDoesNotExceedFifty_ReturnsTrue()
        {
            //Arrange
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Cheese,
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 50
            };
            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(50));
            Assert.That(i.SellIn, Is.EqualTo(1));
        }

        [Test]
        public void UpdateInventory_SellinDateIsLessThanZeroCheeseQualityIncreasesByTwo_ReturnsTrue()
        {
            //Arrange
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Cheese,
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 3
            };
            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(5));
            Assert.That(i.SellIn, Is.EqualTo(-2));
        }

        /// <summary>
        /// Backstage Pass unit tests
        /// </summary>
        [Test]
        public void UpdateInventory_BackstagePassAQualityScoreOfLessThanFiftyWillIncreasesByOne_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.BackstagePass,
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(21));
            Assert.That(i.SellIn, Is.EqualTo(14));
        }

        [Test]
        public void UpdateInventory_ABackstagePassQualityScoreWillNeverExceedFifty_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.BackstagePass,
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 50
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(50));
            Assert.That(i.SellIn, Is.EqualTo(14));
        }

        [Test]
        public void UpdateInventory_BackstagePassAQualityScoreOfLessThanFiftyWillIncreaseByTwoWithin10DaysOfTheSellinDate_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.BackstagePass,
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 20
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(22));
            Assert.That(i.SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdateInventory_BackstagePassAQualityScoreOfLessThanFiftyWillIncreaseByThreeWithinFiveDaysOfTheSellinDate_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.BackstagePass,
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 20
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(23));
            Assert.That(i.SellIn, Is.EqualTo(4));
        }

        [Test]
        public void UpdateInventory_BackstagePassQualityDropsToZeroWhenTheSellinDateReachesZero_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.BackstagePass,
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 20
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(0));
            Assert.That(i.SellIn, Is.EqualTo(-1));
        }

        /// <summary>
        /// Common Item unit tests
        /// </summary>

        [Test]
        public void UpdateInventory_CommonItemQualityDropsByOneEachDayUntilItReachesZero_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Common,
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(19));
            Assert.That(i.SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdateInventory_AfterTheSellinDatePassesACommonItemsQualityWillDegradeTwiceAsFastUntilItReachesZero_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Common,
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 20
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(18));
            Assert.That(i.SellIn, Is.EqualTo(-1));
        }

        [Test]
        public void UpdateInventory_ACommonItemsQualityWillNeverDropBelowZero_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Common,
                Name = "+5 Dexterity Vest",
                SellIn = 0,
                Quality = 0
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(0));
            Assert.That(i.SellIn, Is.EqualTo(-1));
        }

        /// <summary>
        /// Conjured Item unit tests
        /// </summary>
        [Test]
        public void UpdateInventory_ConjuredItemQualityDegradesTwiceAsFastUntilItReachesZero_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Conjured,
                Name = "Conjured Mana Cake",
                SellIn = 3,
                Quality = 6
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(4));
            Assert.That(i.SellIn, Is.EqualTo(2));
        }

        [Test]
        public void UpdateInventory_AConjuredItemsQualityWillNeverDropBelowZero_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Conjured,
                Name = "Conjured Mana Cake",
                SellIn = -1,
                Quality = 1
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(0));
            Assert.That(i.SellIn, Is.EqualTo(-2));
        }

        /// <summary>
        /// Legendary Item unit tests
        /// </summary>
        [Test]
        public void UpdateInventory_ALegendaryItemNeverDecreasesInQuality_ReturnsTrue()
        {
            //Assert
            var i = new InventoryItem()
            {
                InventoryItemCategory = ItemCategory.Legendary,
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 1,
                Quality = 80
            };

            //Act
            i.UpdateInventory();

            //Assert
            Assert.That(i.Quality, Is.EqualTo(80));
            Assert.That(i.SellIn, Is.EqualTo(1));
        }
    }
}