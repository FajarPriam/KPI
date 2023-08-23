using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPI.Controllers
{
    public class MasterController : Controller
    {
        #region Users
        public ActionResult UserIndex()
        {
            try
            {
                ViewBag.path = ConfigurationManager.AppSettings["path"].ToString();
                //var cek = Session["Nrp"].ToString();
                if (!string.IsNullOrEmpty(Session["Nrp"] as string))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }                
            }
            catch (Exception e)
            {
                return RedirectToAction("Login", "Login"); ;
            }
        }
        #endregion
    }
}