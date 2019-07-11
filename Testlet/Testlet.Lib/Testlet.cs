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
            List<Item> randomList = new List<Item>();
            var preTest = Items.Where(x => x.ItemType == ItemTypeEnum.Pretest).ToList();
            var operational = Items.Where(x => x.ItemType == ItemTypeEnum.Operational).ToList();

            Random r = new Random();
            int randomIndex = 0;
            while (preTest.Count > 0)
            {
                randomIndex = r.Next(0, preTest.Count); //Choose a random object in the list
                randomList.Add(preTest[randomIndex]); //add it to the new, random list
                preTest.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            randomIndex = 0;
            while (operational.Count > 0)
            {
                randomIndex = r.Next(0, operational.Count); //Choose a random object in the list
                randomList.Add(operational[randomIndex]); //add it to the new, random list
                operational.RemoveAt(randomIndex); //remove to avoid duplicates
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
