using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Business;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _imageDal;
        public CarImageManager(ICarImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            var result = BusinessRules.Run(CheckCarImages(carImage.CarId));

            if (result!=null)
            {
                return result;
            }
            
                carImage.ImagePath = FileHelper.Add(formFile);
                carImage.Date = DateTime.Now;
                _imageDal.Add(carImage);
                return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {

            _imageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int carId)
        {
            return new SuccessDataResult<CarImage>(_imageDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int carId)
        {

            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(c => c.CarId == carId));
        }

        public IResult Update(CarImage carImage,IFormFile formFile)
        {
         
            carImage.Date = DateTime.Now;
            string oldPath = GetById(carImage.Id).Data.ImagePath;
            FileHelper.Update(formFile, oldPath);
            _imageDal.Update(carImage);
            return new SuccessResult();

        }
        private IResult CheckCarImages(int carId)
        {
            var result = _imageDal.GetAll(c => c.Id == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
