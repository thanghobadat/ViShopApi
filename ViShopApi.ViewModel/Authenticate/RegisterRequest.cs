using System;
using System.ComponentModel.DataAnnotations;

namespace ViShopApi.ViewModel.Authenticate
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
