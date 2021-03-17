using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join i in context.CarImages on c.CarId equals i.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId 
                             select new CarDetailDto {
                                 CarId=c.CarId,
                                 CarName=c.CarName,
                                 BrandName=b.BrandName,
                                 ColorName=co.ColorName,
                                 ImagePath=i.ImagePath,
                                 Description=c.Description,
                                 ModelYear=c.ModelYear,
                                 DailyPrice=c.DailyPrice 
                             };
                return result.ToList();
            } 
        }
        public CarDetailDto GetCarDetail(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars.Where(p =>p.CarId == carId)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                CarId=p.CarId,
                                BrandName=d.BrandName,
                                CarName=p.CarName,
                                ColorName=c.ColorName,
                                ModelYear=p.ModelYear,
                                Description=p.Description,
                                DailyPrice=p.DailyPrice 

                             };
                return result.SingleOrDefault();
            }
        }

    }
}

