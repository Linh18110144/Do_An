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
using System.Web.UI.WebControls;
using System.IO;
using Web.Common;
using PagedList;

namespace Web.Areas.SinhVien.Controllers
{
    public class BaoCaoController : Controller
    {
        private WebMVCEntities db = new WebMVCEntities();

        // GET: SinhVien/BaoCao
        public async Task<ActionResult> Index(int Page=1, int PageSize=8)
        {
            var session = (Common.UserLogin)Session[Web.Common.CommonConstants.USER_SESSION];
            //var baoCaos = db.BaoCaos.Include(b => b.Nhom);
            var baoCaos = from p in db.BaoCaos.Include(b => b.Nhom)
                          where (p.Nhom_ID == session.NhomID)
                          select p;
            var baoCaos1 = baoCaos.OrderBy(p => p.Tuan).ToPagedList(Page,PageSize);
            return View(baoCaos1);
        }

        // GET: SinhVien/BaoCao/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCao baoCao = await db.BaoCaos.FindAsync(id);
            if (baoCao == null)
            {
                return HttpNotFound();
            }
            return View(baoCao);
        }

        // GET: SinhVien/BaoCao/Create
        public ActionResult Create()
        {
            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom");
            return View();
        }

        // POST: SinhVien/BaoCao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Tuan,Nhom_ID,TieuDe,NoiDung,ThoiGianBaoCao,FileUpload,FilePath,PhanHoi")] BaoCao baoCao, HttpPostedFileBase FileUpload)
        {
            var session = (Common.UserLogin)Session[Web.Common.CommonConstants.USER_SESSION];
            baoCao.Nhom_ID = session.NhomID;
            
            if (ModelState.IsValid)
            {
                if (FileUpload != null)
                {

                    string pic = Path.GetFileName(DateTime.Now.ToString("yyyy_MM_dd-") + FileUpload.FileName);
                    string path = Path.Combine(Server.MapPath("~/UploadFiles/") + pic);
                    FileUpload.SaveAs(path);

                    baoCao.FileUpload = pic;
                    baoCao.FilePath = "UploadFiles/" + pic;
                }
                try
                {
                    db.BaoCaos.Add(baoCao);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ViewBag.BaoCao = "Mỗi nhóm mỗi tuần chỉ báo cáo 1 lần";
                }

            }

            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom", baoCao.Nhom_ID);
            return View(baoCao);
        }

        // GET: SinhVien/BaoCao/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCao baoCao = await db.BaoCaos.FindAsync(id);
            if (baoCao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom", baoCao.Nhom_ID);
            return View(baoCao);
        }

        // POST: SinhVien/BaoCao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Tuan,Nhom_ID,TieuDe,NoiDung,ThoiGianBaoCao,FileUpload,FilePath,PhanHoi")] BaoCao baoCao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baoCao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Nhom_ID = new SelectList(db.Nhoms, "ID", "TenNhom", baoCao.Nhom_ID);
            return View(baoCao);
        }

        // GET: SinhVien/BaoCao/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaoCao baoCao = await db.BaoCaos.FindAsync(id);
            if (baoCao == null)
            {
                return HttpNotFound();
            }
            return View(baoCao);
        }

        // POST: SinhVien/BaoCao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BaoCao baoCao = await db.BaoCaos.FindAsync(id);
            db.BaoCaos.Remove(baoCao);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Feedback(int Page=1, int PageSize=8)
        {
            var session = (Common.UserLogin)Session[Web.Common.CommonConstants.USER_SESSION];
            //var baoCaos = db.BaoCaos.Include(b => b.Nhom);
            var baoCaos = from p in db.BaoCaos.Include(b => b.Nhom)
                          where (p.Nhom_ID == session.NhomID)
                          select p;
            var baoCaos1 = baoCaos.OrderBy(p => p.Tuan).ToPagedList(Page, PageSize);
            return View(baoCaos1);
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
