using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel
{
    public class MinimalTopupValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if ((decimal)value < 1000)
                {
                    return new ValidationResult(ErrorMessage = $"Minimal Topup Rp.1000,-");
                }
            }
            return ValidationResult.Success;
        }
    }
}
