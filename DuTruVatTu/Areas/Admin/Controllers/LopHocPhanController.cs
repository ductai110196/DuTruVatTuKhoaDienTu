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
    public class LopHocPhanController : BaseController
    {
        // GET: Admin/LopHocPhan
        public ActionResult Index()
        {
            ViewData["DSBacDaoTao"] = new BacDaoTaoModel().DanhSach();
            ViewData["DSKhoaHoc"] = new KhoaHocModel().DanhSach();
            HocKyModel m = new HocKyModel();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public string LopHocPhanJSON(string hocKy, string maHocPhan)
        {
            return JsonConvert.SerializeObject(
                new LopHocPhanModel(int.Parse(maHocPhan), int.Parse(hocKy)).DanhSach()
                );
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int ThemJSON(string hocKy, string maHocPhan, string maLopHocphan, 
            string tenLopHocPhan, string siSo, string loaiLopHocPhan)
        {
            int st =  new LopHocPhanModel(maLopHocphan, tenLopHocPhan, int.Parse(siSo),
                    int.Parse(loaiLopHocPhan), int.Parse(maHocPhan), int.Parse(hocKy)).Them();
            if (st > 0)
            {
                PhanCongGiangDayModel pc = new PhanCongGiangDayModel();
                pc.MSGIANGVIEN = Contains.TAIKHOANDANGNHAP.MSGIANGVIEN;
                pc.MSLOPHOCPHAN = st;
                return pc.Them();
            }
            return 0;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int CapNhatJSON(string msLopHocPhan, string hocKy, string maHocPhan, string maLopHocPhan,
            string tenLopHocPhan, string siSo, string loaiLopHocPhan)
        {
            return new LopHocPhanModel(int.Parse(msLopHocPhan), maLopHocPhan, tenLopHocPhan, int.Parse(siSo),
                    int.Parse(loaiLopHocPhan), int.Parse(maHocPhan), int.Parse(hocKy)).CapNhat();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int XoaJSON(string msLopHocPhan)
        {
            return new LopHocPhanModel(int.Parse(msLopHocPhan)).Xoa();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int KiemTra(string hocKy, string maLopHocphan, 
            string tenLopHocPhan)
        {
            LopHocPhanModel lhp = new LopHocPhanModel();
            lhp.MSHOCKY = int.Parse(hocKy);
            lhp.MALOPHOCPHAN = maLopHocphan;
            lhp.TENLOPHOCPHAN = tenLopHocPhan;
            return lhp.KiemTra().Count;
        }
    }
}