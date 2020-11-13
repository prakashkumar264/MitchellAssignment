using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellAssignment.Controllers;
using MitchellAssignment.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyThatMyDatabaseConnectionStringExists()
        {
            Assert.IsNotNull(ConfigurationManager.ConnectionStrings["DBModel"]);
        }

        [TestMethod]
        public void TestCreateRedirect()
        {
            vehiclesController controller = new vehiclesController();
            RedirectToRouteResult result = controller.Create(new vehicle()
            {
                Make = "Demo",
                Name = "Test",
                Year = 2050
            }) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void TestDeleteRedirect()
        {
            vehiclesController controller = new vehiclesController();
            RedirectToRouteResult result = controller.DeleteConfirmed(12) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Test_DetailView()
        {
            vehiclesController controller = new vehiclesController();
            ViewResult result = controller.Details(id: 11) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void Test_Detail_Null()
        {
            vehiclesController controller = new vehiclesController();
            HttpStatusCodeResult vehicle = (HttpStatusCodeResult)controller.Details(id: null);
            Assert.AreEqual("400", vehicle.StatusCode.ToString());
        }

        [TestMethod]
        public void TestCreateMake()
        {
            vehiclesController controller = new vehiclesController();
            RedirectToRouteResult result = controller.Create(new vehicle()
            {
                Make = "TestFilter",
                Name = "Prakash",
                Year = 2050
            }) as RedirectToRouteResult;
            FormCollection form = new FormCollection();
            form["Make"] = "TestFilter";
            ViewResult viewResult = controller.Index(form) as ViewResult;
            var s = (IEnumerable<vehicle>) viewResult.ViewData.Model;
            Assert.AreEqual(1, s.Count());
        }

        [TestMethod]
        public void Test_Index_Filter()
        {
            vehiclesController controller = new vehiclesController();
            FormCollection form = new FormCollection();
            form["Make"] = "TestFilter";
            ViewResult viewResult = controller.Index(form) as ViewResult;
            var s = (IEnumerable<vehicle>)viewResult.ViewData.Model;
            Assert.AreEqual(1, s.Count());
        }

    }
}
