using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class NhomLinhVucController : BaseController
    {
        // GET: Admin/NhomLinhVuc
        public ActionResult Index()
        {
            ViewData["DSNhomLinhVuc"] = new NhomLinhVucModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Them(string tenNhom)
        {
            NhomLinhVucModel nlv = new NhomLinhVucModel();
            nlv.TENNHOMLINHVUC = tenNhom;
            return nlv.Them();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int CapNhat(string msNhom, string tenNhom)
        {
            NhomLinhVucModel nlv = new NhomLinhVucModel();
            nlv.MSNHOMLINHVUC = int.Parse(msNhom);
            nlv.TENNHOMLINHVUC = tenNhom;
            return nlv.CapNhat();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Xoa(string msNhom)
        {
            NhomLinhVucModel nlv = new NhomLinhVucModel();
            nlv.MSNHOMLINHVUC = int.Parse(msNhom);
            return nlv.Xoa();
        }
    }
}