using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NOTIFM.Features.ForgotPasswordPage
{
    public class ForgotPasswordModel
    {

        [Required, MaxLength(50), EmailAddress]
        public string Email { get; set; }
    }
}
