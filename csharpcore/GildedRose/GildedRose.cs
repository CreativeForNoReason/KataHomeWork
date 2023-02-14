using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Backstage passes to a TAFKAL80ETC concert":
                        SolveForBackstage(Items[i]);
                        break;
                    case "Aged Brie":
                        SolveForAgedBrie(Items[i]);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Conjured Mana Cake":
                        SolveForConjured(Items[i]);
                        break;
                    default:
                        SolveForOthers(Items[i]);
                        break;
                }

                Items[i].SellIn = Items[i].SellIn - 1;
            }
        }

        private void SolveForConjured(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
            }

            if (item.SellIn <= 0)
            {
                item.Quality = Math.Max(item.Quality - 2, 0);
            }
        }

        private void SolveForOthers(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            if (item.SellIn <= 0)
            {
                item.Quality = Math.Max(item.Quality - 1, 0);
            }
        }

        private void SolveForAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn <= 0)
            {
                item.Quality = Math.Min(item.Quality + 1, 50);
            }
        }

        private void SolveForBackstage(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11)
                {
                    item.Quality = Math.Min(item.Quality + 1, 50);
                }

                if (item.SellIn < 6)
                {
                    item.Quality = Math.Min(item.Quality + 1, 50);
                }
            }

            if (item.SellIn == 0)
            {
                item.Quality = 0;
            }
        }
    }
}
