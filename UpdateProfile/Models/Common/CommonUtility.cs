using Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpdateProfile.common
{
    public class CommonUtility
    {
        public static string ApirUrl = string.Empty;
        public static string FullImageBaseUrl { get; set; }
        public static string ThumbnailBaseUrl { get; set; }
        public static LoginResponse loginDetails { get; set; }
    }
   
}