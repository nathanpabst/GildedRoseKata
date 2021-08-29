namespace csharp.Models
{
    public class InventoryItem : Item
    {
        public ItemCategory InventoryItemCategory { get; set; }

        public void UpdateQuality()
        {
            switch (this.InventoryItemCategory)
            {
                case ItemCategory.Cheese:
                    if (this.Quality < 50)
                    {
                        this.Quality += 1;
                    }

                    this.SellIn -= 1;

                    if (this.SellIn < 0)
                    {
                        if (this.Quality < 50)
                        {
                            this.Quality += 1;
                        }
                    }

                    break;

                case ItemCategory.BackstagePass:
                    if (this.Quality < 50)
                    {
                        this.Quality += 1;
                    }

                    if (this.SellIn < 11)
                    {
                        if (this.Quality < 50)
                        {
                            this.Quality += 1;
                        }
                    }

                    if (this.SellIn < 6)
                    {
                        if (this.Quality < 50)
                        {
                            this.Quality += 1;
                        }
                    }

                    this.SellIn -= 1;

                    if (this.SellIn < 0)
                    {
                        this.Quality = 0;
                    }

                    if (this.SellIn > 0)
                    {
                        this.Quality -= 1;
                    }
                    break;

                case ItemCategory.Legendary:
                    break;

                case ItemCategory.Conjured:
                    if (this.Quality > 0)
                    {
                        this.Quality -= 1;
                    }

                    this.SellIn -= 1;

                    if (this.SellIn < 0)
                    {
                        if (this.Quality > 0)
                        {
                            this.Quality -= 1;
                        }
                    }
                    break;

                case ItemCategory.Common:
                    if (this.Quality > 0)
                    {
                        this.Quality -= 1;
                    }

                    this.SellIn -= 1;

                    if (this.SellIn < 0)
                    {
                        if (this.Quality > 0)
                        {
                            this.Quality -= 1;
                        }
                    }
                    break;
            }
        }
    }
}