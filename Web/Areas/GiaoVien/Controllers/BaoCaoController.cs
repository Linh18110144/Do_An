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
using PagedList;


namespace Web.Areas.GiaoVien.Controllers
{
    public class BaoCaoController : Controller
    {
        private WebMVCEntities db = new WebMVCEntities();

        // GET: GiaoVien/BaoCao
        public ActionResult Index(int Page=1, int PageSize=8)
        {
            var baoCaos = db.BaoCaos.Include(b => b.Nhom);
            var baoCaos1 = baoCaos.OrderBy(p => p.Tuan).ToPagedList(Page, PageSize);
            return View(baoCaos1);
        }

        // GET: GiaoVien/BaoCao/Details/5
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
        public async Task<ActionResult> Feedback(int? id)
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

        // POST: GiaoVien/BaoCaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Feedback(BaoCao baoCao)
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



        // GET: GiaoVien/BaoCao/Delete/5
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

        // POST: GiaoVien/BaoCao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BaoCao baoCao = await db.BaoCaos.FindAsync(id);
            db.BaoCaos.Remove(baoCao);
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
