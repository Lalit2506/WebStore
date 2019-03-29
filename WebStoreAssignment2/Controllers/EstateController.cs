﻿using System;
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
    [RequireHttps]
    public class EstateController : Controller
    {
        private AdsContext db = new AdsContext();

        // GET: Estate
        public ActionResult Index()
        {
            return View(db.Estates.ToList());
        }

        // GET: Estate/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return HttpNotFound();
            }
            return View(estate);
        }

        // GET: Estate/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstateID,Type,Address,Price,location,Description,EstatePhoto")] Estate estate, String CurrentPhoto)
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
                        estate.EstatePhoto = fName;
                    }
                }
                else
                {
                    // This is to keep the old file if there is no new photo
                    estate.EstatePhoto = CurrentPhoto;
                }
                db.Estates.Add(estate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estate);
        }

        // GET: Estate/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return HttpNotFound();
            }
            return View(estate);
        }

        // POST: Estate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstateID,Type,Address,Price,location,Description,EstatePhoto")] Estate estate, String CurrentPhoto)
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
                        estate.EstatePhoto = fName;
                    }
                }
                else
                {
                    // This is to keep the old file if there is no new photo
                    estate.EstatePhoto = CurrentPhoto;
                }
                db.Entry(estate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estate);
        }

        // GET: Estate/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return HttpNotFound();
            }
            return View(estate);
        }

        // POST: Estate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estate estate = db.Estates.Find(id);
            db.Estates.Remove(estate);
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
