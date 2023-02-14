using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 50,
                    Quality = 50
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void SellinQualityMinus1()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 50,
                    Quality = 50
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(49, Items[0].SellIn);
            Assert.Equal(49, Items[0].Quality);
        }

        [Fact]
        public void SellinGoesNegativeMinus1()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = 50
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void QualityMinus2()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = 2
                },
                new Item
                {
                    Name = "foo",
                    SellIn = -1,
                    Quality = 2
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(0, Items[1].Quality);
        }

        [Fact]
        public void QualityNeverNegative()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = 0
                },
                new Item
                {
                    Name = "foo",
                    SellIn = 1,
                    Quality = 0
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(0, Items[1].Quality);
        }

        [Fact]
        public void QualityStopsAt0()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = 1
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void QualityStopsAt0AfterFewCalls()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 2,
                    Quality = 2
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void QualityDropDoublesAndStopsAt0()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 1,
                    Quality = 4
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].Quality);
        }

        // Aged Brie tests
        [Fact]
        public void QualityPlus1SellinMinus1()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = 1
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(2, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);
        }

        [Fact]
        public void QualityDoublesAndStopsAt50()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 0,
                    Quality = 49
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void QualityPlus2()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 0,
                    Quality = 1
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(3, Items[0].Quality);
        }

        // Sulfuras tests
        [Fact]
        public void QualitySellinStaysSame()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        // BackStage Passes tests
        [Fact]
        public void BackQualityPlus1()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 20,
                    Quality = 1
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void BackQualityPlus2()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 1
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(5, Items[0].Quality);
            Assert.Equal(8, Items[0].SellIn);
        }

        [Fact]
        public void BackQualityPlus3()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 1
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(7, Items[0].Quality);
        }

        [Fact]
        public void BackQualityDropsTo0()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 40
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void BackQualityNoMoreThan50()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 49
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(50, Items[0].Quality);
        }        
    }
}
