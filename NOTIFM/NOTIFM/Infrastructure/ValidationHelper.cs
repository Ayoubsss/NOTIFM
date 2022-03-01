using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace NOTIFM.Infrastructure
{
    public static class ValidationHelper
    {
        public static bool IsFormValid(object model)
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, errors, true);
           
            return errors.Count() == 0;
        }
    }
}