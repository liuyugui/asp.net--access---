using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cms.Areas.Admin.Models
{
    public class ArticleModel
    {
        //文章模型

        public int arID{get;set;}
        public String title { set; get; }
        public String contnet { set; get; }

    }
}