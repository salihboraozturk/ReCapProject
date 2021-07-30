using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllCarDetails();
        List<CarDetailDto> GetCarByBrandId(int brandId);
        List<CarDetailDto> GetCarByColorId(int colorId);
        List<ListChartModel> GetCarCountGraph();
        List<ListChartModel> GetBrandCountGraph();
        List<ListChartModel> GetColorCountGraph();
        CarDetailDto GetCarDetail(int carId);
        List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filter);
    }
}
