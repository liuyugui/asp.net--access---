using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cms.Areas.Admin.Models
{
    public class NavModel
    {
        public int nID { set; get; }
        public String title { set; get; }
        public String url { set; get; }
        public int order { set; get; }
    }
}