using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVT.App_Infrastructure// Marco Villegas
{
    public static class ValidationExtensions// Valideringsklass
    {
        public static bool Validate<T>(this T instance, out ICollection<ValidationResult> validationResults)// Utökning av klassen objekt för direktvalidering
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }
    }
}