using CommonModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class LoginModels
    {
        public string deviceId { get; set; }
        public bool isPartner { get; set; }

        [Required(ErrorMessage = "Please enter Username")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string password { get; set; }
        public Newdevice newDevice { get; set; }        
      
    }
    public class LoginRequestResponseViewModel
    {
        public LoginModels LoginRequest { get; set; }
        public LoginResponse LoginResponse { get; set; }
    }

    [Serializable]
    public class LoginResponse
    {
        public string userId { get; set; }
        public string token { get; set; }
        public string displayName { get; set; }
        public bool isEmailVerified { get; set; }
        public bool isPhoneVerified { get; set; }
        public bool isCallVerified { get; set; }
        public UserType userType { get; set; }
        public string secretAccessKey { get; set; }
        public string userName { get; set; }
        public string deviceId { get; set; }
        public bool isPartner { get; set; }
        public string Error { get; set; }
    }



}
