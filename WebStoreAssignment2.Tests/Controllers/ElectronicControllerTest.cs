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
    /// Summary description for ElectronicsControllerTest
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
              new Electronics { Electronicsid = 09, Type = "phone", Model ="Iphone8", Brand ="Apple", price = 2000, Description = "Good", electronicPicture = "image.jpg"}

            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockElectronic>();
            mock.Setup(c => c.Electronic).Returns(Electronic.AsQueryable());

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
        public void Detail()
        {
            // Arrange
            ElectronicController controller = new ElectronicController();

            // Act
            ViewResult result = controller.Details(09) as ViewResult;

            // Assert
            Assert.AreEqual("Detail", result.ViewName);
        }
        [TestMethod]

        public void Edit()
        {
            // Arrange
            ElectronicController controller = new ElectronicController();

            // Act
            ViewResult result = controller.Edit(09) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }
    }
}
