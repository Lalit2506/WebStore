using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStoreAssignment2.Models;

namespace WebStoreAssignment2.Controllers
{
    [RequireHttps]
    public class SuggestionController : Controller
    {
        IMockSuggestion db;

        public SuggestionController()
        {
            this.db = new IDataSuggestion();
        }

        public SuggestionController(IMockSuggestion mockDb)
        {
            this.db = mockDb;
        }

        // GET: Suggestion
        public ActionResult Index()
        {
            SuggestionList p1 = new SuggestionList();
            p1. Suggestion = (db.suggestions.ToList());

            return View("Index", p1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "SuggestionID, Name, Comment")] Suggestion newPerson)
        {
            SuggestionList vm;
            if (ModelState.IsValid)
            {

                db.Save(newPerson);
                ModelState.Clear();
                vm = new SuggestionList()
                {
                    Suggestion = db.suggestions.ToList(),
                };
                return PartialView("Index", vm);
            }

            vm = new SuggestionList()
            {
                Suggestion = db.suggestions.ToList(),
                newPerson = newPerson
            };
            return PartialView("Index", vm);

        }

        // GET: Suggestion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.suggestions.SingleOrDefault(c => c.SuggestionID == id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View("Details", suggestion);
        }

        // GET: Suggestion/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Suggestion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuggestionID,Name,Comment")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.Save(suggestion);
                return RedirectToAction("Index");
            }

            return View(suggestion);
        }

        // GET: Suggestion/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.suggestions.SingleOrDefault(c => c.SuggestionID == id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View("Edit", suggestion);
        }

        // POST: Suggestion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuggestionID,Name,Comment")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.Save(suggestion);
                return RedirectToAction("Index");
            }
            return View(suggestion);
        }

        // GET: Suggestion/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.suggestions.SingleOrDefault(c => c.SuggestionID == id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View("Delete", suggestion);
        }

        // POST: Suggestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suggestion suggestion = db.suggestions.SingleOrDefault(c => c.SuggestionID == id);
            db.Delete(suggestion);
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
