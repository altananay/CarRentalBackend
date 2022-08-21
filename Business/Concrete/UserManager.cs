using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(Userr user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(Userr user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IDataResult<List<Userr>> GetAll()
        {
            return new SuccessDataResult<List<Userr>>(_userDal.GetAll());
        }

        public Userr GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(Userr user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult Update(Userr user)
        {
            if (user.Id == null || user.Id < 1)
            {
                return new ErrorResult(Messages.UnknownError);
            }
            else
            {
                return new SuccessResult(Messages.UserUpdated);
            }
        }
    }
}