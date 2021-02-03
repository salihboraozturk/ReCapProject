using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>() { 
            new Car(){CarId=1,BrandId=1,ColorId=1,DailyPrice=150000,Description="Renault",ModelYear=2018},
            new Car(){CarId=2,BrandId=2,ColorId=2,DailyPrice=138000,Description="Ford Tourneo",ModelYear=2018},
            new Car(){CarId=3,BrandId=3,ColorId=2,DailyPrice=50000,Description="Hyundai H100",ModelYear=2005},
            };
        }

        public void Add(Car car)
        {
            Console.WriteLine(car.CarId+"car listeye eklendi");
        }

        public void Delete(Car car)
        {
            Console.WriteLine(car.CarId + "car listede silindi");
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int carId)
        {
           return _car.Where(c=>c.CarId==carId).ToList();
        }

        public void Update(Car car)
        {
            Console.WriteLine(car.CarId + "car listede güncellendi");
        }
    }
}
