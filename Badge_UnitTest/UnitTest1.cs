using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Badge_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddBadge_WhenNoBadgeExists_ShouldAddNewBadgeToRepo()
        {
            // Arrange
            var _test1 = new BadgeRepository();

            // Act
            _test1.AddBadge(1, new List<string>());

            // Assert
            var badges = _test1.GetBadges();
            Assert.IsTrue(badges.ContainsKey(1));
        }

        [TestMethod]
        public void AddBadge_WhenBadgeExists_ShouldNotAddNewBadgeToRepo()
        {
            // Arrange
            var _testAdd = new BadgeRepository();

            // Act
            _testAdd.AddBadge(1, new List<string>() { "door1", "door2" });

            var badges = _testAdd.GetBadges();
            Assert.IsTrue(badges.ContainsKey(1));

            _testAdd.AddBadge(1, new List<string>() { "door3", "door4" });

            // Assert
            badges = _testAdd.GetBadges();
            Assert.IsTrue(badges.ContainsKey(1));
            Assert.AreEqual(2, badges[1].Count);       // .FirstOrDefault is iterating through your list looking for the element value that you specified in the predicate otherwise it returns null
            Assert.IsNotNull(badges[1].FirstOrDefault(b => b == "door1"));
            Assert.IsNotNull(badges[1].FirstOrDefault(b => b == "door2"));
            Assert.IsNull(badges[1].FirstOrDefault(b => b == "door3"));
            Assert.IsNull(badges[1].FirstOrDefault(b => b == "door4"));

        }
        [TestMethod]
        public void RemoveAccess_WhenAddedToTheBadge_ShouldRemoveToRepo()
        {
            // Arrange
            var _testRemove = new BadgeRepository();

            // Act
            _testRemove.AddBadge(1, new List<string>() { "door3" });
            _testRemove.RemoveAccess(1, "door 3");

            // Assert
            var badges = _testRemove.GetBadges();

            Assert.IsTrue(badges.ContainsKey(1));
        }
        //[TestMethod]
        //public void UpdateAccess_WhenAddedToTheBadge_ShouldUpdatCurrentBadge()
        //{
        //    // Arrange
        //    var _testUpdate = new BadgeRepository();

        //    // Act
        //    _testUpdate.AddBadge(1, new List<string>() { "door3", "door5" });
        //    _testUpdate.UpdateBadge(1, new List<string> {"door3" , "door4" });

        //    // Assert
        //    var badges = _testUpdate.GetBadges();
        //    Assert.IsTrue(badges.ContainsKey(1));
        //}
        //didnt have enough time to test the final method.
    }
}
