using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountVerification.Models
{

    public class CreateTextPollRequest
    {
        [Display(Name ="Is Filter Option")]
        public bool isFilterOption { get; set; } 

        [Display(Name ="Category Id")]
        public int catId { get; set; }

        [Display(Name ="Is Company Poll")]
        public bool isCompanyPoll { get; set; }

        [Display(Name = "Alllowed anonymously")]
        public int alllowedAnonymously { get; set; }

        [Display(Name ="Is Adult")]
        public bool isAdult { get; set; }

        [Display(Name ="Is Published")]
        public bool isPublished { get; set; }

        [Display(Name = "Poll Type Id")]
        public PollType pollTypeId { get; set; }

        [Display(Name = "Poll Id")]
        public int pollId { get; set; }

        [Display(Name ="Poll Status")]
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
        [Range(30, 31536000, ErrorMessage = "Assignment duration must be between 30 and 31536000 seconds")]
        public int assignmentDurationInSeconds { get; set; }
       
        [Display(Name = "keywords")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "keywords must be between 0 and 1000 char")]
        public string keywords { get; set; }

        [Display(Name ="Is comments enabled")]
        public bool isEnabledComments { get; set; }

        [Display(Name ="Expiration Date")]
        public DateTime expirationDate { get; set; }

        public Filternamevalue[] filterNameValue { get; set; }

        [Display(Name ="Filter Main Category")]
        public string filterMainCategory { get; set; }

        [Display(Name = "Partner UserName")]
        public string pUserName { get; set; }

        [Display(Name ="Is Public Enable")]
        public bool isEnablePublic { get; set; }

        [Display(Name ="Category Name")]
        public string catName { get; set; }

        [Display(Name ="UserName")]
        public string userName { get; set; }

        [Display(Name ="Max Assigment")]
        public int maxAssignments { get; set; }
        
        [Display(Name = "Tags")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "keywords must be between 0 and 1000 char")]
        public string tags { get; set; }

        [Required]
        [Display(Name = "LifeTime in seconds")]
        [Range(30, 31536000, ErrorMessage = "LifeTime in seconds must be between 30 and 31536000 seconds")]
        public int lifeTimeInSeconds { get; set; }

        public GeneralApiResponse Response { get; set; }
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