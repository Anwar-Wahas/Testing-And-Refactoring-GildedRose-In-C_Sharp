

using GildedRose.Console;
using NUnit.Framework;
using System.Collections.Generic;


namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {
        

        private Item CreateAndUpdateItem(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            itemsLogic app = new itemsLogic() { Items = items };
            app.UpdateQuality();
            return items[0];
        }

        [Test]
        public void GildedRose_GivenRegularItem_SellInAndQualityLower()
        {
            Item item = CreateAndUpdateItem("regFood",15,25);

           
           
            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(24, item.Quality);

        }

        
        [Test]
        public void GildedRose_GivenRegularItemPassSelling_QualityDegradesTwiceAsFast()
        {
         
            Item item = CreateAndUpdateItem("regFood", 0,25);
          
            Assert.AreEqual(23, item.Quality);

        }

        [Test]
        public void GildedRose_GivenRegularItem_QualityNeverNigitve()
        {

            Item item = CreateAndUpdateItem("regFood", 15, 0);

            Assert.AreEqual(0, item.Quality);

        }

        [Test]
        public void GildedRose_GivenRegularItemPassSelling_QualityNeverNigitve()
        {

            Item item = CreateAndUpdateItem("regFood", -1, 0);

            Assert.AreEqual(0, item.Quality);

        }


        [Test]
        public void GildedRose_GivenAgedBrie_QualityIncreases()
        {

            Item item = CreateAndUpdateItem("Aged Brie", 15, 25);

            Assert.AreEqual(26, item.Quality);

        }

        [Test]
        public void GildedRose_GivenAgedBriePastSellin_QualityIncressBy2()
        {

            Item item = CreateAndUpdateItem("Aged Brie", 0, 25);

            Assert.AreEqual(27, item.Quality);

        }

        [Test]
        public void GildedRose_GivenAgedBrie_QualityNeverMoreThan50()
        {

            Item item = CreateAndUpdateItem("Aged Brie", 15, 50);

            Assert.AreEqual(50, item.Quality);

        }

        [Test]
        public void GildedRose_GivenAgedBriePastSellin_QualityNeverMoreThan50()
        {

            Item item = CreateAndUpdateItem("Aged Brie", 0, 49);

            Assert.AreEqual(50, item.Quality);

        }

       

        [Test]
        public void GildedRose_GivenSulfuras_QualityNeverDecresses()
        {

            Item item = CreateAndUpdateItem("Sulfuras, Hand of Ragnaros", 15, 80);

            Assert.AreEqual(80, item.Quality);

        }

        [Test]
        public void GildedRose_GivenSulfurasPastSellin_QualityNeverDecresses()
        {

            Item item = CreateAndUpdateItem("Sulfuras, Hand of Ragnaros", -1, 80);

            Assert.AreEqual(80, item.Quality);

        }

        [Test]
        public void GildedRose_GivenBackstage_QualityIncress()
        {

            Item item = CreateAndUpdateItem("Backstage passes to a TAFKAL80ETC concert", 15, 25);

            Assert.AreEqual(26, item.Quality);

        }

        [Test]
        public void GildedRose_GivenBackstageDaysOut_QualityIncressBy2()
        {

            Item item = CreateAndUpdateItem("Backstage passes to a TAFKAL80ETC concert", 10, 25);

            Assert.AreEqual(27, item.Quality);

        }

        [Test]
        public void GildedRose_GivenBackstageDaysOut_QualityNeverMoreThan50()
        {

            Item item = CreateAndUpdateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49);

            Assert.AreEqual(50, item.Quality);

        }

        [Test]
        public void GildedRose_GivenBackstageDaysOut_QualityIncressBy3()
        {

            Item item = CreateAndUpdateItem("Backstage passes to a TAFKAL80ETC concert", 5, 25);

            Assert.AreEqual(28, item.Quality);

        }

        [Test]
        public void GildedRose_GivenBackstageDaysOut_QualityMoreThan50()
        {

            Item item = CreateAndUpdateItem("Backstage passes to a TAFKAL80ETC concert", 5, 48);

            Assert.AreEqual(50, item.Quality);

        }

        [Test]
        public void GildedRose_GivenBackstagePastSellin_QualityDropsTo0()
        {

            Item item = CreateAndUpdateItem("Backstage passes to a TAFKAL80ETC concert", 0, 25);

            Assert.AreEqual(0, item.Quality);

        }

        [Test]
        public void GildedRose_GivenConjuredItem_QualityDegradesTwiceAsFast()
        {
            Item item = CreateAndUpdateItem("Conjured", 15, 25);

            Assert.AreEqual(23, item.Quality);

        }

        [Test]
        public void GildedRose_GivenConjuredItemPastSellin_QualityDegradesTwiceAsFast()
        {
            Item item = CreateAndUpdateItem("Conjured", 0, 25);

            Assert.AreEqual(21, item.Quality);

        }

        [Test]
        public void GildedRose_GivenConjuredItem_QualityNeverNagitivet()
        {
            Item item = CreateAndUpdateItem("Conjured", 15, 0);

            Assert.AreEqual(0, item.Quality);

        }

        [Test]
        public void GildedRose_GivenConjuredItemPastSellin_QualityNeverNagitivet()
        {
          
            Item item = CreateAndUpdateItem("Conjured", 0, 0);

            Assert.AreEqual(0, item.Quality);
        


        }
       
    }
}