using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountVerification.Models
{
    public class GeyMyPollRequest
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string pagingOrder { get; set; }
        public string searchParameter { get; set; }
        public string searchType { get; set; }
        public bool viewAll { get; set; }
        public int pollId { get; set; }
    }

}
