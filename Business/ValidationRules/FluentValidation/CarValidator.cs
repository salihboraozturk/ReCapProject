using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.CarName).MinimumLength(2);
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(1950);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(1).When(c=>c.BrandId==1);
            RuleFor(c => c.CarName).Must(StartsWithA).WithMessage("Ürünler A harfi ile başlamalı.");

        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
