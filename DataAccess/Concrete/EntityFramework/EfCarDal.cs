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
        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto)
        {
            using (CarContext context = new CarContext())
            {
                var filterExpression = GetFilterExpression(filterDto);
                var result = from car in filterExpression == null ? context.Cars : context.Cars.Where(filterExpression)
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 CarName = car.CarName,
                                 Description = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Status = !(context.Rentals.Any(r => r.CarId == car.CarId && (r.ReturnDate == null || r.ReturnDate>DateTime.Now))),
                                 ImagePath = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).FirstOrDefault(),
                                 MinFindex=car.MinFindex
                             };
                return result.ToList(); //tolist yapmadan query'e dönüştürüp verileri çekmez.

            }
        }
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath= (from carImage in context.CarImages where carImage.CarId == c.CarId select carImage.ImagePath).FirstOrDefault(),
                                 MinFindex = c.MinFindex

                             };
                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetail(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars.Where(p => p.CarId == carId)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 BrandName = d.BrandName,
                                 CarName = p.CarName,
                                 ColorName = c.ColorName,
                                 ModelYear = p.ModelYear,
                                 Description = p.Description,
                                 DailyPrice = p.DailyPrice,
                                 Status = !(context.Rentals.Any(r => r.CarId == p.CarId && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))),
                                 ImagePath = (from carImage in context.CarImages where carImage.CarId == p.CarId select carImage.ImagePath).FirstOrDefault(),
                                 MinFindex = p.MinFindex
                             };
                return result.FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarByBrandId(int brandId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars.Where(p => p.BrandId == brandId)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             join i in context.CarImages
                             on p.CarId equals i.CarId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 BrandName = d.BrandName,
                                 CarName = p.CarName,
                                 ColorName = c.ColorName,
                                 ModelYear = p.ModelYear,
                                 Description = p.Description,
                                 DailyPrice = p.DailyPrice,
                                 ImagePath = (from carImage in context.CarImages where carImage.CarId == p.CarId select carImage.ImagePath).FirstOrDefault(),
                                 MinFindex = p.MinFindex

                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarByColorId(int colorId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars.Where(p => p.ColorId == colorId)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             join i in context.CarImages
                             on p.CarId equals i.CarId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 BrandName = d.BrandName,
                                 CarName = p.CarName,
                                 ColorName = c.ColorName,
                                 ModelYear = p.ModelYear,
                                 Description = p.Description,
                                 DailyPrice = p.DailyPrice,
                                 ImagePath = (from carImage in context.CarImages where carImage.CarId == p.CarId select carImage.ImagePath).FirstOrDefault(),
                              MinFindex = p.MinFindex
                             };
                return result.ToList();
            }
        }
    }
}

