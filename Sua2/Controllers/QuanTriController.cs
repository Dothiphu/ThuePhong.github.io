using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
            public class QuanTriController : Controller
            {
                QuanLiThuePhongEntities1 db = new QuanLiThuePhongEntities1();
                //
                // GET: /QuanTri
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
                        ViewBag.Thongbao = "Đăng ký thành công! Xin mời đăng nhập";
                        //var kiemtradangky = new KiemtradangkyController();
                        //if (kiemtradangky.CheckUserName(user.Username))
                        //{
                        //    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                        //}
                        //chèn dữ liệu
                        db.Users.Add(user);
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
                        ViewBag.ThongBao = "Thành công";
                        Session["Taikhoan"] = user;

                       return RedirectToAction("KhachHang","KhachHang");
                    
                    }
                    ViewBag.ThongBao = "Đăng nhập không thành công!";
                   // Response.Redirect("Dangnhap.cshtml");
                    return View();
                }
                public ActionResult Dangxuat()
                {
                    Session.Clear();
                    return new RedirectResult("/QuanTri/Dangnhap");
                   
                }

	        }
        }