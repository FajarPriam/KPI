using FormsAuth;
using KPI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPI_API.Views_Models
{
    public class ClsUser
    {
        DB_KPIDataContext db = new DB_KPIDataContext();

        public string user { get; set; }
        public string pass { get; set; }
        public int role { get; set; }

        public int c_login()//(string user, string pass, int role)
        {
            int cek = 0;//false
            
            bool validasi = checkValidUser(user, pass);

            if (validasi)
            {
                var cekUser = db.VW_USER_PROFILEs.Where(a => a.USER == user.Substring(1) && a.ID_ROLE == role).ToList();
                if (cekUser.Count > 0)
                {
                    cek = 1;//true
                }
                else
                {
                    cek = 2;//false user belum terdaftar dengan role tersebut
                }
            }
            else
            {
                cek = 3;//Invalid login
            }

            return cek;
        }

        public VW_USER_PROFILE c_getUser()
        {            
            var data = db.VW_USER_PROFILEs.Where(a => a.USER == user.Substring(1) && a.ID_ROLE == role).FirstOrDefault();
            return data;
        }

        public IEnumerable<VW_USER_PROFILE> c_getAllUsers() 
        {
            var list = db.VW_USER_PROFILEs.ToList();
            return list;
        }

        public IQueryable<TBL_M_ROLE> c_getRole()
        {
            var data = db.TBL_M_ROLEs.ToList().AsQueryable();
            return data;
        }

        public bool checkValidUser(string nrp = "", string pass = "")
        {
            bool iReturn = false;

            try
            {
                var ldap = new LdapAuthentication("LDAP://KPPMINING:389");
                iReturn = ldap.IsAuthenticated("KPPMINING", nrp, pass);
            }
            catch (Exception ex)
            {
                var asd = ex.ToString();
                iReturn = false;
            }

            return iReturn;
        }

        //public bool OpenLdap(string username = "", string password = "")
        //{
        //    bool status = true;
        //    String uid = "cn=" + username + ",ou=Users,dc=kpp,dc=net";

        //    DirectoryEntry root = new DirectoryEntry("LDAP://10.12.101.102", uid, password, AuthenticationTypes.None);

        //    try
        //    {
        //        object connected = root.NativeObject;
        //        status = true;

        //    }
        //    catch (Exception ex)
        //    {
        //        var asd = ex.ToString();
        //        status = false;
        //    }

        //    return status;
        //}
    }
}