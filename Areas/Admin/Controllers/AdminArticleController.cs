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
    public class AdminArticleController : Controller
    {
        //
        // GET: /Admin/AdminArticle/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            String sql = @"SELECT * FROM  Article";

            List<ArticleModel> list = new List<ArticleModel>();

            AccessSqlHelper accHpler = new AccessSqlHelper();

            OleDbDataReader reader = accHpler.ExecuteReader(sql, null);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ArticleModel artModel = new ArticleModel();

                    artModel.arID = reader.GetInt32(0);

                    object titel = reader.IsDBNull(1) ? null: reader.GetString(1);
                    artModel.title = titel == null ? string.Empty : Convert.ToString(titel);

                    object content = reader.IsDBNull(2) ? null : reader.GetString(2);
                    artModel.contnet = content == null ? string.Empty : Convert.ToString(content);

                    list.Add(artModel);
                }
            
            }


           ViewBag.list = list;


            return View();
        }


        public ActionResult Add(String title,String content)
        {
            
            String sql = @"INSERT INTO  Article (title,content) VALUES (@title,@content)";

            OleDbParameter[] pms = new OleDbParameter[]{

                new OleDbParameter("@title",title),
                new OleDbParameter("@content",content)

            };

            AccessSqlHelper accHpler = new AccessSqlHelper();


            accHpler.ExecuteReader(sql, pms);

            return View();
        }






    }
}
