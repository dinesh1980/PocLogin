using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels
{

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
    }

}
