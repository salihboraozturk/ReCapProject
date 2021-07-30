using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<CarDetailDto> GetCarDetails(int carId);
        IDataResult<CarDetailImageDto> GetCarDetailImage(int carId);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarsDetails(CarDetailFilterDto filterDto);
        IDataResult<List<ListChartModel>> GetCarCountGraph();
        IDataResult<List<ListChartModel>> GetBrandCountGraph();
        IDataResult<List<ListChartModel>> GetColorCountGraph();
    }
}
