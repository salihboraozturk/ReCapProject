using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand,CarContext>, IBrandDal
    {
        public List<ListChartModel> GetCarCountGraph()
        {
            using (CarContext context = new CarContext())
                {
                    var list = (from review in context.Brands
                                group review by review.BrandName into reviewgroups
                                select new ListChartModel
                                {
                                    Name = reviewgroups.Key,
                                    Count = reviewgroups.Count()

                                }).OrderByDescending(x => x.Count);
                return list.ToList();
            }

        }
    }
}
