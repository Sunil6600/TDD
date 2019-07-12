using System;
using System.Collections.Generic;
using System.Linq;

namespace Testlet.Lib
{
    public class Testlet
    {
        public string TestletId;
        public List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }

        public List<Item> Randomize()
        {
            var randomList = new List<Item>();

            var tempItems = Items.Select(x => x).ToList();
            var preTest = Items.Where(x => x.ItemType == ItemTypeEnum.Pretest).ToList();

            var r = new Random();
            int randomIndex;

            for (var i = 0; i < 2; i++)
            {
                randomIndex = r.Next(0, preTest.Count); //Choose a random object in the list
                randomList.Add(preTest[randomIndex]); //add it to the new, random list
                tempItems.Remove(preTest[randomIndex]); //remove from unfiltered list also
                preTest.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            while (tempItems.Count > 0)                
            {
                randomIndex = r.Next(0, tempItems.Count); //Choose a random object in the list
                randomList.Add(tempItems[randomIndex]); //add it to the new, random list
                tempItems.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList;
        }
    }

    public class Item
    {
        public string ItemId;
        public ItemTypeEnum ItemType;
    }

    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }

    public class TestletResult
    {
        public Testlet TestletList()
        {
            var items = new List<Item>
            {
                new Item{ItemId = "1", ItemType = ItemTypeEnum.Pretest},
                new Item{ItemId = "2", ItemType = ItemTypeEnum.Pretest},
                new Item{ItemId = "3", ItemType = ItemTypeEnum.Pretest},
                new Item{ItemId = "4", ItemType = ItemTypeEnum.Pretest},
                new Item{ItemId = "5", ItemType = ItemTypeEnum.Operational},
                new Item{ItemId = "6", ItemType = ItemTypeEnum.Operational},
                new Item{ItemId = "7", ItemType = ItemTypeEnum.Operational},
                new Item{ItemId = "8", ItemType = ItemTypeEnum.Operational},
                new Item{ItemId = "9", ItemType = ItemTypeEnum.Operational},
                new Item{ItemId = "10", ItemType = ItemTypeEnum.Operational},
            };

            return new Testlet("1", items);
        }
    }
}
