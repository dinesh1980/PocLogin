using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.Models.UploadFile
{

    public class FileObject
    {
        public string id { get; set; }
        public int fileID { get; set; }
        public string contentType { get; set; }
        public string url { get; set; }
        public string fileName { get; set; }
        public bool deleted { get; set; }
        public DateTime lastUpdate { get; set; }
    }

}