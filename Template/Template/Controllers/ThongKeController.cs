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
    public class ThongKeController : Controller
    {
        QuanLiThuePhongEntities1 db = new QuanLiThuePhongEntities1();
        //
        // GET: /ThongKe/
        public ActionResult ThongKe(int? page)
        {

            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.ChiTietDichVus.ToList().OrderBy(n =>n.MaPhong).ToPagedList(pageNumber, pageSize));

        }
        //Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dl và dropdownlist
            ViewBag.MaPhong = new SelectList(db.Phongs.ToList().OrderBy(n => n.TenPhong), "MaPhong", "TenPhong");
            ViewBag.MaDV = new SelectList(db.DichVus.ToList().OrderBy(n => n.TenDV), "MaDV", "TenDV");

            return View();
        }
        public ActionResult ThemMoi(ChiTietDichVu ctdv)
        {
            if (ModelState.IsValid)
            {
                ctdv.ThanhTien = ctdv.SoLuong * ctdv.DonGia;
                ctdv.TongTien = ctdv.GiaPhong + ctdv.ThanhTien;
                db.ChiTietDichVus.Add(ctdv);
                db.SaveChanges();

            }
            return RedirectToAction("ThongKe");
        }
        //Sửa
        [HttpGet]
        public ActionResult Sua(int MaPhong)
        {
            //lấy ra đối tượng khách hàng theo mã
            ChiTietDichVu ctdv = db.ChiTietDichVus.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (ctdv == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(ctdv);
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Sua(ChiTietDichVu ctdv)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                ctdv.ThanhTien = ctdv.SoLuong * ctdv.DonGia;
                ctdv.TongTien = ctdv.GiaPhong + ctdv.ThanhTien;
                db.Entry(ctdv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ThongKe");

        }
        //Hiển thị
        public ActionResult Hienthi(int MaPhong)
        {

            //lấy ra đối tượng khách hàng theo mã
            ChiTietDichVu ctdv = db.ChiTietDichVus.SingleOrDefault(n => n.MaPhong == MaPhong);
            if (ctdv == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(ctdv);
        }
        //Xóa
        [HttpGet]
        public ActionResult Xoa(int MaPhong)
        {
            //lấy ra đối tượng khách hàng theo mã
            ChiTietDichVu ctdv = db.ChiTietDichVus.FirstOrDefault(n => n.MaPhong == MaPhong);
            if (ctdv == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(ctdv);

        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacnhanXoa(int MaPhong)
        {
            ChiTietDichVu ctdv = db.ChiTietDichVus.FirstOrDefault(n => n.MaPhong == MaPhong);
            if (ctdv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChiTietDichVus.Remove(ctdv);
            db.SaveChanges();
            return RedirectToAction("ThongKe");
        }
	}
}