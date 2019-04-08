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
    public class ElectronicsAPIController : ApiController
    {
        private AdsContext db = new AdsContext();

        // GET: api/ElectronicsAPI
        public IQueryable<Electronics> GetElectronics()
        {
            return db.Electronics;
        }

        // GET: api/ElectronicsAPI/5
        [ResponseType(typeof(Electronics))]
        public IHttpActionResult GetElectronics(int id)
        {
            Electronics electronics = db.Electronics.Find(id);
            if (electronics == null)
            {
                return NotFound();
            }

            return Ok(electronics);
        }

        // PUT: api/ElectronicsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElectronics(int id, Electronics electronics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != electronics.Electronicsid)
            {
                return BadRequest();
            }

            db.Entry(electronics).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectronicsExists(id))
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

        // POST: api/ElectronicsAPI
        [ResponseType(typeof(Electronics))]
        public IHttpActionResult PostElectronics(Electronics electronics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Electronics.Add(electronics);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = electronics.Electronicsid }, electronics);
        }

        // DELETE: api/ElectronicsAPI/5
        [BasicAuthentication]
        [ResponseType(typeof(Electronics))]
        public IHttpActionResult DeleteElectronics(int id)
        {
            Electronics electronics = db.Electronics.Find(id);
            if (electronics == null)
            {
                return NotFound();
            }

            db.Electronics.Remove(electronics);
            db.SaveChanges();

            return Ok(electronics);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElectronicsExists(int id)
        {
            return db.Electronics.Count(e => e.Electronicsid == id) > 0;
        }
    }
}