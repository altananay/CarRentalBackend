using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfTheCarIsAlreadyRentedInTheSelectedDateRange(rental));
            if (result != null)
            {
                return result;
                
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            try
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            catch
            {
                return new ErrorResult(Messages.UnknownError);
            }
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            if (rental.Id == null || rental.Id < 1)
            {
                return new ErrorResult(Messages.UnknownError);
            }
            else
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
        }

        private IResult CheckIfTheCarIsAlreadyRentedInTheSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r =>
                r.CarId == rental.CarId
                && (r.RentDate.Date == rental.RentDate.Date
                || (r.RentDate.Date < rental.RentDate.Date
                && (r.ReturnDate == null || ((DateTime)r.ReturnDate).Date > rental.RentDate.Date))));

            if (result != null)
                return new ErrorResult(Messages.CarCouldNotBeHired);

            return new SuccessResult();
        }
    }
}
