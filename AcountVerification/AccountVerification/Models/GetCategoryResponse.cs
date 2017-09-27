using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.Models
{

    public class GetCategoriesResponse
    {
        public int catId { get; set; }
        public string catName { get; set; }

    }

    public class GetAllFilterbyCategoryResponse
    {
        public string categoryName { get; set; }
        public string filter1 { get; set; }
        public string filter2 { get; set; }
        public string filter3 { get; set; }
        public string filter4 { get; set; }

    }


}