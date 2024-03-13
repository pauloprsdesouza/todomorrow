using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Todomorrow.Domain.SoftSkills;

namespace Todomorrow.Contracts.Users
{
    public class SignInRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
