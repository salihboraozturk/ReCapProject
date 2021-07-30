using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal iCarDal, ICarImageService carImageService)
        {
            _iCarDal = iCarDal;
            _carImageService = carImageService;
        }
        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<Car> Add(Car car)
        {
            _iCarDal.Add(car);
            return new SuccessDataResult<Car>(car,Messages.CarAdded);
        }
       // [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        //[SecuredOperation("admin,user")]
        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<10)
            {
                throw new Exception("");

            }
            Add(car);
            return null;
        }
       

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.CarsDisplay);
        }

        public IDataResult<List<CarDetailDto>> GetCarByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarByBrandId(brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarByColorId(colorId));
        }

        public IDataResult<CarDetailImageDto> GetCarDetailImage(int carId)
        {
            var result = _iCarDal.GetCarDetail(carId);
            var imageResult = _carImageService.GetAllImageByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarDetailImageDto>(Messages.BrandAdded);
            }

            var carDetailAndImagesDto = new CarDetailImageDto
            {
                //Car = result,
                ImagePath = imageResult.Data
            };

            return new SuccessDataResult<CarDetailImageDto>(carDetailAndImagesDto);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
         return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetAllCarDetails(), Messages.CarsDisplay);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == id), Messages.CarsDisplay);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == id), Messages.CarsDisplay);
        }
        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _iCarDal.GetAll(c=>c.CarName==carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameExists);
            }
            return new SuccessResult();
        }

        public IDataResult<CarDetailDto> GetCarDetails(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_iCarDal.GetCarDetail(carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarsDetails(CarDetailFilterDto filterDto)
        {
            //Expression propertyExp,someValue,containsMethodExp,combinedExp;
            //Expression<Func<Car, bool>> exp = c => true, oldExp;
            //MethodInfo method;
            //var parameterExp = Expression.Parameter(typeof(Car), "type");
            //foreach (PropertyInfo propertyInfo in filterDto.GetType().GetProperties())
            //{
            //    if (propertyInfo.GetValue(filterDto,null) != null)
            //    {
            //        oldExp = exp;
            //        propertyExp = Expression.Property(parameterExp, propertyInfo.Name);
            //        method = typeof(int).GetMethod("Equals", new[] { typeof(int) });
            //        someValue = Expression.Constant(filterDto.GetType().GetProperty(propertyInfo.Name).GetValue(filterDto, null), typeof(int));
            //        containsMethodExp = Expression.Call(propertyExp, method, someValue);
            //        exp = Expression.Lambda<Func<Car, bool>>(containsMethodExp, parameterExp);
            //        combinedExp = Expression.AndAlso(exp.Body,oldExp.Body);
            //        exp = Expression.Lambda<Func<Car, bool>>(combinedExp, exp.Parameters[0]);
            //    }
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetAllCarDetailsByFilter(filterDto));
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c=>c.CarId==id));
        }

        public IDataResult<List<ListChartModel>> GetCarCountGraph()
        {
            return new SuccessDataResult<List<ListChartModel>>(_iCarDal.GetCarCountGraph());
        }

        public IDataResult<List<ListChartModel>> GetBrandCountGraph()
        {
            return new SuccessDataResult<List<ListChartModel>>(_iCarDal.GetBrandCountGraph());
        }
    }

}
