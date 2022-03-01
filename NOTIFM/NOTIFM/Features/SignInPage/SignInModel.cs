using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NOTIFM.Features.SignInPage
{
    public class SignInModel
    {
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
