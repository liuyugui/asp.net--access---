using cms.Areas.Admin.Models;
using connectAccess;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms.Areas.Admin.Controllers
{
    public class AdminNavController : Controller
    {
        //
        // GET: /Admin/AdminNav/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {

            String sql = @"SELECT * FROM  Nav";

            List<NavModel> list = new List<NavModel>();

            AccessSqlHelper accHpler = new AccessSqlHelper();

            OleDbDataReader reader = accHpler.ExecuteReader(sql, null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NavModel navModel = new NavModel();

                    navModel.nID = reader.GetInt32(0);

                    object titel = reader.IsDBNull(1) ? null : reader.GetString(1);
                    navModel.title = titel == null ? string.Empty : Convert.ToString(titel);

                    object url = reader.IsDBNull(2) ? null : reader.GetString(2);
                    navModel.url = url == null ? string.Empty : Convert.ToString(url);

                    navModel.order = reader.GetInt32(3);

                    list.Add(navModel);
                }

            }


            ViewBag.list = list;

            return View();
        }

        public ActionResult add()
        {
            return View();
        }
        public ActionResult updata(int order,int nID) 
        {


            String sql = @"UPDATE Nav SET [order]=@order WHERE nID = @nID";

            AccessSqlHelper accHelper = new AccessSqlHelper();

            OleDbParameter[] pms = new OleDbParameter[]{

                new OleDbParameter("@order",order),
                new OleDbParameter("@nID",nID)

            };

            int r = accHelper.ExecuteNonQuery(sql,pms);

            ViewBag.isSuess = r;

            return View();
        }


    }
}
