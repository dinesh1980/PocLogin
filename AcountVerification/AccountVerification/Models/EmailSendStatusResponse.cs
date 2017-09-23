using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.Models
{
    public class EmailSendStatusResponse
    {
        public string status { get; set; }
        public string statusMessage { get; set; }
        public ErrorDetails Error { get; set; }

    }
}