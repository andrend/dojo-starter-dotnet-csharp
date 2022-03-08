using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Quality_Should_Decrease_At_The_End_Of_The_Day()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 9;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void SellIn_Should_Decrease_At_The_End_Of_The_Day()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedSellIn = 9;

            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }

        [Fact]
        public void Quality_Should_Decrease_Twice_As_Fast_When_Sell_By_Date_Is_Today()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 9;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void Quality_Should_Decrease_Twice_As_Fast_When_Sell_By_Date_Was_Yesterday()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 8;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void SellIn_Should_Decrease_Even_When_It_Has_Passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedSellIn = -1;

            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }

        [Fact]
        public void Quality_Should_Decrease_Twice_As_Fast_When_Sell_By_Date_Passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 8;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void Quality_Should_Never_Be_Negative_When_Sellin_Is_Yet_To_Come()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 0;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void Quality_Should_Never_Be_Negative_When_Sellin_Passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 0;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void Aged_Brie_Quality_Should_Increase()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 11;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void Aged_Brie_Quality_Should_Not_Pass_The_Max_Quality()
        {
            var maxQuality = 50;
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = maxQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.Equal(maxQuality, Items[0].Quality);
        }

        [Fact]
        public void Sulfuras_Never_Decreases_In_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 10;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void Sulfuras_Never_Decreases_In_SellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedSellIn = 10;

            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }

        [Theory]
        [MemberData(nameof(TestData.Sulfras_Test_Data), MemberType = typeof(TestData))]
        public void Sulfuras_Never_Decreases_In_Quality_Or_SellIn(List<Item> items, int expectedSellIn, int expectedQuality)
        {
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectedSellIn, items[0].SellIn);
            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Fact]
        public void Backstage_Passes_Quality_Should_Increase_As_SellIn_Is_10_Days_Or_Less()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 12;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }
    }
}
