using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;
using PagedList;
using PagedList.Mvc;
namespace Template.Controllers
{

    public class DichVuController : Controller
    {
        QuanLiThuePhongEntities db = new QuanLiThuePhongEntities();
        //
        // GET: /DichVu/
        public ActionResult DichVu(int ? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.DichVus.ToList().OrderBy(n => n.MaDV).ToPagedList(pageNumber, pageSize));
        }
        // Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult ThemMoi(DichVu dv)
        {
            if (ModelState.IsValid)
            {
                db.DichVus.Add(dv);
                db.SaveChanges();

            }
            return RedirectToAction("DichVu");
        }
        //Sửa
        [HttpGet]
        public ActionResult Sua(int MaDV)
        {
            //lấy ra đối tượng khách hàng theo mã
            DichVu dv = db.DichVus.SingleOrDefault(n => n.MaDV == MaDV);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(dv);
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Sua(DichVu dv)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(dv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("DichVu");

        }
        //Hiển thị
        public ActionResult Hienthi(int MaDV)
        {

            //lấy ra đối tượng khách hàng theo mã
           DichVu dv = db.DichVus.SingleOrDefault(n => n.MaDV == MaDV);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(dv);
        }
        //Xóa
        [HttpGet]
        public ActionResult Xoa(int MaDV)
        {
            //lấy ra đối tượng khách hàng theo mã
            DichVu dv = db.DichVus.SingleOrDefault(n => n.MaDV == MaDV);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(dv);

        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(int MaDV)
        {
            DichVu dv = db.DichVus.SingleOrDefault(m => m.MaDV == MaDV);
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DichVus.Remove(dv);
            db.SaveChanges();
            return RedirectToAction("DichVu");
        }
        //Tìm kiếm
        public ActionResult TimKiem(string SearchString)
        {
            var links = from l in db.DichVus
                        select l;

            if (!String.IsNullOrEmpty(SearchString))
            {
                links = links.Where(s => s.TenDV.Contains(SearchString));
            }

            return View(links);
        }
	}
}