using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MitchellAssignment.Models;

namespace MitchellAssignment.Controllers
{
    /// <summary>
    /// Contains all the required methods to perform CRUD operations
    /// </summary>
    public class vehiclesController : Controller
    {
       
        private dbContext db = new dbContext();

        // GET: vehicles
        /// <summary>
        /// Returns the list of the vehicles in database
        /// Creates a session for enum of all makes in the vehicles db.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            Session["Make"] = db.MakeDatas.SqlQuery("select distinct Make from dbo.vehicles").ToList();
            return View("Index", db.vehicles.ToList());
        }

        /// <summary>
        /// Returns list of vehicles based on make filter
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            String Make = formCollection["Make"];
            return View("Index", db.vehicles.SqlQuery("Select * from dbo.vehicles where Make = @Make", new SqlParameter("@Make", Make)).ToList());
        }

        /// <summary>
        /// Get details of vehicle based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: vehicles/Details/5
        public ActionResult Details(int? id)
         {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View("Details", vehicle);
        }

        // GET: vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vehicles/Create
        /// <summary>
        /// Creates vehicle data
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Make,Year")] vehicle vehicle)
        {
            
            if (ModelState.IsValid)
            {
                db.vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: vehicles/Edit/5
        /// <summary>
        /// Get vehicle for edit based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View("Edit", vehicle);
        }

        // POST: vehicles/Edit/5
        /// <summary>
        /// Edits the selected vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Make,Year")] vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: vehicles/Delete/5
        /// <summary>
        /// Deletes the selected vehicle based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicle vehicle = db.vehicles.Find(id);
            db.vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
