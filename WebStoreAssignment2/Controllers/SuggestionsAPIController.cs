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
    public class SuggestionsAPIController : ApiController
    {
        private AdsContext db = new AdsContext();

        // GET: api/SuggestionsAPI
        public IQueryable<Suggestion> GetSuggestions()
        {
            return db.Suggestions;
        }

        // GET: api/SuggestionsAPI/5
        [ResponseType(typeof(Suggestion))]
        public IHttpActionResult GetSuggestion(int id)
        {
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            return Ok(suggestion);
        }

        // PUT: api/SuggestionsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuggestion(int id, Suggestion suggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suggestion.SuggestionID)
            {
                return BadRequest();
            }

            db.Entry(suggestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuggestionExists(id))
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

        // POST: api/SuggestionsAPI
        [ResponseType(typeof(Suggestion))]
        public IHttpActionResult PostSuggestion(Suggestion suggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suggestions.Add(suggestion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suggestion.SuggestionID }, suggestion);
        }

        // DELETE: api/SuggestionsAPI/5
        [BasicAuthentication]
        [ResponseType(typeof(Suggestion))]
        public IHttpActionResult DeleteSuggestion(int id)
        {
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            db.Suggestions.Remove(suggestion);
            db.SaveChanges();

            return Ok(suggestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuggestionExists(int id)
        {
            return db.Suggestions.Count(e => e.SuggestionID == id) > 0;
        }
    }
}