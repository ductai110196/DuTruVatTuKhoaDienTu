using DuTruVatTu.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class PhongController : BaseController
    {
        // GET: Admin/Phong
        public ActionResult Index()
        {
            ViewData["DSPhong"] = new DuTruVatTu.Models.PhongModel().DanhSach();
            ViewData["DSGiangVien"] = new DuTruVatTu.Models.GiangVienModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int KiemTra(string tenPhong)
        {
            return new DuTruVatTu.Models.PhongModel(tenPhong).KiemTra().Count;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Them( string tenPhong, string msGiangVien)
        {
            return new DuTruVatTu.Models.PhongModel(tenPhong, int.Parse(msGiangVien)).Them();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int CapNhat(string maPhong, string tenPhong, string msGiangVien)
        {
            return new DuTruVatTu.Models.PhongModel(int.Parse(maPhong), tenPhong, int.Parse(msGiangVien)).CapNhat();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Xoa(string maPhong)
        {
            return new DuTruVatTu.Models.PhongModel(int.Parse(maPhong)).Xoa();
        }
    }
}