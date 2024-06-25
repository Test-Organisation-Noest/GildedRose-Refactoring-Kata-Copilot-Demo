using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePasses(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    // Sulfuras doesn't change in quality
                    break;
                default:
                    UpdateNormalOrConjuredItem(item);
                    break;
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }
    }

    private void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        if (item.SellIn < 0 && item.Quality < 50)
        {
            item.Quality += 1;
        }
    }

    private void UpdateBackstagePasses(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;

            if (item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality += 1;
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality += 1;
            }
        }

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }

    private void UpdateNormalOrConjuredItem(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;

            if (item.Name.StartsWith("Conjured"))
            {
                item.Quality -= 1;
            }
        }

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 1;

            if (item.Name.StartsWith("Conjured"))
            {
                item.Quality -= 1;
            }
        }
    }
}