using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(NguoiDung nguoiDung)
        {

            if (ModelState.IsValid)
            {
                var matkhau = Encryptor.MD5Hash(nguoiDung.MatKhau);
                using (WebMVCEntities db = new WebMVCEntities())
                {
                    var user = db.NguoiDungs.Where(a => a.TenDangNhap.Equals(nguoiDung.TenDangNhap) && a.MatKhau.Equals(matkhau)).FirstOrDefault();
                    if (user != null)
                    {
                        var userSession = new UserLogin();
                        userSession.UserID = user.ID;
                        userSession.UserName = user.TenDangNhap;
                        userSession.HoTen = user.HoTen;

                        if (user.ChucVu_ID == 2)
                        {
                            userSession.NhomID = user.Nhom_ID;
                            Session.Add(CommonConstants.USER_SESSION, userSession);
                            return RedirectToAction("Index", "SinhVien/TrangChu");
                        }
                        else
                        {
                            Session.Add(CommonConstants.USER_SESSION, userSession);
                            return RedirectToAction("Index", "GiaoVien/TrangChu");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không đúng.");
                    }
                }
            }
            return View("Login");
        }
    }
}