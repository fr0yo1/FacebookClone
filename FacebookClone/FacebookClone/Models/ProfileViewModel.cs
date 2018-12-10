using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Models
{
    public enum Gender
    {
        Other,
        Male,
        Female
    }

    public class ProfileViewModel
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string age { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public HttpPostedFileBase picture { get; set; }

        public String profilePictureRelativePath { get; set; }

        public IEnumerable<SelectListItem> getGenderList()
        {
            var selectList = new List<SelectListItem>();
            foreach (var g in Enum.GetValues(typeof(Gender)))
            {
                selectList.Add(new SelectListItem
                {
                    Value = g.ToString(),
                    Text = g.ToString()
                });
            }
            return selectList;
        }
    }
}

