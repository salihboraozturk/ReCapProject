using Entities.Concrete;
using Business.Concrete;
using System;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarId);
            }
        }
    }
}
