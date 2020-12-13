using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;
using Web.Models;

namespace Web.Areas.SinhVien.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: SinhVien/TrangChu
        public ActionResult Index()
        {
            var session = (Common.UserLogin)Session[Web.Common.CommonConstants.USER_SESSION];
            WebMVCEntities db = new WebMVCEntities();


                var user = from p in db.NguoiDungs
                           where (p.Nhom_ID == session.NhomID)
                           select p;
                return View(user);
            
        }

        

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Login", "Login", new { area = "" });
        }
    }
}