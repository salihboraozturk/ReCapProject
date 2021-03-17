using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
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
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result=BusinessRules.Run(CheckIfCarNameExists(car.CarName));
            if (result!=null)
            {
                return result;
            }
            
            _iCarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
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

        public IDataResult<CarDetailImageDto> GetCarDetailImage(int carId)
        {
            var result = _iCarDal.GetCarDetail(carId);
            var imageResult = _carImageService.GetAllByCarId(carId);
            if (result == null || imageResult.Success == false)
            {
                return new ErrorDataResult<CarDetailImageDto>(Messages.BrandAdded);
            }

            var carDetailAndImagesDto = new CarDetailImageDto
            {
                Car = result,
                ImagePath = imageResult.Data
            };

            return new SuccessDataResult<CarDetailImageDto>(carDetailAndImagesDto);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
         return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(), Messages.CarsDisplay);
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

     
    }
}
