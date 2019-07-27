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
    public class PhongTroController : Controller
    {
        //
        // GET: /PhongTro/
        QuanLiThuePhongEntities1 db = new QuanLiThuePhongEntities1();

        //
        // GET: /KhachHang/
        public ActionResult PhongTro(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.Phongs.ToList().OrderBy(n => n.MaPhong).ToPagedList(pageNumber, pageSize));
        }
        // Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult ThemMoi(Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Phongs.Add(phong);
                db.SaveChanges();

            }
            return RedirectToAction("PhongTro");
        }
        //Sửa
        [HttpGet]
        public ActionResult Sua(int MaPhong)
        {
            //lấy ra đối tượng khách hàng theo mã
            Phong phong = db.Phongs.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (phong == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(phong);
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Sua(Phong phong)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(phong).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("PhongTro");

        }
        //Hiển thị
        public ActionResult Hienthi(int MaPhong)
        {

            //lấy ra đối tượng khách hàng theo mã
            Phong phong = db.Phongs.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (phong == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(phong);
        }
        //Xóa
        [HttpGet]
        public ActionResult Xoa(int MaPhong)
        {
            //lấy ra đối tượng khách hàng theo mã
            Phong phong = db.Phongs.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (phong == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(phong);

        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(int MaPhong)
        {
            Phong phong = db.Phongs.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (phong == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Phongs.Remove(phong);
            db.SaveChanges();
            return RedirectToAction("PhongTro");
        }
        //Tìm kiếm
        public ActionResult TimKiem(string SearchString)
        {
            var links = from l in db.Phongs
                        select l;

            if (!String.IsNullOrEmpty(SearchString))
            {
                links = links.Where(s => s.TenPhong.Contains(SearchString));
            }

            return View(links);
        }
	}
}