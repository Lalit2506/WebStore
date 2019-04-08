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
    [RequireHttps]
    public class JobController : Controller
    {
        IMockJobs db;

        public JobController()
        {
            this.db = new IDataJobs();
        }

        public JobController(IMockJobs mockDb)
        {
            this.db = mockDb;
        }

        // GET: Job
        public ActionResult Index()
        {
            return View("Index", db.jobs.OrderBy(c => c.Jobsid).ToList());
        }

        // GET: Job/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.jobs.SingleOrDefault(c => c.Jobsid == id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // GET: Job/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Jobsid,Jobtype,Salary,Company,Hours,location,Description,CompanyPicture")] Jobs jobs, String Picture)
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
                        jobs.CompanyPicture = fName;
                    }
                }
                else
                {
                    // This is to keep the old file if there is no new photo
                    jobs.CompanyPicture = Picture;
                }
                db.Save(jobs);
                return RedirectToAction("Index");
            }

            return View(jobs);
        }

        // GET: Job/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.jobs.SingleOrDefault(c => c.Jobsid == id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Jobsid,Jobtype,Salary,Company,Hours,location,Description,CompanyPicture")] Jobs jobs, String Picture)
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
                            jobs.CompanyPicture = fName;
                        }
                    }
                    else
                    {
                    // This is to keep the old file if there is no new photo
                    jobs.CompanyPicture = Picture;
                    }
                db.Save(jobs);
                return RedirectToAction("Index");
            }
            return View(jobs);
        }

        // GET: Job/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.jobs.SingleOrDefault(c => c.Jobsid == id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobs jobs = db.jobs.SingleOrDefault(c => c.Jobsid == id);
            db.Delete(jobs);
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
        public ActionResult Apply(int id)
        {
            var job = (from a in db.jobs where a.Jobsid == id select a).SingleOrDefault();
            return View(job);
        }
    }
}
