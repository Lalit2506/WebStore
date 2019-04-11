using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStoreAssignment2.Controllers;
using WebStoreAssignment2.Models;
using Moq;
using System.Linq;
using System.Web.Mvc;

namespace WebStoreAssignment2.Tests.Controllers
{
    /// <summary>
    /// Summary description for CarControllerTest
    /// </summary>
    [TestClass]
    public class CarControllerTest
    {
        CarController controller;
        List<Car> cars;
        Mock<IMockCar> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            cars = new List<Car>
            {
              new Car { Carid = 1, Cartype = "Sedan", Price = 2000, Make = "GMC", Model = "Sunny" ,Condition = "Good",year = 2000, CarPhoto = "image.jpg"}

            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockCar>();
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

        public void Detailsright()
        {
            //arrange

            //act
            var result = ((ViewResult)controller.Details(1)).Model;

            //assert
            Assert.AreEqual(cars.SingleOrDefault(c => c.Carid == 1), result);
        }

        [TestMethod]
        public void DetailsException()
        {
            // arrange

            //act
            HttpNotFoundResult result = controller.Details(0) as HttpNotFoundResult;

            //assert
            Assert.AreEqual(404, result.StatusCode);

        }

        [TestMethod]
        public void Detailsnull()
        {
            //arrange

            //act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(400, result.StatusCode);
        }



        [TestMethod]
        public void Create()
        {
            //arrange

            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.AreEqual("Create", result.ViewName);
        }




        [TestMethod]
        public void Edit()
        {
            //arrange

            //act
            ViewResult result = controller.Edit(1) as ViewResult;

            //assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]

        public void EditRight()
        {
            //arrange

            //act
            var result = ((ViewResult)controller.Edit(1)).Model;

            //assert
            Assert.AreEqual(cars.SingleOrDefault(c => c.Carid == 1), result);
        }

        [TestMethod]
        public void EditWrong()
        {
            //arrange

            //act
            HttpNotFoundResult result = controller.Edit(7) as HttpNotFoundResult;

            //assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void EditNull()
        {
            //arrange

            //act
            HttpStatusCodeResult result = controller.Edit(null) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void Delete()
        {
            //arrange

            //act
            ViewResult result = controller.Delete(1) as ViewResult;

            //assert
            Assert.AreEqual("Delete", result.ViewName);

        }

        [TestMethod]
        public void DeleteNull()
        {
            //arrange

            //act
            HttpStatusCodeResult result = controller.Delete(null) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void DeleteWrong()
        {
            //arrange

            //act
            HttpNotFoundResult result = controller.Delete(4) as HttpNotFoundResult;

            //assert
            Assert.AreEqual(404, result.StatusCode);
        }
        [TestMethod]
        public void Deleteconfirm()
        {
            //arrange
            RedirectToRouteResult result = controller.DeleteConfirmed(1) as RedirectToRouteResult;

            //act
            var listOfResult = result.RouteValues.ToArray();

            //assert
            Assert.AreEqual("Index", listOfResult[0].Value);
        }


        [TestMethod]
        public void Buy()
        {
            //arrange

            //act
            ViewResult result = controller.Buy(1) as ViewResult;

            //assert
            Assert.AreEqual("Buy", result.ViewName);

        }
    }
}
