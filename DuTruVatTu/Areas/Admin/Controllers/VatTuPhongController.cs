using CrystalDecisions.CrystalReports.Engine;
using DuTruVatTu.Command;
using DuTruVatTu.Models;
using DuTruVatTu.Report;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        [HttpGet]
        public ActionResult Report(string maPhong, string tenPhong)
        {
            VatTuPhongModel vtp = new VatTuPhongModel(); 
            vtp.MSPHONG = int.Parse(maPhong);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "rptVatTuPhong.rpt"));
            rd.SetDataSource(vtp.Report());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            TextObject txtReportHeader;
            txtReportHeader = rd.ReportDefinition.ReportObjects["lblTieuDe"] as TextObject;
            txtReportHeader.Text = "THỐNG KÊ SỐ LƯỢNG VẬT TƯ HIỆN CÓ TẠI PHÒNG " + tenPhong;
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/xls", new Command.Command().ConvertFileName(txtReportHeader.Text) + ".xls");
        }
    }
}