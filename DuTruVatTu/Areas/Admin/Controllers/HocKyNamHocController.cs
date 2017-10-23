using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class HocKyNamHocController : BaseController
    {
        // GET: Admin/HocKyNamHoc
        public ActionResult Index()
        {
            ViewData["DSNamHoc"] = new NamHocModel().DanhSach();
            ViewData["DSKhoa"] = new KhoaHocModel().DanhSach();
            return View();
        }

        [HttpPost]
        public string HocKyTheoKhoaHocJSON(string msNamHoc, string msKhoaHoc)
        {
            HocKyModel hk = new HocKyModel();
            hk.MSKHOAHOC = int.Parse(msKhoaHoc);
            hk.MSNAMHOC = int.Parse(msNamHoc);
            return JsonConvert.SerializeObject(
                hk.HocKyTheoKhoaHoc(), new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" }
                );
        }

        [HttpPost]
        public string LayDanhSachHocKyHienTaiTheoKhoaJson(string maKhoa)
        {
            return JsonConvert.SerializeObject(
                new HocKyModel(int.Parse(maKhoa)).HocKyHienTai()
                );
        }

        [HttpPost]
        public int ThemHocKy(string mSNamHoc, string mSKhoaHoc, string tenHocKy, string ngayBatDau, string ngayKetThuc, 
            string ngayDuTru, string ngaytKetThucDuTru)
        {
            HocKyModel hk = new HocKyModel();
            hk.MSNAMHOC = int.Parse(mSNamHoc);
            hk.MSKHOAHOC = int.Parse(mSKhoaHoc);
            hk.TENHOCKY = tenHocKy;
            hk.NGAYBATDAU = DateTime.ParseExact(ngayBatDau, "yyyy-MM-dd", null);
            hk.NGAYKETTHUC = DateTime.ParseExact(ngayKetThuc, "yyyy-MM-dd", null);
            hk.THOIGIANBATDAUDUTRU = DateTime.ParseExact(ngayDuTru, "yyyy-MM-dd", null);
            hk.THOIGIANKETTHUCDUTRU = DateTime.ParseExact(ngaytKetThucDuTru, "yyyy-MM-dd", null);
            return hk.Them();
        }

        [HttpPost]
        public int CapNhatHocKy(string mSNamHoc, string mSKhoaHoc, string msHocKy, string tenHocKy, string ngayBatDau, string ngayKetThuc,
            string ngayDuTru, string ngaytKetThucDuTru)
        {
            HocKyModel hk = new HocKyModel();
            hk.MSNAMHOC = int.Parse(mSNamHoc);
            hk.MSKHOAHOC = int.Parse(mSKhoaHoc);
            hk.MSHOCKY = int.Parse(msHocKy);
            hk.TENHOCKY = tenHocKy;
            hk.NGAYBATDAU = DateTime.ParseExact(ngayBatDau, "yyyy-MM-dd", null);
            hk.NGAYKETTHUC = DateTime.ParseExact(ngayKetThuc, "yyyy-MM-dd", null);
            hk.THOIGIANBATDAUDUTRU = DateTime.ParseExact(ngayDuTru, "yyyy-MM-dd", null);
            hk.THOIGIANKETTHUCDUTRU = DateTime.ParseExact(ngaytKetThucDuTru, "yyyy-MM-dd", null);
            return hk.CapNhat();
        }

        [HttpPost]
        public int XoaHocKy(string msHocKy)
        {
            HocKyModel hk = new HocKyModel();
            hk.MSHOCKY = int.Parse(msHocKy);
            return hk.Xoa();
        }
    }
}