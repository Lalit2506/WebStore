using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class IDataCar : IMockCar
    {

            private AdsContext db = new AdsContext();
            public IQueryable<Car> cars { get { return db.Cars; } }

            public void Delete(Car car)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }

            public Car Save(Car car)
            {
                if (car.Carid == 0)
                {
                    db.Cars.Add(car);
                }
                else
                {
                    db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                return car;
            }

            public void Dispose()
            {
                db.Dispose();
            }
        }
}