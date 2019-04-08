﻿using System;
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
    /// Summary description for EstateControlleTest
    /// </summary>
    [TestClass]
    public class EstateControlleTest
    {
        EstateController controller;
        List<Estate> estates;
        Mock<IMockEstate> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            estates = new List<Estate>
            {
              new Estate { EstateID = 1, Type = "House Rental", Price = 200, Address = "326 Grove", location = "Barrie" ,Description = "Good" ,EstatePhoto = "image.jpg"}

            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockEstate>();
            mock.Setup(c => c.estates).Returns(estates.AsQueryable());

            // initialize the controller and inject the mock object
            controller = new EstateController(mock.Object);
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
            
            var results = (List<Estate>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(estates.OrderBy(c => c.EstateID).ToList(), results);
        }



        [TestMethod]

        public void Detailsnull()
        {
            //arrange

            //act
            var result = ((ViewResult)controller.Details(1)).Model;

            //assert
            Assert.AreEqual(estates.SingleOrDefault(c => c.EstateID == 1), result);
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
    }
}
