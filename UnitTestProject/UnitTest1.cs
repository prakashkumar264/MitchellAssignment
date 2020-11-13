using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MitchellAssignment.Controllers;
using MitchellAssignment.Models;
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
        public void TestCreateMake()
        {
            vehiclesController controller = new vehiclesController();
            RedirectToRouteResult result = controller.Create(new vehicle()
            {
                Make = "Toyota",
                Name = "Corolla",
                Year = 2000
            }) as RedirectToRouteResult;
            FormCollection form = new FormCollection();
            form["Make"] = "Toyota";
            ViewResult viewResult = controller.Index(form) as ViewResult;
            var s = (IEnumerable<vehicle>)viewResult.ViewData.Model;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(1, s.Count());
        }

        [TestMethod]
        public void Test_DetailView()
        {
            vehiclesController controller = new vehiclesController();
            ViewResult result = controller.Details(id: 1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void Test_Detail_Data()
        {
            vehiclesController controller = new vehiclesController();
            ViewResult viewResult = controller.Details(id: 1) as ViewResult;
            vehicle vehicle = (vehicle)viewResult.ViewData.Model;
            Assert.AreEqual("Toyota", vehicle.Make);
            Assert.AreEqual("Corolla", vehicle.Name);
            Assert.AreEqual(2000, vehicle.Year);
            Assert.AreEqual("Details", viewResult.ViewName);
        }

        [TestMethod]
        public void Test_Detail_Null()
        {
            vehiclesController controller = new vehiclesController();
            HttpStatusCodeResult vehicle = (HttpStatusCodeResult)controller.Details(id: null);
            Assert.AreEqual("400", vehicle.StatusCode.ToString());
        }

        [TestMethod]
        public void Test_Edit_view()
        {
            vehiclesController controller = new vehiclesController();
            ViewResult viewResult = controller.Edit(id: 1) as ViewResult;
            vehicle vehicle = (vehicle)viewResult.ViewData.Model;
            Assert.AreEqual("Toyota", vehicle.Make);
            Assert.AreEqual("Corolla", vehicle.Name);
            Assert.AreEqual(2000, vehicle.Year);           
            Assert.AreEqual("Edit", viewResult.ViewName);
        }

        [TestMethod]
        public void Test_Edit_Data()
        {
            vehiclesController controller = new vehiclesController();
            ViewResult viewResult = controller.Edit(id: 1) as ViewResult;
            vehicle vehicle = (vehicle)viewResult.ViewData.Model;
            vehicle.Year = 1996;
            controller.Edit(vehicle);
            ViewResult viewResult1 = controller.Edit(id: 1) as ViewResult;
            vehicle vehicle1 = (vehicle)viewResult.ViewData.Model;
            Assert.AreEqual("Toyota", vehicle1.Make);
            Assert.AreEqual("Corolla", vehicle1.Name);
            Assert.AreEqual(1996, vehicle1.Year);

        }

        [TestMethod]
        public void TestDeleteRedirect()
        {
        vehiclesController controller = new vehiclesController();
        RedirectToRouteResult result = controller.DeleteConfirmed(1) as RedirectToRouteResult;
        Assert.AreEqual("Index", result.RouteValues["action"]);
        }

    }
}
