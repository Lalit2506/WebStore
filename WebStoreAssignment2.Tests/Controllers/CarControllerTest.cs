using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStoreAssignment2.Controllers;
using WebStoreAssignment2.Models;
using Moq;
using System.Web.Mvc;
using System.Linq;

namespace WebStoreAssignment2.Tests.Controllers
{
    /// <summary>
    /// Summary description for CarsControllerTest
    /// </summary>
    [TestClass]
    public class ControllerTest
    {
        CarController controller;
        List<Car> cars;
        Mock<IMockCars> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            cars = new List<Car>
            {
              new Car { Carid = 09, Cartype = "SUV", Model ="CRV", Make ="Honda", year = 2019, Price = 40000, Condition ="New", CarPhoto = "image.jpg"}

            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockCars>();
            mock.Setup(c => c.cars).Returns(cars.AsQueryable());

            // initialize the controller and inject the mock object
            controller = new CarController(mock.Object);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // arrange
            // now handled in TestInitialize

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadsCategories()
        {
            // act

            var results = (List<Car>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(cars.OrderBy(c => c.Carid).ToList(), results);

        }
        [TestMethod]
        public void Detail()
        {
            // Arrange
            CarController controller = new CarController();

            // Act
            ViewResult result = controller.Details(09) as ViewResult;

            // Assert
            Assert.AreEqual("Detail", result.ViewName);
        }
        [TestMethod]

        public void Edit()
        {
            // Arrange
            CarController controller = new CarController();

            // Act
            ViewResult result = controller.Edit(09) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }
    }
}
