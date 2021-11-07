using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
  public  class itemsLogic
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string Conjured= "Conjured";

        private const int MAX_QUANTITY = 50;
        private const int BACKSTAGE_PASSES_DECRESE_D2 = 11;
        private const int BACKSTAGE_PASSES_DECRESE_D3 = 6;

        public IList<Item> Items;

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if (IsRegular(item))
                {
                    regularProcces(item);

                }
                else if (IsAgedBrie(item))
                {
                    agedBrieProcces(item);
                }

                else if (IsBackstagePasses(item))
                {
                    backstagePassesProcces(item);
                }

               else  if (IsSulfuras(item))
                {
                    sulfurasProcces(item);
                }
                else if (isConjured(item))
                {
                    ConjuredProcces(item);

                }

            }
        }

        private void ConjuredProcces(Item item)
        {
            item.SellIn--;
            item.Quality -= 2;

            if (item.SellIn <= 0)
            {
                item.Quality -= 2;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

        }

        private void sulfurasProcces(Item item)
        {
            item.SellIn--;
        }

        private void backstagePassesProcces(Item item)
        {
            item.SellIn--;
            item.Quality++;

            if (item.SellIn < BACKSTAGE_PASSES_DECRESE_D2)
            {
                item.Quality++;
            }

            if (item.SellIn < BACKSTAGE_PASSES_DECRESE_D3)
            {
                item.Quality++;
            }

            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            if (item.Quality > MAX_QUANTITY)
            {
                item.Quality = MAX_QUANTITY;
            }
        }

        private void agedBrieProcces(Item item)
        {
            item.SellIn--;
            item.Quality++;

            if (item.SellIn <= 0)
            {
                item.Quality++;
            }

            if (item.Quality > MAX_QUANTITY)
            {
                item.Quality = MAX_QUANTITY;
            }
        }

        private void regularProcces(Item item)
        {
            item.SellIn--;
            item.Quality--;

            if (item.SellIn <= 0)
            {
                item.Quality--;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        private bool IsRegular(Item item)
        {
            return !(IsAgedBrie(item)|| IsBackstagePasses(item) || IsSulfuras(item)||isConjured(item));
        }

        private static bool IsSulfuras(Item item)
        {
            return item.Name == SULFURAS;
        }

        private static bool IsBackstagePasses(Item item)
        {
            return item.Name == BACKSTAGE_PASSES;
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name == AGED_BRIE;
        }
        private bool isConjured(Item item)
        {
            return item.Name == Conjured;
        }
    }

}

