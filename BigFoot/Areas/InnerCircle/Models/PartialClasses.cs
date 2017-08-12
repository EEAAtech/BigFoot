using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigFoot.Areas.InnerCircle.Models
{
    public class PartialClasses
    {
    }

    public class PageImages
    {
        public int PageID { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
                
        [Range(0,100)]
        public int Position { get; set; }
    }
}