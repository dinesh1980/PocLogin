using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CommonModels;

namespace UserRegistration.Models
{

    public class RegisterRequestViewModel
    {
        [Display(Name = "Organization")]
        public string org { get; set; }
        public int verificationMethod { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "User name is too short"), MaxLength(50, ErrorMessage = "User Name is too long.")]
        [Display(Name = "User Name")]
        public string userName { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email address is not valid.")]
        [Display(Name = "Email Address")]
        [MinLength(4, ErrorMessage = "Email is too short"), MaxLength(50, ErrorMessage = "Email is too long.")]
        public string emailAddress { get; set; }

        [Display(Name = "Password")]
        [Required]
        [MinLength(6, ErrorMessage = "Password is too short"), MaxLength(20, ErrorMessage = "Password is too long.")]
        public string password { get; set; }

        [Display(Name = "User Type")]
        public UserType userType { get; set; }
        //public string id { get; set; }
        public Newdevice newDevice { get; set; }
        public Newprofilecontact newProfileContact { get; set; }
   
    }

   
   

   
}
