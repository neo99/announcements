using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using AnnouncementApp.Models;

namespace AnnouncementApp.Models.Attributes
{
    public class StartEndDateAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _msg;

        public StartEndDateAttribute(string msg)
        {
          _msg = msg;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Announcement a = (Announcement)validationContext.ObjectInstance;

            if (a.EndDate <= a.StartDate)
            {
                return new ValidationResult(_msg);
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-startenddate", _msg);

            MergeAttribute(context.Attributes, "data-val-startenddate-msg", _msg);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }
    }
}
