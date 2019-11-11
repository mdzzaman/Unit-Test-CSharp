using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Interface;
using WebApi.Services;

namespace WebApi.Test
{
    [TestClass]
    public class OrangeJuiceManualTest
    {
        IManual manual;

        [TestInitialize]
        public void Init()
        {
            manual = new OrangeJuiceManual();
        }

        [TestCleanup]
        [Ignore]
        public void TestCleanup()
        {
            //manual.Dispose();
        }

        [Priority(3), DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(12, 24)]
        [DataRow(14, 28)]
        [DataRow(0, 0)]
        public void NumberOfFruits_DoubleFruits_SinglePerson(int person, int expected)
        {
            //Act
            var original = manual.NumberOfFruits(person);

            //Assert
            Assert.AreEqual(original, expected);
        }

        [Priority(1), DataTestMethod]
        [DataRow(-1, 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberOfFruits_NegativeValue_Exception(int person, int expected)
        {
            //Act
            var original = manual.NumberOfFruits(person);

            //Assert
            Assert.AreEqual(original, expected);
        }

        [Priority(2), DataTestMethod]
        [DataRow(-1, 0)]
        public void NumberOfFruits_NegativeValue_ExceptionInTest(int person, int expected)
        {
            //Act
            try
            {
                var original = manual.NumberOfFruits(person);
            }
            catch (ArgumentException)
            {
                // The test succeeded
            }
        }
    }
}
