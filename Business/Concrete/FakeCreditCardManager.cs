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
    public class FakeCreditCardManager : IFakeCreditCardService
    {
        IFakeCreditCardDal _fakeCreditCardDal;

        public FakeCreditCardManager(IFakeCreditCardDal fakeCreditCardDal)
        {
            _fakeCreditCardDal = fakeCreditCardDal;
        }

        public IResult GetAll(FakeCreditCard fakeCreditCard)
        {
            //return new SuccessDataResult<List<FakeCreditCard>>(_fakeCreditCardDal.GetAll(fcc => fcc.Number == fakeCreditCard.Number && fcc.Cvv == fakeCreditCard.Cvv && fakeCreditCard.ExpirationDate == fakeCreditCard.ExpirationDate));
            var result = BusinessRules.Run(CheckIfPaymentInformationsCorrect(fakeCreditCard));
            if (result != null)
            {
                return result;
            }
            return new SuccessResult(Messages.PaymentTransactionSuccessfull);
        }

        private IResult CheckIfPaymentInformationsCorrect(FakeCreditCard fakeCreditCard)
        {
            var result = _fakeCreditCardDal.GetAll(fcc => fcc.Number == fakeCreditCard.Number && (fcc.Cvv == fakeCreditCard.Cvv) && (fakeCreditCard.ExpirationDate == fakeCreditCard.ExpirationDate));

            if (result.Count == 0)
            {
                return new ErrorResult(Messages.PaymentDenied);
            }

            return new SuccessResult(Messages.PaymentTransactionSuccessfull);
        }
    }
}