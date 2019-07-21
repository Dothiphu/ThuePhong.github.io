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
    public class DangKyPhongController : Controller
    {
        QuanLiThuePhongEntities db = new QuanLiThuePhongEntities();
        //
        // GET: /DangKyPhong/
        public ActionResult DangKyPhong(int ? page)
        {
            
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                return View(db.DangKyPhongs.ToList().OrderBy(n => n.Duyet).ToPagedList(pageNumber, pageSize));
            
        }
        //Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dl và dropdownlist
            ViewBag.MaPhong = new SelectList(db.Phongs.ToList().OrderBy(n => n.TenPhong), "MaPhong", "TenPhong");
            ViewBag.MaKH = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.TenKH), "MaKH", "TenKH");
            
            return View();
        }
        public ActionResult ThemMoi(DangKyPhong dky)
        {
            if (ModelState.IsValid)
            {
                db.DangKyPhongs.Add(dky);
                db.SaveChanges();

            }
            return RedirectToAction("DangKyPhong");
        }
        //Sửa
        [HttpGet]
        public ActionResult Sua(int MaPhong)
        {
            //lấy ra đối tượng khách hàng theo mã
            DangKyPhong dky = db.DangKyPhongs.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (dky == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(dky);
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Sua(DangKyPhong dky)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(dky).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("DangKyPhong");

        }
        //Hiển thị
        public ActionResult Hienthi(int MaPhong)
        {

            //lấy ra đối tượng khách hàng theo mã
          DangKyPhong dky = db.DangKyPhongs.SingleOrDefault(n =>n.MaPhong== MaPhong);
            if (dky == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(dky);
        }
        //Xóa
        [HttpGet]
        public ActionResult Xoa(int MaPhong)
        {
            //lấy ra đối tượng khách hàng theo mã
         DangKyPhong dky= db.DangKyPhongs.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (dky == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(dky);

        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(int MaPhong)
        {
            DangKyPhong dky = db.DangKyPhongs.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (dky == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DangKyPhongs.Remove(dky);
            db.SaveChanges();
            return RedirectToAction("DangKyPhong");
        }
        //Tìm kiếm
        public ActionResult TimKiem(string SearchString)
        {
            var links = from l in db.DangKyPhongs
                        join i in db.Phongs on l.MaPhong equals i.MaPhong
                        select i;

            if (!String.IsNullOrEmpty(SearchString))
            {
                links = links.Where(s => s.TenPhong.Contains(SearchString));
            }

            return View(links);
        }
	}
}