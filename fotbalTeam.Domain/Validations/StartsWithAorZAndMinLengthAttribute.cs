using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;

namespace fotbalTeam.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class StartsWithAorZAndMinLengthAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _minLength;

        public StartsWithAorZAndMinLengthAttribute(int minLength)
        {
            _minLength = minLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.MemberName == "MemberField")
            {
                return ValidationResult.Success;
            }

            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is string text)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return ValidationResult.Success;
                }

                if (text.Length < _minLength)
                {
                    return new ValidationResult($"The {validationContext.DisplayName} field must be at least {_minLength} characters long.");
                }

                if (char.IsLetter(text[0]) && text[0] >= 'A' && text[0] <= 'Z')
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"The {validationContext.DisplayName} field must start with a letter from 'A' to 'Z'.");
            }

            return new ValidationResult($"The {validationContext.DisplayName} field has an unsupported data type.");
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
            {
                context.Attributes.Add("data-val", "true");
            }

            context.Attributes.Add("data-val-startswithaorzandminlength",
                $"The {context.ModelMetadata.Name} field must start with a letter from 'A' to 'Z' and be at least {_minLength} characters long.");

            context.Attributes.Add("data-val-startswithaorzandminlength-minlength",
                _minLength.ToString());
        }
    }
}