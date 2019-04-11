using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public interface IMockCar
    {
        IQueryable<Car> cars { get; }
        Car Save(Car car);
        void Delete(Car car);
        void Dispose();
    }
}