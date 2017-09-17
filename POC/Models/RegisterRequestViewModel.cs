using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace POC.Models
{

    //public class RegisterRequestViewModel
    //{
    //    [Display(Name = "Organization")]
    //    public string org { get; set; }
    //    public int verificationMethod { get; set; }

    //    [Required]
    //    [MinLength(4, ErrorMessage = "User name is too short"), MaxLength(50, ErrorMessage = "User Name is too long.")]
    //    [Display(Name = "User Name")]
    //    public string userName { get; set; }

    //    [Required]
    //    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email address is not valid.")]
    //    [Display(Name = "Email Address")]
    //    [MinLength(4, ErrorMessage = "Email is too short"), MaxLength(50, ErrorMessage = "Email is too long.")]
    //    public string emailAddress { get; set; }

    //    [Display(Name = "Password")]
    //    [Required]
    //    [MinLength(6, ErrorMessage = "Password is too short"), MaxLength(20, ErrorMessage = "Password is too long.")]
    //    public string password { get; set; }

    //    [Display(Name = "User Type")]
    //    public UserType userType { get; set; }
    //    //public string id { get; set; }
    //    public Newdevice newDevice { get; set; }
    //    public Newprofilecontact newProfileContact { get; set; }
   
    //}

    public class Newdevice
    {
        public string deviceVersion { get; set; }
        public string browserName { get; set; }
        public string browserVersion { get; set; }
        public string browserUserAgent { get; set; }
        public string snsType { get; set; }
        public string deviceName { get; set; }
        public string devicePlatform { get; set; }
        public string snsDeviceId { get; set; }
        public string channelId { get; set; }
    }

    //public class Newprofilecontact
    //{
    //    public string id { get; set; }

    //    [Display(Name = "Company Name")]
    //    public string companyName { get; set; }

    //    [Display(Name = "Job Title")]
    //    public string jobTitle { get; set; }

    //    [Display(Name = "Education Level")]
    //    public string educationLevel { get; set; }

    //    [Display(Name = "Relationship Status")]
    //    public string relationshipStatus { get; set; }

    //    [Display(Name = "Marital Status")]
    //    public string maritalStatus { get; set; }
    //    public string pictureId { get; set; }

    //    [Display(Name = "Is Profile Public")]
    //    public bool isPublicProfile { get; set; }

    //    [Display(Name = "Is Phone Public")]
    //    public bool isPhonePublic { get; set; }

    //    [Display(Name = "Is Email Public")]
    //    public bool isEmailPublic { get; set; }
    //    public int viewCounter { get; set; }

    //    public PhoneType phoneType { get; set; }

    //    [Display(Name = "User Id")]
    //    public string userId { get; set; }

    //    [Required]
    //    [Display(Name = "Country Code")]
    //    public int countryCode { get; set; }

    //    [Required]
    //    [Display(Name = "Phone Number")]
    //    [MinLength(5, ErrorMessage = "Phone min length is 5."), MaxLength(15, ErrorMessage = "Phone number max length exceeds.")]
    //    public string phoneNumber { get; set; }

    //    [Required]
    //    [Display(Name = "Gender")]
    //    [StringLength(6, ErrorMessage = "Gender is not valid")]
    //    public string gender { get; set; }

    //    [DataType(DataType.DateTime)]
    //    public string birthDate { get; set; }

    //    [Display(Name = "Address Line1")]
    //    [StringLength(50)]
    //    [Required]
    //    public string addressLine1 { get; set; }

    //    [Display(Name = "Address Line2")]
    //    [StringLength(50)]
    //    public string addressLine2 { get; set; }

    //    [Display(Name = "City")]
    //    [StringLength(50)]
    //    [Required]
    //    public string addressCity { get; set; }

    //    [Display(Name = "Country")]
    //    [StringLength(50)]
    //    [Required]
    //    public string addressCountry { get; set; }

    //    [Display(Name = "State")]
    //    [StringLength(50)]
    //    [Required]
    //    public string addressState { get; set; }

    //    [Display(Name = "Zip")]
    //    [StringLength(15)]
    //    [Required]
    //    public string addressZip { get; set; }

    //    public string ownerId { get; set; }

    //    [Display(Name = "Picture Url")]
    //    public string pictureUrl { get; set; }

    //    [Display(Name = "Profile Picture")]
    //    public Profilepictures profilePictures { get; set; }

    //    [Display(Name = "Is Email Verified")]
    //    public bool isEmailVerified { get; set; }

    //    [Display(Name = "Is Phone Verified")]
    //    public bool isPhoneVerified { get; set; }

    //    [Display(Name = "Public Polls")]
    //    public int publicPolls { get; set; }

    //    [Display(Name = "Business Polls")]
    //    public int businessPolls { get; set; }

    //    [Display(Name = "Private Polls")]
    //    public int privatePolls { get; set; }

    //    [Display(Name = "Total Polls")]
    //    public int totalPolls { get; set; }

    //    public string[] deletedPictures { get; set; }

    //    [Display(Name = "Last Login")]
    //    public DateTime lastLogin { get; set; }

    //    [Display(Name = "Member Since")]
    //    public DateTime memberSince { get; set; }

    //    [Required]
    //    [StringLength(20), MinLength(2)]
    //    [Display(Name = "First Name")]
    //    public string firstName { get; set; }

    //    [Required]
    //    [StringLength(20), MinLength(2)]
    //    [Display(Name = "Last Name")]
    //    public string lastName { get; set; }

    //    [Required]
    //    [StringLength(50), MinLength(8)]
    //    [Display(Name = "Pay Pal Email")]
    //    public string payPalEmail { get; set; }

    //    public DateTime phoneVerifiedDateTime { get; set; }

    //    public string phoneVerificationMethod { get; set; }

    //    public DateTime emailVerifiedDateTime { get; set; }
    //}

    //public class Profilepictures
    //{
    //    public string _4d180a2814b6470e897c4649296cf910 { get; set; }
    //    public string _6fd01f627bf44d0dbaa931af818cf42e { get; set; }
    //}

    public enum UserType
    {
        Normal = 0,
        Admin = 1,
        Business = 2,
        Member = 3,
        Partner = 4,
        Celebrity = 5,
        Worker = 6
    }
    public enum PhoneType
    {
        mobile = 0,
        landline = 1,
        voip = 2
    }
}
