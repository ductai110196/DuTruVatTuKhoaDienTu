using DuTruVatTu.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Controllers
{
    public class DangXuatController : Controller
    {
        // GET: DangXuat
        public ActionResult Index()
        {
            Session.Remove(Contains.SESSION_KEY_DANGNHAP);
            return RedirectToAction("Index", "DangNhap");
        }
    }
}