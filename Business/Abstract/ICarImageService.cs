using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage, IFormFile formFile);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage, IFormFile formFile);
        IDataResult<List<CarImage>> GetImageByCarId(int carId);
        IDataResult<CarImage> GetById(int carId);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);

    }
}
