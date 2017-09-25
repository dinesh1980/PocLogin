using AccountVerification.ApiClient;
using CommonModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountVerification.Models
{
    public class AccountVerificationRequestResponseViewModel
    {
        //public VerificationType? verificationType { get; set; }
        //public ReSendVerifyEmailModel ResendVerifyemail { get; set; }
        //public AccountVerificationResponse accountVerificationResponse {get;set;}
    }
    public class ReSendVerifyEmailModel:IVerificationResponse
    {
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email address is not valid.")]
        [Display(Name = "Email Address")]
        [MinLength(4, ErrorMessage = "Email is too short"), MaxLength(50, ErrorMessage = "Email is too long.")]
        public string EmailAddress { get; set; }
        public AccountVerificationResponse response { get; set; }
    }

    public class AccountVerificationResponse: IVerificationResponse
    {
        public string status { get; set; }
        public string statusMessage { get; set; }
        public ErrorDetails Error { get; set; }
    }

    public class SendVerificationCode: IVerificationResponse
    {
        [Required]
        [MinLength(4, ErrorMessage = "User name is too short"), MaxLength(50, ErrorMessage = "User Name is too long.")]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        public AccountVerificationResponse response { get; set; }
    }

    public interface IVerificationResponse
    {

    }

}