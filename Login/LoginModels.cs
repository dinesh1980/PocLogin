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

   

 
   
}
