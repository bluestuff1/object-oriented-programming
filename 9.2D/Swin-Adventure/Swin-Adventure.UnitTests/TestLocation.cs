﻿using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
    [TestFixture]
    public class TestLocation
    {

        Location l;
        Player p;
        Item sword = new Item(new string[] { "sword" }, "bronze", "This is a cheap sword");

        [Test]
        public void TestLocationIdentifyItself()
        {
            p = new Player("player1", "This is player 1");
            l = new Location("toilet", "This place stinks");

            bool actual = l.AreYou("location");

            Assert.IsTrue(actual, "Locations can identify themselves");
        }

        [Test]
        public void TestLocationLocateItems()
        {
            p = new Player("player1", "This is player 1");
            l = new Location("toilet", "This place stinks");
            l.Inventory.Put(sword);

            GameObject expected = sword;
            GameObject actual = l.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Locations can locate items they have");
        }

        [Test]
        public void TestPlayerLocateItemsInLocation()
        {
            p = new Player("player1", "This is player 1");
            l = new Location("toilet", "This place stinks");

            p.Location = l;
            l.Inventory.Put(sword);

            GameObject expected = sword;
            GameObject actual = p.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Players can locate items in their location");
        }
    }
}
