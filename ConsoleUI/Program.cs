using Entities.Concrete;
using Business.Concrete;
using System;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        { 


            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarName+"----"+item.BrandName+"----"+item.ColorName+ "----" + item.DailyPrice);
            }
            // CarTest();
        }

        private static void CarTest()
        {
            Car car1 = new Car()
            {
                ColorId = 1,
                BrandId = 1,
                DailyPrice = 1,
                CarName = "A9modeli",
                ModelYear = 2006
            };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarName);
            }
        }
    }
}
