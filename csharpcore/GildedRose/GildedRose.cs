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
            int qualityFactor = 1;
            for (var i = 0; i < Items.Count; i++)
            {
                qualityFactor = Items[i].SellIn <= 0
                    ? qualityFactor * 2
                    : qualityFactor;

                switch (Items[i].Name)
                {
                    case "Backstage passes to a TAFKAL80ETC concert":
                        SolveForBackstage(Items[i]);
                        break;
                    case "Aged Brie":
                        SolveForAgedBrie(Items[i], qualityFactor);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Conjured Mana Cake":
                        SolveForOthers(Items[i], 2 * qualityFactor);
                        break;
                    default:
                        SolveForOthers(Items[i], qualityFactor);
                        break;
                }

                Items[i].SellIn = Items[i].SellIn - 1;
            }
        }

        private void SolveForOthers(Item item, int qualityFactor)
        {
            item.Quality = Math.Max(item.Quality - qualityFactor, 0);            
        }

        private void SolveForAgedBrie(Item item, int qualityFactor)
        {
            item.Quality = Math.Min(item.Quality + qualityFactor, 50);            
        }

        private void SolveForBackstage(Item item)
        {
            item.Quality = Math.Min(item.Quality + 1, 50);

            if (item.SellIn < 11)
            {
                item.Quality = Math.Min(item.Quality + 1, 50);
            }

            if (item.SellIn < 6)
            {
                item.Quality = Math.Min(item.Quality + 1, 50);
            }            

            if (item.SellIn == 0)
            {
                item.Quality = 0;
            }
        }
    }
}
