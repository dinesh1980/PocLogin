using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.Models
{
      public class GetPublicProfileRequest
    {
        public string id { get; set; }
        public bool viewAll { get; set; }
    }
}