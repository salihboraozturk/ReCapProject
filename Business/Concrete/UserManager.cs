using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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

        public IResult CheckFindex(int userId)
        {
           var userToCheck = _iUserDal.Get(u=>u.UserId==userId);
            userToCheck.Findex += 50;
            Update(userToCheck);
            return new SuccessResult(Messages.FindexUp);
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

        public User GetByMail(string email)
        {
            return _iUserDal.Get(u=>u.Email==email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _iUserDal.GetClaims(user);
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
        public IResult UserUpdate(User user)
        {
            var userToUpdate = GetUserById(user.UserId).Data;
            
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            Update(userToUpdate);
            return new SuccessResult(Messages.ProfileUpdated);

        }
    }
}
