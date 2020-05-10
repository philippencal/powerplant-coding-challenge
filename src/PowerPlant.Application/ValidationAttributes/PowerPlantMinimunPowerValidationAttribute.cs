using PowerPlant.Application.DTO;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PowerPlant.Application.ValidationAttributes
{
    public class PowerPlantMinimunPowerValidationAttribute : ValidationAttribute
    {       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var powerplantDTO = (PowerPlantDTO)validationContext.ObjectInstance;

            if (powerplantDTO.Pmax > powerplantDTO.Pmin)
            {
                return ValidationResult.Success;
            }

            var msg = $"The minimun power(pmin) can not be higher than maximun power(pmax).";
            return new ValidationResult(msg);
        }
    }
}
