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
    public class DuTruVatTuController : BaseController
    {
        // GET: Admin/DuTru
        public ActionResult Index()
        {
            var magiangvien = ((TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP]).MSGIANGVIEN;
            ViewData["DSLopHocPhan"] = new DuTruVatTuModel().DanhSachLopHocPhanTheoGiangVien(magiangvien);
            ViewData["DSNhomLinhVuc"] = new NhomLinhVucModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public string DanhSachDuTruJSON(string maLopHocphan)
        {
            DuTruVatTuModel dt = new DuTruVatTuModel();
            dt.MSGIANGVIEN = ((TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP]).MSGIANGVIEN;
            dt.MSLOPHOCPHAN = int.Parse(maLopHocphan);
            return JsonConvert.SerializeObject(dt.DanhSach(), new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public string DSVatTuJSON(string maLopHocphan, string maLinhVuc, string maNhomVatTu)
        {
            DuTruVatTuModel dt = new DuTruVatTuModel();
            dt.MSGIANGVIEN = ((TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP]).MSGIANGVIEN;
            dt.MSLOPHOCPHAN = int.Parse(maLopHocphan);
            dt.MSNHOMLINHVUC = int.Parse(maLinhVuc);
            dt.MSNHOMVATTU = int.Parse(maNhomVatTu);
            return JsonConvert.SerializeObject(dt.DanhSachVatTu());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public void ThemDuTruVatTu(string mangVatTu, string mangSoLuong, 
            string msLopHocPhan)
        {
            var magiangvien = ((TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP]).MSGIANGVIEN;
            var vatTu = JsonConvert.DeserializeObject<String[]>(mangVatTu);
            var soLuong = JsonConvert.DeserializeObject<String[]>(mangSoLuong);
            DuTruVatTuModel dtvt = new DuTruVatTuModel();
            dtvt.MSLOPHOCPHAN = int.Parse(msLopHocPhan);
            dtvt.MSGIANGVIEN = magiangvien;
            int msDuTruVatTu = dtvt.Them();
            DuTruVatTuChiTietModel dtvtct = new DuTruVatTuChiTietModel();
            for(int i = 0; i < vatTu.Length; i++)
            {
                dtvtct.MSVATTU = int.Parse(vatTu[i]);
                dtvtct.SOLUONGVATTU = int.Parse(soLuong[i]);
                dtvtct.MSDUTRUVATTU = msDuTruVatTu;
                dtvtct.Them();
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Xoa(string maDuTruVatTuChiTiet)
        {
            DuTruVatTuModel dt = new DuTruVatTuModel();
            dt.MSDUTRUVATTUCHITIET = int.Parse(maDuTruVatTuChiTiet);
            return dt.Xoa();
        }
    }
}