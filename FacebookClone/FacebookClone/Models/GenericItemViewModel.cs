using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class GenericItemViewModel
    {
        public string id { get; set; }
        public string previewString { get; set; }
        public string myController { get; set; }
        public string imagePath { get; set; }
        public string content { get; set; }
        public string clickOption { get; set; }
    }
}