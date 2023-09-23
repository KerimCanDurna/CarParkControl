using CarPark.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.ServiceCopy.Validation
{
    public class SecondClassVehicleDtoValidator : AbstractValidator<SecondClassVehicleDto>

    {
        public SecondClassVehicleDtoValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Color).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.PlateNumber).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.CheckInDate).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            // 1970 den günümüze kadar olan yılları girebilir 
            RuleFor(x => x.ModelYear).InclusiveBetween(1970, DateTime.Now.Year).WithMessage("{PropertyName} must be between 1970- now ");

            RuleFor(x => x.SecondClassVehicle.SpareTire).NotEmpty().WithMessage("{PropertyName} is required").NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.SecondClassVehicle.TrunkCapacity).InclusiveBetween(1,500).WithMessage("{PropertyName} must be between than 0-500 ");

        }
    }
}
