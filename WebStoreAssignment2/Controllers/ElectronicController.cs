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
    public class ElectronicController : Controller
    {
        IMockElectronic db;

        public ElectronicController()
        {
            this.db = new IDataElectronic();
        }

        public ElectronicController(IMockElectronic mockDb)
        {
            this.db = mockDb;
        }

        // GET: Electronic
        public ActionResult Index()
        {
            return View("Index", db.electronics.OrderBy(c => c.Electronicsid).ToList());
        }

        // GET: Electronic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Electronics electronics = db.electronics.SingleOrDefault(c => c.Electronicsid == id);
            if (electronics == null)
            {
                return HttpNotFound();
            }
            return View(electronics);
        }

        // GET: Electronic/Create
        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Electronic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Electronicsid,Type,Model,Brand,price,Description,electronicPicture")] Electronics electronics, String Picture)
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
                        electronics.electronicPicture = fName;
                    }
                }
                else
                {
                    // This is to keep the old file if there is no new photo
                    electronics.electronicPicture = Picture;
                }
                db.Save(electronics);
                return RedirectToAction("Index");
            }

            return View(electronics);
        }

        // GET: Electronic/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Electronics electronics = db.electronics.SingleOrDefault(c => c.Electronicsid == id);
            if (electronics == null)
            {
                return HttpNotFound();
            }
            return View("Edit", electronics);
        }

        // POST: Electronic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Electronicsid,Type,Model,Brand,price,Description,electronicPicture")] Electronics electronics, String Picture)
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
                        electronics.electronicPicture = fName;
                    }
                }
                else
                {
                    // This is to keep the old file if there is no new photo
                    electronics.electronicPicture = Picture;
                }
                db.Save(electronics);
                return RedirectToAction("Index");
            }
            return View(electronics);
        }

        // GET: Electronic/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Electronics electronics = db.electronics.SingleOrDefault(c => c.Electronicsid == id);
            if (electronics == null)
            {
                return HttpNotFound();
            }
            return View("Delete", electronics);
        }

        // POST: Electronic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Electronics electronics = db.electronics.SingleOrDefault(c => c.Electronicsid == id);
            db.Delete(electronics);
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
            var elec = (from a in db.electronics where a.Electronicsid == id select a).SingleOrDefault();
            return View("Buy", elec);
        }
    }
}
