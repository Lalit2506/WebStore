using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreAssignment2.Models
{
    public interface IMockElectronic
    {
        IQueryable<Electronics> electronics { get; }
        Electronics Save(Electronics electronics);
        void Delete(Electronics electronics);
        void Dispose();
    }
}
