using Core.DataAccess;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal:IEntityRepository<Brand>
    {
        List<ListChartModel> GetCarCountGraph();
    }
}
