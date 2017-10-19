using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        // GET: Admin/QuanLyTaiKhoan
        public ActionResult Index()
        {
            ViewData["DSTaiKhoan"] = new TaiKhoanDangNhapModel().DanhSach();
            return View();
        }

        public string QuyenHanChiTiet(string maTaiKhoan)
        {
            return JsonConvert.SerializeObject(
                new TaiKhoanDangNhapModel(int.Parse(maTaiKhoan)).TaiKhoanChiTiet()
                );
        }
        public int CapNhat(
                    string maTaiKhoan,
                    string tenDangNhap,
                    string email,
                    string quyenHan)
        {
            return new TaiKhoanDangNhapModel(
                int.Parse(maTaiKhoan), tenDangNhap, "", quyenHan, "", email
                ).CapNhat();
        }
    }
}