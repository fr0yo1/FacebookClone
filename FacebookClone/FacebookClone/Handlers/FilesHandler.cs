using System;
using System.IO;
using System.Web;

namespace FacebookClone.Handlers
{
    public class FilesHandler
    {
        public static String aplicationPath = "~/Content";
        public static String relativeFolder = Path.GetFileName("Images");
        public static String saveImage(HttpPostedFileBase picture, HttpServerUtilityBase server)
        {

            string subPath = Path.Combine(server.MapPath(aplicationPath), relativeFolder);
            if (!System.IO.Directory.Exists(subPath))
                System.IO.Directory.CreateDirectory(subPath);

            string fullPath = Path.Combine(subPath, Path.GetFileName(picture.FileName));
            try
            {
                picture.SaveAs(fullPath);
            } catch (Exception ex)
            {
                return null;
            }

            string relativePath = "/Content/" + "Images/" + picture.FileName;
            return relativePath;
        } 
    }
}