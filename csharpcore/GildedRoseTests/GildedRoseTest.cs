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

        // tests for usual items
        [Fact]
        public void Sellin_And_Quality_Should_DecreaseBy1()
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
        public void Sellin_ShouldBe_Negative1()
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
        public void Quality_Should_LowerBy2()
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
        public void Quality_ShouldNot_BeNegative()
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
        public void Quality_Should_StopAt0()
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
        public void Quality_Should_StopAt0_After_FewCalls()
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
        public void Quality_Should_DecreaseBy2_And_StopAt0()
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
        public void Quality_Should_IncreaseBy1_And_Sellin_DecreaseBy1()
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
        public void Quality_Should_IncreaseBy2_And_StopAt50()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 0,
                    Quality = 47
                },
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void Quality_Should_IncreaseBy2()
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
        public void Quality_And_Sellin_Should_Stay_Same()
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
        public void BackStage_Quality_Should_InreaseBy1()
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
        public void BackStage_Quality_Should_IncreaseBy2()
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
        public void BackStage_Quality_Should_IncreaseBy3()
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
        public void BackStage_Quality_Should_DecreaseTo0()
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
        public void BackStage_Quality_Should_StopAt50()
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

        // Conjured items tests
        [Fact]
        public void Conjured_Should_DecreaseBy2()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 20,
                    Quality = 50
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(48, Items[0].Quality);
        }

        [Fact]
        public void Conjured_Should_DecreaseBy4()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 50
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(46, Items[0].Quality);
        }

        [Fact]
        public void Conjured_Should_StopAt0()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 6
                },
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 10,
                    Quality = 3
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(0, Items[1].Quality);
        }

        [Fact]
        public void Conjured_Should_Be2()
        {
            // ARRANGE
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 1,
                    Quality = 8
                }
            };
            GildedRose sut = new GildedRose(Items);

            // ACT
            sut.UpdateQuality();
            sut.UpdateQuality();

            // ASSERT
            Assert.Equal(2, Items[0].Quality);
        }
    }
}
