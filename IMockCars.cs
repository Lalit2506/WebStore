using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public interface IMockCars
    {
        IQueryable<Car> cars { get; }
        Car Save(Car cars);
        void Delete(Car cars);
        void Dispose();
    }
}