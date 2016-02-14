using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace TwitterSystem.Helper
{
    public class TagsAttribute : RegularExpressionAttribute
    {
        private string pattern;

        public TagsAttribute(string pattern)
            :base(pattern)
        {
            this.pattern = pattern;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isMatch = Regex.Matches(value.ToString(), this.pattern).Count > 0;
            return isMatch ? ValidationResult.Success : new ValidationResult(string.Empty);
        }
    }
}