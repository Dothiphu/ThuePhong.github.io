using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Template.ViewModels;
using Template.Models;

namespace Template.Controllers
{
    public class TrangChuController : Controller
    {
        //
        // GET: /TrangChu/
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult RegistrationRoom(DangKiPhongViewModel DkpViewModel)
        //{
        //    Phong phong = new Phong();

        //    phong.DienTich = DkpViewModel.Phongs.DienTich;
        //}
	}
}