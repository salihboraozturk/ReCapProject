using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public void Add(Car car)
        {
            if(car.DailyPrice>0 && car.CarName.Length > 2)
            {
                _iCarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Günlük ücret 0'dan büyük olmalıdır veya descript 2 karakterden büyük olmalıdır");
            }
           
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _iCarDal.GetAll(p=>p.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _iCarDal.GetAll(p => p.ColorId == id);
        }
    }
}
