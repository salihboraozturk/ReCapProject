using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _iUserDal;
        public UserManager(IUserDal iUserDal)
        {
            _iUserDal = iUserDal;
        }

        public IResult Add(User user)
        {
            _iUserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _iUserDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll(),Messages.UsersDisplay);
        }

        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_iUserDal.Get(u=>u.UserId==userId),Messages.UsersDisplay);
        }

        public IResult Update(User user)
        {
            _iUserDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
