using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class IDataSuggestion : IMockSuggestion
    {
        private AdsContext db = new AdsContext();
        public IQueryable<Suggestion> suggestions { get { return db.Suggestions; } }

        public void Delete(Suggestion suggestion)
        {
            db.Suggestions.Remove(suggestion);
            db.SaveChanges();
        }

        public Suggestion Save(Suggestion suggestion)
        {
            if (suggestion.SuggestionID == 0)
            {
                db.Suggestions.Add(suggestion);
            }
            else
            {
                db.Entry(suggestion).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return suggestion;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}