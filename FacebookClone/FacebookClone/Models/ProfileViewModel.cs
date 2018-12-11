using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Models
{
    public enum Gender: int
    {
        [Description("Other")]
        Other=0,
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2
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

        
        public void addProfileToUser(String user_id,String profilePath)
        {
            var newProfile = new Profile
            {
                age = this.age,
                firstname = this.firstname,
                lastname = this.lastname,
                Id = user_id,
                gender = this.gender.ToString()
            };
            var databaseEntities = new FacebookDatabaseEntities();
            databaseEntities.Profiles.Add(newProfile);
            var album = databaseEntities.Albums.Add(new Album { user_id = user_id, name = "ProfileAlbum", date = DateTime.Now });
            var picture = databaseEntities.Pictures.Add(new Picture { album_id = album.album_id, path = profilePath, date = DateTime.Now, description = "ProfilePicture" });
            databaseEntities.SaveChanges();
        }

        public void addNewProfileToUser(String user_id, String profilePath)
        {
            var databaseEntities = new FacebookDatabaseEntities();
            var profileAlbum = databaseEntities.Albums.Where(x => x.name.Equals("ProfileAlbum") && x.user_id == user_id).FirstOrDefault();

            Picture profilePicture = new Picture();
            profilePicture.album_id = profileAlbum.album_id;
            profilePicture.path = profilePath;
            profilePicture.date = DateTime.Now;
            profilePicture.description = "ProfilePicture";

            databaseEntities.Pictures.Add(profilePicture);
            databaseEntities.SaveChanges();
        }
    }

}

