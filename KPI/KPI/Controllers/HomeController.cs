using IronXL;
using KPI.Models;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
//using Excel = Microsoft.Office.Interop.Excel;

namespace KPI.Controllers
{
    public class HomeController : Controller
    {  
        public ActionResult Index()
        {
            return View();
        }

        #region Uploads
        public ActionResult Uploads()
        {
            ViewBag.path = ConfigurationManager.AppSettings["path"].ToString();

            return View();
        }

        [HttpPost]
        public JsonResult uploadFile()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;

                    // create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
                    string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                    // save the file
                    file.SaveAs(path);

                    string conString = string.Empty;

                    string extension = Path.GetExtension(file.FileName);

                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties = 'Excel 12.0 Xml;HDR=YES;IMEX=2'; "; //";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                    }

                    DataTable dt = new DataTable();
                    conString = string.Format(conString, path);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);
                                connExcel.Close();
                            }
                        }
                    }

                    DataTable new_dt = new DataTable();
                    var listExcel = dt.Rows;
                    string kpiDept = "";
                    List<ClsKPI> clsKPIs = new List<ClsKPI>();
                    foreach (DataRow row in listExcel)
                    {
                        var arr = row.ItemArray;
                        if (arr[0].ToString() != "")
                        {
                            kpiDept = arr[0].ToString();
                        }
                        //string[] new_row = { kpiDept, arr[1].ToString(), arr[1].ToString(), arr[1].ToString() };                                               
                        clsKPIs.Add(new ClsKPI
                        {
                            KPI_DeptSectHead = kpiDept,
                            KPI_Officer = arr[1].ToString(),
                            KPI_OfficerNonom = arr[2].ToString(),
                            Dept_ID = arr[3].ToString()
                        });
                    }
                                        

                    return Json(new { Status = true, Data = clsKPIs }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("no files were selected !");
                }               
            }
            catch(Exception e)
            {
                return Json(new { Status = false, Remark = e.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpPost]
        //public JsonResult uploadFile()
        //{
        //    // check if the user selected a file to upload
        //    if (Request.Files.Count > 0)
        //    {
        //        try
        //        {
        //            HttpFileCollectionBase files = Request.Files;

        //            HttpPostedFileBase file = files[0];
        //            string fileName = file.FileName;

        //            // create the uploads folder if it doesn't exist
        //            Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
        //            string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

        //            // save the file
        //            file.SaveAs(path);

        //            WorkBook workBook = WorkBook.Load(path);

        //            // Select worksheet at index 0
        //            WorkSheet workSheet = workBook.WorkSheets[0];

        //            // Get any existing worksheet
        //            WorkSheet firstSheet = workBook.DefaultWorkSheet;

        //            //var data = firstSheet.ToDataTable(true).AsDataView();
        //            var ListExcel = firstSheet.AsQueryable().ToList();
        //            var test = ListExcel.ToArray();
        //                //{ "oke", "saya", "just" };

        //            int i = 0;
        //            string[] row1 = new string[ListExcel.Count()];

        //            return Json(new { Status = true, Data = "JUST OKE" }, JsonRequestBehavior.AllowGet);
        //        }

        //        catch (Exception e)
        //        {
        //            return Json(new { Status = false, Remark = e.ToString() }, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    return Json("no files were selected !");
        //}
        #endregion

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}