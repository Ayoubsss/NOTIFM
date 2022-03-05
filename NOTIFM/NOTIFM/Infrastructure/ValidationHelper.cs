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

        public static bool IsPasswordValid(string password)
        {
            int validConditions = 0;
            foreach (char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever    
                foreach (char c in special)
                {
                    if (password.Contains(c))
                        return false;
                }
            }
            return true;
        }
    }
}