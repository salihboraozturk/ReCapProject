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
using Business.Constants;
using System.IO;

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
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId),
                CheckIfImageExtensionValid(formFile));

            if (result!=null)
            {
                return new ErrorResult();
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

        public IDataResult<List<CarImage>> GetAllImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        }
        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = @"\Images\NoImage.jpg";
            var result = _imageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            return result;
        }
        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.InvalidImageExtension);
            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            int result = _imageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.imageLimitExceeded);
            return new SuccessResult();

        }
    }
}
