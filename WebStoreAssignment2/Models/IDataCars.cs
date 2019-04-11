using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class IDataCars : IMockCars
    {
        private AdsContext db = new AdsContext();

        public IQueryable<Car> cars { get { return db.Cars; } }

        public void Delete(Car cars)
        {
            db.Cars.Remove(cars);
            db.SaveChanges();
        }

        public Car Save(Car cars)
        {
            if (cars.Carid == 0)
            {
                db.Cars.Add(cars);
            }
            else
            {
                db.Entry(cars).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return cars;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}