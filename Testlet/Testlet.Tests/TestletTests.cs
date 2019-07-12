using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Testlet.Lib;

namespace Testlet.Tests
{
    [TestClass]
    public class TestletTests
    {
        [TestMethod]
        public void TestFixedTotalItems6Operational4Pretest()
        {
            // Arrange
            TestletResult testLet = new TestletResult();

            // Act
            var testLetList = testLet.TestletList();

            // Assert

            Assert.IsNotNull(testLetList, "Testlet result is null");
            Assert.AreEqual(10, testLetList.Items.Count);
            Assert.AreEqual(4, testLetList.Items.Where(x => x.ItemType == ItemTypeEnum.Pretest).ToList().Count);
            Assert.AreEqual(6, testLetList.Items.Where(x => x.ItemType == ItemTypeEnum.Operational).ToList().Count);
        }

        [TestMethod]
        public void TestAfterRandomizeTop4PreTestAndBottom6Operational()
        {
            // Arrange
            TestletResult testLet = new TestletResult();

            // Act
            var items = testLet.TestletList().Randomize();

            // Assert

            Assert.IsNotNull(items, "Items result is null");
            Assert.AreEqual(10, items.Count);
            Assert.AreEqual(2, items.Take(2).Where(x => x.ItemType == ItemTypeEnum.Pretest).ToList().Count);
            items.Reverse();
            Assert.IsTrue(items.Take(8).Where(x => x.ItemType == ItemTypeEnum.Pretest).ToList().Count > 1, "There is no pretest in mix");
            Assert.IsTrue(items.Take(8).Where(x => x.ItemType == ItemTypeEnum.Operational).ToList().Count > 1, "There is no operational in mix");
        }
    }
}
