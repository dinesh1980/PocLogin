using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.Models
{
    [Serializable]
    public class RegistrationResponseModel
    {

        public string message { get; set; }
        public bool isEmailVerified { get; set; }
        public bool isPhoneVerified { get; set; }
        public bool isCallVerified { get; set; }
        public string userId { get; set; }
        public string token { get; set; }
        public string displayName { get; set; }
        public int accessLevel { get; set; }


    }
}