using PowerPlant.Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PowerPlant.Application.ValidationAttributes
{
    public class PowerPlantMinimumPowerValidationAttribute : ValidationAttribute
    {       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var powerplantDTO = (PowerPlantDTO)validationContext.ObjectInstance;

            if (powerplantDTO.Pmax > powerplantDTO.Pmin)
            {
                return ValidationResult.Success;
            }

            var msg = $"The minimum power(pmin) can not be higher than maximum power(pmax).";
            return new ValidationResult(msg);
        }
    }
}
