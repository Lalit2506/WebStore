using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class IDataElectronic : IMockElectronic
    {
        private AdsContext db = new AdsContext();
        public IQueryable<Electronics> electronics { get { return db.Electronics; } }

        public void Delete(Electronics electronics)
        {
            db.Electronics.Remove(electronics);
            db.SaveChanges();
        }

        public Electronics Save(Electronics electronics)
        {
            if (electronics.Electronicsid == 0)
            {
                db.Electronics.Add(electronics);
            }
            else
            {
                db.Entry(electronics).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return electronics;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}