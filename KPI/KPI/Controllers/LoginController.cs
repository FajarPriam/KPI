using KPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            ViewBag.path = ConfigurationManager.AppSettings["path"].ToString();

            return View();
        }

        public JsonResult setSession(ClsUser param)
        {
            Session["Nrp"] = param.NRP;
            Session["Nama"] = param.NAME;
            Session["IdProfile"] = param.ID_ROLE;
            Session["Profile"] = param.ROLE;
            Session["District"] = param.DISTRICT;
            Session["PosId"] = param.POSITION_ID;
            Session["PosTitle"] = param.POS_TITLE;

            return Json(JsonRequestBehavior.AllowGet);
        }

    }
}