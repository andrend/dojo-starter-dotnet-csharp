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
        public void Quality_Should_Decrease_Twice_As_Fast_When_Sell_By_Date_Has_Passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Test item", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            var expectedQuality = 8;

            Assert.Equal(expectedQuality, Items[0].Quality);
        }
    }
}
