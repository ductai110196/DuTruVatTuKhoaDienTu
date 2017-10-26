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
    public class GiangVienController : BaseController
    {
        // GET: Admin/GiangVien
        public ActionResult Index()
        {
            ViewData["DSGiangVien"] = new GiangVienModel().DanhSach();
            ViewData["DSChucVu"] = new ChucVuModel().DanhSach();
            return View();
        }

        [HttpPost]
        public int Them(string maGiangVien, string tenGiangVien, string ngaySinh, string gioiTinh, string maChucVu)
        {
            GiangVienModel gv = new GiangVienModel();
            gv.MAGIANGVIEN = maGiangVien;
            gv.TENGIANGVIEN = tenGiangVien;
            gv.NGAYSINH = DateTime.ParseExact(ngaySinh, "yyyy-MM-dd", null);
            gv.GIOITINH = gioiTinh;
            gv.MSCHUCVU = int.Parse(maChucVu);
            return gv.Them();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public int CapNhat(string msGiangVien, string maGiangVien, string tenGiangVien, 
            string ngaySinh, string gioiTinh, string maChucVu)
        {
            GiangVienModel gv = new GiangVienModel();
            gv.MSGIANGVIEN = int.Parse(msGiangVien);
            gv.MAGIANGVIEN = maGiangVien;
            gv.TENGIANGVIEN = tenGiangVien;
            gv.NGAYSINH = DateTime.ParseExact(ngaySinh, "yyyy-MM-dd", null);
            gv.GIOITINH = gioiTinh;
            gv.MSCHUCVU = int.Parse(maChucVu);
            return gv.CapNhat();
        }

        [HttpPost]
        public int Xoa(string msGiangVien)
        {
            GiangVienModel gv = new GiangVienModel();
            gv.MSGIANGVIEN = int.Parse(msGiangVien);
            return gv.Xoa();
        }

        [HttpPost]
        public string DanhSachGiangVienJSON()
        {
            return JsonConvert.SerializeObject(
                new GiangVienModel().DanhSach());
        }
    }
}