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
    /// Summary description for JobsControllerTest
    /// </summary>
    [TestClass]
    public class JobsControllerTest
    {
        JobController controller;
        List<Jobs> jobs;
        Mock<IMockJobs> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            // create some mock data
            jobs = new List<Jobs>
            {
              new Jobs { Jobsid = 1, Jobtype = "Part time", Salary = 200, Hours = 30, Company = "georgian", location = "Toronto", Description = "ASP.NET DEVELOPER", CompanyPicture = "image.jpg"}

            };

            // set up & populate our mock object to inject into our controller
            mock = new Mock<IMockJobs>();
            mock.Setup(c => c.jobs).Returns(jobs.AsQueryable());

            // initialize the controller and inject the mock object
            controller = new JobController(mock.Object);
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
         
            var results = (List<Jobs>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(jobs.OrderBy(c => c.Jobsid).ToList(), results);
        }
    }
}
