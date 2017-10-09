using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.Models.CreateTextPolls
{
    public class GetMyPoll
    {
        
            public int pageSize { get; set; }
            public int pageNumber { get; set; }
            public string pagingOrder { get; set; }
            public string searchParameter { get; set; }
            public string searchType { get; set; }
            public bool viewAll { get; set; }
            public int pollId { get; set; }
       
    }
    public class MyPolls
    {
        public int pollId { get; set; }
        public int pollTypeId { get; set; }
        public DateTime createDate { get; set; }
        public string pollStatus { get; set; }
        public string pollTitle { get; set; }
        public string question { get; set; }
        public string mainCatName { get; set; }
        public string catName { get; set; }
        public DateTime expirationDate { get; set; }
        public string pollOverview { get; set; }
        public object firstOption { get; set; }
        public object secondOption { get; set; }
        public string firstImagePath { get; set; }
        public string secondImagePath { get; set; }

        public string userName { get; set; }
        public int maxAssignments { get; set; }
        public bool isPublic { get; set; }
        public string filtersJson { get; set; }
        public int responseCompleted { get; set; }
        public string userId { get; set; }
        public string firstImagePathFull { get; set; }
        public string secondImagePathfull { get; set; }
    }
    public class FiltersJson
    {
        public string FilterName { get; set; }
        public string FilterValue { get; set; }
    }
}