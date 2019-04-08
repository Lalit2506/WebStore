using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public interface IMockJobs
    {
        IQueryable<Jobs> jobs { get; }
        Jobs Save(Jobs jobs);
        void Delete(Jobs jobs);
        void Dispose();
    }
}