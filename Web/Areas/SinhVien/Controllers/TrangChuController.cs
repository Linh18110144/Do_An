using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Common;

namespace Web.Areas.SinhVien.Controllers
{
    public class TrangChuController : Controller
    {
        private WebMVCEntities db = new WebMVCEntities();

        // GET: SinhVien/TrangChu
        public async Task<ActionResult> Index()
        {
            var session = (Common.UserLogin)Session[Web.Common.CommonConstants.USER_SESSION];
            WebMVCEntities db = new WebMVCEntities();


            var user = from p in db.NguoiDungs
                       where (p.Nhom_ID == session.NhomID)
                       select p;
            //var nguoiDungs = db.NguoiDungs.Include(n => n.ChucVu).Include(n => n.DeTai).Include(n => n.Nhom);
            return View(await user.ToListAsync());
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Login", "Login", new { area = "" });
        }
    }
}
