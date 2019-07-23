using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;


namespace Template.Controllers
{
    public class QuantriController : Controller
    {
        // GET: Quantri
        QuanLiThuePhongEntities db = new QuanLiThuePhongEntities();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(User user)
        {
            if (ModelState.IsValid)
            {
                //var kiemtradangky = new KiemtradangkyController();
                //if (kiemtradangky.CheckUserName(user.Username))
                //{
                //    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                //}
                //chèn dữ liệu
                db.User.Add(user);
                //Lưu vào cơ sở dữ liệu
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection f)
        {
            string sTaikhoan = f["txtTaikhoan"].ToString();
            string sMatkhau = f.Get("txtMatkhau").ToString();
            User user = db.Users.SingleOrDefault(n => n.Username == sTaikhoan && n.Password == sMatkhau);
            if (user != null)
            {
                
                
                Session["Taikhoan"] = user;
                return RedirectToAction("Admin", "LayoutAdmin");              
            }
            ViewBag.ThongBao = "Thất bại";
            return View();
        }
    }
}