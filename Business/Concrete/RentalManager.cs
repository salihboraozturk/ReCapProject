using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _iRentalDal;
        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;
        }
        
        public IResult Add(Rental rental)
        {
            var result = _iRentalDal.Get(r=>r.RentalId==rental.RentalId && r.ReturnDate==null);
            if (result.ReturnDate==null)
            {
                return new ErrorResult(Messages.RentalCouldNotAdded);
            }
            _iRentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _iRentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalCouldNotAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(),Messages.RentalsDisplay);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_iRentalDal.GetRentalDetails(),Messages.RentalsDisplay);
        }

        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_iRentalDal.Get(r => r.RentalId == rentalId),Messages.RentalsDisplay);
        }

        public IResult Update(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
