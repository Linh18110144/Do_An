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

namespace Web.Areas.GiaoVien.Controllers
{
    public class TrangChuController : Controller
    {
        private WebMVCEntities db = new WebMVCEntities();

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Login", "Login", new { area = "" });
        }
        public async Task<ActionResult> Index(string searchString)
        {
            var nguoiDungs = db.NguoiDungs.Include(n => n.ChucVu).Include(n => n.DeTai).Include(n => n.Nhom);
            return View(await nguoiDungs.ToListAsync());
        }

        // GET: GiaoVien/TrangChu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: GiaoVien/TrangChu/Create
        public ActionResult Create()
        {
            ViewBag.ChucVu_ID = new SelectList(db.ChucVus, "ID", "TenChucVu");
            ViewBag.DeTai_ID = new SelectList(db.DeTais, "ID", "TenDeTai");
            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom");
            return View();
        }

        // POST: GiaoVien/TrangChu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,TenDangNhap,MatKhau,HoTen,Email,Nhom_ID,DeTai_ID,ChucVu_ID")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoiDung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ChucVu_ID = new SelectList(db.ChucVus, "ID", "TenChucVu", nguoiDung.ChucVu_ID);
            ViewBag.DeTai_ID = new SelectList(db.DeTais, "ID", "TenDeTai", nguoiDung.DeTai_ID);
            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom", nguoiDung.Nhom_ID);
            return View(nguoiDung);
        }

        // GET: GiaoVien/TrangChu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChucVu_ID = new SelectList(db.ChucVus, "ID", "TenChucVu", nguoiDung.ChucVu_ID);
            ViewBag.DeTai_ID = new SelectList(db.DeTais, "ID", "TenDeTai", nguoiDung.DeTai_ID);
            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom", nguoiDung.Nhom_ID);
            return View(nguoiDung);
        }

        // POST: GiaoVien/TrangChu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,TenDangNhap,MatKhau,HoTen,Email,Nhom_ID,DeTai_ID,ChucVu_ID")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ChucVu_ID = new SelectList(db.ChucVus, "ID", "TenChucVu", nguoiDung.ChucVu_ID);
            ViewBag.DeTai_ID = new SelectList(db.DeTais, "ID", "TenDeTai", nguoiDung.DeTai_ID);
            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom", nguoiDung.Nhom_ID);
            return View(nguoiDung);
        }

        // GET: GiaoVien/TrangChu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: GiaoVien/TrangChu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = await db.NguoiDungs.FindAsync(id);
            db.NguoiDungs.Remove(nguoiDung);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
