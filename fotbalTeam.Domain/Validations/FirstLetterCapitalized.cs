using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace fotbalTeam.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FirstLetterCapitalizedCzAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.MemberName == "MemberField")
            {
                return ValidationResult.Success;
            }

            if (value == null || string.IsNullOrEmpty(value as string))
            {
                return ValidationResult.Success;
            }

            if (value is string text)
            {
                if (char.IsUpper(text[0]) || CharUnicodeInfo.GetUnicodeCategory(text[0]) == UnicodeCategory.UppercaseLetter)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"The {validationContext.DisplayName} field must start with an uppercase letter.");
            }

            return new ValidationResult($"The {validationContext.DisplayName} field must be a string.");
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }
            context.Attributes.Add("data-val-firstlettercapcz", $"The {context.ModelMetadata.DisplayName ?? context.ModelMetadata.Name} field must start with an uppercase letter.");
        }
    }
}