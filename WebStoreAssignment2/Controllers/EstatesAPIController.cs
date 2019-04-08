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
    public class EstatesAPIController : ApiController
    {
        private AdsContext db = new AdsContext();

        // GET: api/EstatesAPI
        public IQueryable<Estate> GetEstates()
        {
            return db.Estates;
        }

        // GET: api/EstatesAPI/5
        [ResponseType(typeof(Estate))]
        public IHttpActionResult GetEstate(int id)
        {
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return NotFound();
            }

            return Ok(estate);
        }

        // PUT: api/EstatesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstate(int id, Estate estate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estate.EstateID)
            {
                return BadRequest();
            }

            db.Entry(estate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstateExists(id))
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

        // POST: api/EstatesAPI
        [ResponseType(typeof(Estate))]
        public IHttpActionResult PostEstate(Estate estate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estates.Add(estate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estate.EstateID }, estate);
        }

        // DELETE: api/EstatesAPI/5
        [BasicAuthentication]
        [ResponseType(typeof(Estate))]
        public IHttpActionResult DeleteEstate(int id)
        {
            Estate estate = db.Estates.Find(id);
            if (estate == null)
            {
                return NotFound();
            }

            db.Estates.Remove(estate);
            db.SaveChanges();

            return Ok(estate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstateExists(int id)
        {
            return db.Estates.Count(e => e.EstateID == id) > 0;
        }
    }
}