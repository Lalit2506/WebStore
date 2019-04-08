using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebStoreAssignment2.App_Start;
using WebStoreAssignment2.Models;

namespace WebStoreAssignment2.Controllers
{
    public class JobsAPIController : ApiController
    {
        private AdsContext db = new AdsContext();

        // GET: api/JobsAPI
        public IQueryable<Jobs> GetJobs()
        {
            return db.Jobs;
        }

        // GET: api/JobsAPI/5
        [ResponseType(typeof(Jobs))]
        public IHttpActionResult GetJobs(int id)
        {
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return NotFound();
            }

            return Ok(jobs);
        }

        // PUT: api/JobsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobs(int id, Jobs jobs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobs.Jobsid)
            {
                return BadRequest();
            }

            db.Entry(jobs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/JobsAPI
        [ResponseType(typeof(Jobs))]
        public IHttpActionResult PostJobs(Jobs jobs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jobs.Add(jobs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobs.Jobsid }, jobs);
        }

        // DELETE: api/JobsAPI/5
        [BasicAuthentication]
        [ResponseType(typeof(Jobs))]
        public IHttpActionResult DeleteJobs(int id)
        {
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return NotFound();
            }

            db.Jobs.Remove(jobs);
            db.SaveChanges();

            return Ok(jobs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobsExists(int id)
        {
            return db.Jobs.Count(e => e.Jobsid == id) > 0;
        }
    }
}