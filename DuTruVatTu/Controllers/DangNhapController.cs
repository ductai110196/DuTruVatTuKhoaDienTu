using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string a = new Command.Command().MaHoaChuoi(matKhau);
            var taiKhoan = new TaiKhoanDangNhapModel(tenDangNhap, new Command.Command().MaHoaChuoi(matKhau)).DangNhap();
            if (taiKhoan.Count > 0)
            {
                Session[Contains.SESSION_KEY_DANGNHAP] = taiKhoan[0];
                return RedirectToAction("Index", "XinChao", new { area = "Admin" });
            }
            else
            {
                ViewData["LoiDangNhap"] = "Đăng nhập thất bại.";
                return View("index");
            }
        }
    }
}