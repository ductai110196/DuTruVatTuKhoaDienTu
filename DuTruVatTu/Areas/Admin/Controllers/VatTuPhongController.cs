using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class VatTuPhongController : BaseController
    {
        // GET: Admin/VatTuPhong
        public ActionResult Index()
        {
            PhongModel phong = new PhongModel();
            phong.MSGIANGVIEN = ((TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP]).MSGIANGVIEN;
            ViewData["DSPhong"] = phong.DanhSachPhongTheoGiangVien();
            ViewData["DSNhomLinhVuc"] = new NhomLinhVucModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public string HocKyTheoKhoaHocJSON(string maPhong)
        {
            VatTuPhongModel vtp = new VatTuPhongModel();
            vtp.MSPHONG = int.Parse(maPhong);
            return JsonConvert.SerializeObject(
               vtp.DanhSach());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Them(string arrVatTu, string arrSoLuong, string msPhong)
        {
            VatTuPhongModel vtp = new VatTuPhongModel();
            List<string> arrThemVatTu = JsonConvert.DeserializeObject<List<string>>(arrVatTu);
            List<string> arrThemSoLuong = JsonConvert.DeserializeObject<List<string>>(arrVatTu);
            vtp.MSPHONG = int.Parse(msPhong);
            for (int i = 0; i < arrThemVatTu.Count; i++)
            {
                vtp.MSVATTU = int.Parse(arrThemVatTu[i]);
                vtp.SOLUONG = int.Parse(arrThemSoLuong[i]);
                vtp.Them();
            }
            return 1;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Xoa(string mSVATTUPHONG)
        {
            VatTuPhongModel vtp = new VatTuPhongModel();
            vtp.MSVATTUPHONG = int.Parse(mSVATTUPHONG);
            return vtp.Xoa();
        }
    }
}