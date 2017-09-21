using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpdateProfile.Models
{
    public class UserProfileUpdateResponse
    {

        public string id { get; set; }
        public string userName { get; set; }
        public string profileId { get; set; }
        public string status { get; set; }
        public bool isEmailVerified { get; set; }
        public string token { get; set; }
        public bool isPhoneVerified { get; set; }
        public bool isCallVerified { get; set; }
        public string source { get; set; }
        public string displayName { get; set; }
        public int userType { get; set; }
        public bool buyCompanyPolls { get; set; }
        public bool buyTurkPolls { get; set; }
        public bool isRequiedApproval { get; set; }
        public string org { get; set; }
        public string emailInvites { get; set; }
        public Newprofilecontact newProfileContact { get; set; }
        public Newdevice newDevice { get; set; }
        public string emailAddress { get; set; }
        public string userId { get; set; }
        public bool isActive { get; set; }
        public string userRole { get; set; }
        public bool isCanRunFreePoll { get; set; }
        public bool isBuyCredits { get; set; }
        public bool isPartner { get; set; }
        public int departmentId { get; set; }
        public DateTime lastLogin { get; set; }
        public DateTime createDate { get; set; }
        public int accessLevel { get; set; }

    }
}