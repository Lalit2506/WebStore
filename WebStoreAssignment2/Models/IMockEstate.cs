using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public interface IMockEstate
    {
        IQueryable<Estate> estates { get; }
        Estate Save(Estate estate);
        void Delete(Estate estate);
        void Dispose();
    }
}