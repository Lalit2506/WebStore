using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStoreAssignment2.Models;

namespace WebStoreAssignment2.Controllers
{
    public class CarController : Controller
    {
        IMockCar db;

        public CarController()
        {
            this.db = new IDataCar();
        }

        public CarController(IMockCar mockDb)
        {
            this.db = mockDb;
        }

        // GET: Car
        public ActionResult Index()
        {
            return View("Index", db.cars.OrderBy(c => c.Carid).ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car cars = db.cars.SingleOrDefault(c => c.Carid == id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Car/Create
        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carid,Cartype,Model,year,Make,Price,Condition,CarPhoto")] Car cars, String Picture)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files != null)
                {
                    var file = Request.Files[0];

                    if (file.FileName != null && file.ContentLength > 0)
                    {
                        // This is to remove the path of the photo from edge
                        string fName = Path.GetFileName(file.FileName);

                        string path = Server.MapPath("~/Content/Images/" + fName);
                        file.SaveAs(path);
                        cars.CarPhoto = fName;
                    }
                }
                else
                {
                    // This is to keep the old file if there is no new photo
                    cars.CarPhoto = Picture;
                }
                db.Save(cars);
                return RedirectToAction("Index");
            }

            return View(cars);
        }

        // GET: Car/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car cars = db.cars.SingleOrDefault(c => c.Carid == id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View("Edit", cars);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carid,Cartype,Model,year,Price,Condition, CarPhoto")] Car cars, String Picture)
        {
            if (ModelState.IsValid)
            {

                if (Request.Files != null)
                {
                    var file = Request.Files[0];

                    if (file.FileName != null && file.ContentLength > 0)
                    {
                        // This is to remove the path of the photo from edge
                        string fName = Path.GetFileName(file.FileName);

                        string path = Server.MapPath("~/Content/Images/" + fName);
                        file.SaveAs(path);
                        cars.CarPhoto = fName;
                    }
                }
                else
                {
                    // This is to keep the old file if there is no new photo
                    cars.CarPhoto = Picture;
                }
                db.Save(cars);
                return RedirectToAction("Index");
            }
            return View(cars);
        }

        // GET: Car/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car Cars = db.cars.SingleOrDefault(c => c.Carid == id);
            if (Cars == null)
            {
                return HttpNotFound();
            }
            return View("Delete", Cars);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car cars = db.cars.SingleOrDefault(c => c.Carid == id);
            db.Delete(cars);
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
        [Authorize]
        public ActionResult Buy(int? id)
        {
            var Car = (from a in db.cars where a.Carid == id select a).SingleOrDefault();
            return View("Buy", Car);
        }
    }
}
