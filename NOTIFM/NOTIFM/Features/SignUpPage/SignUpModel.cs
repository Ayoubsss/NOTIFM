using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NOTIFM.Features.SignUpPage
{
    public class SignUpModel
    {
        public string Email { get; set; }

        [Required, MaxLength(8)]
        public string Password { get; set; }

        [Required, MaxLength(8)]
        public string PasswordConfirmation { get; set; }
    }
}
