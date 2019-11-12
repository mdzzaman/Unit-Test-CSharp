using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Telerik.JustMock;
using WebApi.Entity;
using WebApi.Interface;
using WebApi.Services;

namespace WebApi.Test
{
    [TestClass]
    public class JuiceBuilderTest
    {
        private TestContext _TestInstance;
        public TestContext TestContext
        {
            get { return _TestInstance; }
            set { _TestInstance = value; }
        }

        private IJuiceBuilder juiceBuilder;
        //static IJuiceBuilder juiceBuilder1;
        public JuiceBuilderTest()
        {
            // Temporary off
            //IManual manual = new Mock<IManual>().Object;
            //juiceBuilder = new JuiceBuilder(manual);

            var manualMock = new Mock<IManual>();
            manualMock.Setup(foo => foo.NumberOfFruits(It.IsAny<int>())).Returns(12);
            IManual manual = manualMock.Object;
            juiceBuilder = new JuiceBuilder(manual);
        }


        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            testContext.WriteLine("JuiceBuilderTest");

            //var manualMock = new Mock<IManual>();
            //manualMock.Setup(foo => foo.NumberOfFruits(It.IsAny<int>())).Returns(12);
            //IManual manual = manualMock.Object;
            //juiceBuilder1 = new JuiceBuilder(manual);
        }

        [Owner("Kamruzzaman")]
        [Description("This test is for testing the total number of people eligible for juice")]
        [TestProperty("Test Reviewer: ", "Md.Kamruzzaman")]
        [Timeout(4000)]
        [TestMethod]
        public void GetNumberOfPeople_TotalPeopleGreaterThenNotInterest_Positive()
        {
            //Arrange
            IManual manual = new Mock<IManual>().Object;
            Order order = new Order { NumberOfPeople = 100, NumberOfPeopleNotInterest = 50 };
            var target = new PrivateAccessor(new JuiceBuilder(manual));

            //Act
            var original = target.CallMethod("GetNumberOfPeople", order);

            //Assert
            Assert.AreEqual(original, 50);
        }


        [DataTestMethod]
        [DynamicData(nameof(GetDataForCreateNewJuice), DynamicDataSourceType.Method)]
        public void CreateNewJuice_SixPerson_TwelveFruits(Order order)
        {
            //Arrange
            //Order order = new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 3 };

            //Act
            juiceBuilder.CreateNewJuice(order);
            var original = juiceBuilder.GetJuice();

            //Assert
            Assert.AreEqual(original.NumberOfFruit, 12);
        }
        public static IEnumerable<object[]> GetDataForCreateNewJuice()
        {
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 3 } };
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 1 } };
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 5 } };
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 7 } };
        }


        [DataTestMethod]
        [CustomDataSource]
        public void CreateNewJuice_DynamicData_TwelveFruits(Order order)
        {
            //Arrange
            //Order order = new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 3 };

            //Act
            juiceBuilder.CreateNewJuice(order);
            var original = juiceBuilder.GetJuice();

            //Assert
            Assert.AreEqual(original.NumberOfFruit, 12);
        }

        //    // ============= Currently .net core not support =================
        //[Ignore]
        //[TestMethod]
        //[DeploymentItem("Ocaramba.MsTests\\data\\data.csv")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\data\data.csv", "data#csv", DataAccessMethod.Sequential)]
        //public void CreateNewJuice_CSVData_TwelveFruits()
        //{
        //    //Arrange
        //    //int a = Convert.ToInt32(TestContext.DataRow[0]);
        //    //int b = Convert.ToInt32(TestContext.DataRow[1]);

        //    Order order = new Order
        //    {
        //        NumberOfPeople = (int)this.TestContext.DataRow["NumberOfPeople"],
        //        NumberOfPeopleNotInterest = (int)this.TestContext.DataRow["NumberOfPeopleNotInterest"]
        //    };
        //    //Act
        //    juiceBuilder.CreateNewJuice(order);
        //    var original = juiceBuilder.GetJuice();

        //    //Assert
        //    Assert.AreEqual(original.NumberOfFruit, 12);
        //}

        // Example of method name
        //[Ignore]
        //[TestMethod]
        //public void UoW_InitialCondition_ExpectedResult()
        //{
        //    //Arrange


        //    //Act


        //    //Assert

        //}
    }


    public class CustomDataSourceAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 3 } };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
}
