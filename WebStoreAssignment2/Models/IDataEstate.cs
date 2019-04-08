using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class IDataEstate : IMockEstate
    {
        private AdsContext db = new AdsContext();

        public IQueryable<Estate> estates { get { return db.Estates; } }

        public void Delete(Estate estate)
        {
            db.Estates.Remove(estate);
            db.SaveChanges();
        }

        public Estate Save(Estate estate)
        {
            if (estate.EstateID == 0)
            {
                db.Estates.Add(estate);
            }
            else
            {
                db.Entry(estate).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return estate;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}