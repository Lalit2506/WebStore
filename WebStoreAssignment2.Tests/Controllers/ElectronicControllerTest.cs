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
    /// Summary description for ElectronicControllerTest
    /// </summary>
    [TestClass]
    public class ElectronicControllerTest
    {
        ElectronicController controller;
        List<Electronics> electronics;
        Mock<IMockElectronic> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            electronics = new List<Electronics>
            {
              new Electronics { Electronicsid = 1, Type = "PC", price = 2000, Brand = "Samsung", Model = "AlienWare" ,Description = "Good", electronicPicture = "image.jpg"}

            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockElectronic>();
            mock.Setup(c => c.electronics).Returns(electronics.AsQueryable());

            // initialize the controller and inject the mock object
            controller = new ElectronicController(mock.Object);
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

            var results = (List<Electronics>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(electronics.OrderBy(c => c.Electronicsid).ToList(), results);
        }



        [TestMethod]

        public void Detailsright()
        {
            //arrange

            //act
            var result = ((ViewResult)controller.Details(1)).Model;

            //assert
            Assert.AreEqual(electronics.SingleOrDefault(c => c.Electronicsid == 1), result);
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
            Assert.AreEqual(electronics.SingleOrDefault(c => c.Electronicsid == 1), result);
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
