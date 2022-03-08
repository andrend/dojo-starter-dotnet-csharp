using System.Collections.Generic;

namespace GildedRoseKata
{
    public class TestData
    {
        public static IEnumerable<object[]> Sulfras_Test_Data()
        {
            yield return new object[]
            {
                new List<Item>
                {
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 }
                }, 10, 10
            };
        }
    }
}