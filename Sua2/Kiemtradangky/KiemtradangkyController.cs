using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Kiemtradangky
{
    public class KiemtradangkyController : Controller
    {
        QuanLiThuePhongEntities1 db = new QuanLiThuePhongEntities1();
        //
        // GET: /Kiemtradangky/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public bool CheckUserName(string Username)
        {
            return db.Users.Count(x => x.Username == Username) > 0;
        }

	}
}