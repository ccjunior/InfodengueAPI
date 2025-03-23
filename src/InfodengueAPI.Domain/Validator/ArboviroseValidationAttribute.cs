using System.ComponentModel.DataAnnotations;

namespace InfodengueAPI.Domain.Validator
{
    public class ArboviroseValidationAttribute : ValidationAttribute
    {
        private static readonly string[] ValoresPermitidos = { "dengue", "chikungunya", "zika" };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string stringValue && ValoresPermitidos.Contains(stringValue.ToLower()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("A arbovirose deve ser 'dengue', 'chikungunya' ou 'zika'.");
        }
    }
}
