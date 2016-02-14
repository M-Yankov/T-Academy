using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Common;
using Data.Models;
using TwitterSystem.Helper;

namespace TwitterSystem.Models
{
    public class InputTweetModel
    {
        [Required]
        [MinLength(Constants.MinLength)]
        [MaxLength(Constants.MaxLength)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [Tags(Constants.Pattern, ErrorMessage = "Example: #firstTag #2Tag #third3tag" )]
        public string Tags { get; set; }
    }
}