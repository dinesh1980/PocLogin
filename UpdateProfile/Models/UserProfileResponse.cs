using CommonModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UpdateProfile.Models
{
    public class UserProfileResponse
    {
        public string id { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string companyName { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string jobTitle { get; set; }
        [Display(Name = "Education Level")]
        public string educationLevel { get; set; }
        public string pictureId { get; set; }
        public bool isPublicProfile { get; set; }
        public bool isPhonePublic { get; set; }
        public int viewCounter { get; set; }
        [Display(Name = "Phone Type")]
        public PhoneType phoneType { get; set; }
        public string userId { get; set; }
        [Required]
        [Display(Name = "Country Code")]
        public int countryCode { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [MinLength(5, ErrorMessage = "Phone number is too short"), MaxLength(15, ErrorMessage = "Phone number is too long.")]
        public string phoneNumber { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Date of Birth")]
        [Required]
        public string birthDate { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Address line 1 max length is 50")]
        [Display(Name = "Address Line 1")]
        public string addressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string addressLine2 { get; set; }

        [Display(Name = "City")]
        public string addressCity { get; set; }
        [Display(Name = "Country")]
        public string addressCountry { get; set; }
        [Display(Name = "State")]
        public string addressState { get; set; }

        [Display(Name = "Zip Code")]
        public string addressZip { get; set; }
        [Display(Name = "Picture Url")]
        public string pictureUrl { get; set; }
        public IDictionary<string, string> profilePictures { get; set; }
        public bool isEmailVerified { get; set; }
        public bool isPhoneVerified { get; set; }
        public int publicPolls { get; set; }
        public int businessPolls { get; set; }
        public int privatePolls { get; set; }
        public int totalPolls { get; set; }
        public object deletedPictures { get; set; }
        [Display(Name = "Last Login")]
        public DateTime lastLogin { get; set; }
        [Display(Name = "Member Since")]
        public DateTime memberSince { get; set; }
        [Required]
        [StringLength(20), MinLength(2)]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [StringLength(20), MinLength(2)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email address is not valid.")]
        [Display(Name = "Paypal Email")]
        [MinLength(4, ErrorMessage = "Email is too short"), MaxLength(50, ErrorMessage = "Email is too long.")]
        public string payPalEmail { get; set; }
        [Display(Name = "Is Profile Email")]
        public Boolean isEmailPublic { get; set; } = false;

        [Display(Name = "Relationship Status")]
        public string relationshipStatus { get; set; }

        [Display(Name = "Marital Status")]
        public string maritalStatus { get; set; }
        
    }
}