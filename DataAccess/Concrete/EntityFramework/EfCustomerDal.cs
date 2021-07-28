using Core.DataAcces.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Customers
                             join b in context.Users on c.UserId equals b.UserId
                             select new CustomerDetailDto
                             {
                              CustomerId=c.CustomerId,
                              CompanyName=c.CompanyName,
                              FirstName=b.FirstName,
                              LastName=b.LastName
                             };
                return result.ToList();
            }
        }
    }
}
