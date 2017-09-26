using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountVerification.Models
{

    public class CreateTextPollRequest
    {
        public bool isFilterOption { get; set; }
        public int catId { get; set; }
        public bool isCompanyPoll { get; set; }
        public int alllowedAnonymously { get; set; }
        public bool isAdult { get; set; }
        public bool isPublished { get; set; }
        public PollType pollTypeId { get; set; }
        public int pollId { get; set; }
        public string pollStatus { get; set; }
        [Required]
        [Display(Name ="Poll Title")]
        [StringLength(128, MinimumLength = 20, ErrorMessage = "Poll Title must be between 20 and 128 char")]
        public string pollTitle { get; set; }
        [Required]
        [Display(Name = "Question")]
        [StringLength(255, MinimumLength = 20, ErrorMessage = "Poll Title must be between 20 and 255 char")]
        public string question { get; set; }
        [Required]
        [Display(Name = "Poll Overview")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Poll Over view must be between 20 and 1000 char")]
        public string pollOverview { get; set; }
        [Required]
        [Display(Name = "Assignment Duration In Seconds")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Poll Over view must be between 20 and 1000 char")]
        public int assignmentDurationInSeconds { get; set; }
        public string keywords { get; set; }
        public bool isEnabledComments { get; set; }
        public DateTime expirationDate { get; set; }
        public Filternamevalue[] filterNameValue { get; set; }
        public string filterMainCategory { get; set; }
        public string pUserName { get; set; }
        public bool isEnablePublic { get; set; }
        public string catName { get; set; }
        public string userName { get; set; }
        public int maxAssignments { get; set; }
        public string tags { get; set; }
        public int lifeTimeInSeconds { get; set; }
    }

    public class Filternamevalue
    {
        public string filterName { get; set; }
        public string filterValue { get; set; }
    }

    public enum PollType
    {
        /// <summary>
        /// single text
        /// </summary>
        singleText = 1,
        /// <summary>
        /// Best text
        /// </summary>
        bestText = 2,
        /// <summary>
        /// single Image
        /// </summary>
        singleImage = 3,
        /// <summary>
        /// Best Image
        /// </summary>
        bestImage = 4
    }
}