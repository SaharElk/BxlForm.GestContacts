using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestMvc.Models.Data;
using TestMvc.Models.Services;

namespace TestMvc.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CategoryIdValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CategoryService categoryservice = (CategoryService)validationContext.GetService(typeof(CategoryService));

            Category category = categoryservice.Get().Where(c => c.Id == (int)value).SingleOrDefault();

            if (category is null)
            {
                return new ValidationResult("Invalid category");
            }

            return ValidationResult.Success;
        }
    }
}
