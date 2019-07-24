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
    public class KhachHangController : Controller
    {
        QuanLiThuePhongEntities1 db = new QuanLiThuePhongEntities1();
     
        //
        // GET: /KhachHang/
        public ActionResult KhachHang( int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.KhachHangs.ToList().OrderBy(n=>n.MaKH).ToPagedList(pageNumber,pageSize));
        }
        // Thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult ThemMoi(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
             
            }
            return RedirectToAction("KhachHang");
        }
        //Sửa
        [HttpGet]
        public ActionResult Sua(int MaKH)
        {
            //lấy ra đối tượng khách hàng theo mã
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);
        }
         [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Sua(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("KhachHang");

        }
        //Hiển thị
         public ActionResult Hienthi(int MaKH)
         {
             
                 //lấy ra đối tượng khách hàng theo mã
                 KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
                 if (kh == null)
                 {
                     Response.StatusCode = 404;
                     return null;
                 }

                 return View(kh);
         }
        //Xóa
        [HttpGet]
         public ActionResult Xoa(int MaKH)
         {
             //lấy ra đối tượng khách hàng theo mã
             KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
             if (kh == null)
             {
                 Response.StatusCode = 404;
                 return null;
             }

             return View(kh);

         }
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacnhanXoa(int MaKH)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(m => m.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("KhachHang");
        }
        //Tìm kiếm
        public ActionResult TimKiem(string SearchString)
        {
            var links = from l in db.KhachHangs
                        select l;

            if (!String.IsNullOrEmpty(SearchString))
            {
                links = links.Where(s => s.TenKH.Contains(SearchString));
            }

            return View(links);
        }
        
	}
}