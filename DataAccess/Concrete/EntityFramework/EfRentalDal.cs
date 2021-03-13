using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
             using (CarContext context = new CarContext())
                {
                    var result = from r in context.Rentals
                                 join c in context.Cars on r.CarId equals c.CarId
                                 join b in context.Brands on c.BrandId equals b.BrandId
                                 join cu in context.Customers on r.CustomerId equals cu.CustomerId
                                 join us in context.Users on cu.UserId equals us.UserId
                                 select new RentalDetailDto {
                                 BrandName=b.BrandName,
                                 FirstName=us.FirstName,
                                 LastName=us.LastName,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                                 };
                    return result.ToList();
                }
        }
    }
}
