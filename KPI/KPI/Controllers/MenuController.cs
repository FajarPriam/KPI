using KPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPI.Controllers
{
    public class MenuController : Controller
    {
        DB_KPIDataContext db = new DB_KPIDataContext();

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            if (Session["Nrp"] == null)
            {
                var menu = "";

                return PartialView("_PartialMenu1", menu);
            }
            else
            {
                var menu = db.VW_MENU_ROLEs.Where(x => x.ROLE_ID == Convert.ToInt32(Session["IdProfile"].ToString())).OrderBy(x => x.ORDER).ToList();
                //Session["web_url"] = System.Configuration.ConfigurationManager.AppSettings["Web_Url"].ToString();

                return PartialView("_PartialMenu1", menu);
            }
        }
    }
}