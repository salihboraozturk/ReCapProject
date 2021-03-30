using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentSucces);
        }

        public IResult CheckPaymentSuccess(Payment payment)
        {
            var result=_paymentDal.GetAll(c =>c.CardNumber==payment.CardNumber && c.ExpirationMonth ==payment.ExpirationMonth && c.ExpirationYear == payment.ExpirationYear && c.Cvv == payment.Cvv).Any();
            if (result)
            {
                return new SuccessResult(Messages.PaymentSucces);
            }
            else
            {
                return new ErrorResult(Messages.PaymentError);

            }

        }
    }
}
