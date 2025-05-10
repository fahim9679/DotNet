using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.Validations
{
    public class UppercaseAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue=value.ToString();
                if (!string.IsNullOrEmpty(stringValue))
                {
                    char firstLetter = stringValue[0];
                    if (char.IsUpper(firstLetter))
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult(ErrorMessage ?? "The first letter must be in uppercase.");
        }
    }
}
