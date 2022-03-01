using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NOTIFM.Features.LoginPage
{
    public class LoginModel
    {
        [Required, MaxLength(20), EmailAddress]
        public string Email { get; set; }
    }
}
