using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class IDataJobs : IMockJobs
    {
        private AdsContext db = new AdsContext();

        public IQueryable<Jobs> jobs { get { return db.Jobs; } }

        public void Delete(Jobs jobs)
        {
            db.Jobs.Remove(jobs);
            db.SaveChanges();
        }

        public Jobs Save(Jobs jobs)
        {
            if (jobs.Jobsid == 0)
            {
                db.Jobs.Add(jobs);
            }
            else
            {
                db.Entry(jobs).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return jobs;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}