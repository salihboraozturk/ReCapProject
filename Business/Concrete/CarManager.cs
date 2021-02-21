using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        { 
           
            _iCarDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.CarsDisplay);
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
    }
}
