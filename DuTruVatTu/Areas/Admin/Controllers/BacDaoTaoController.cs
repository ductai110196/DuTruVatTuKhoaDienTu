using DuTruVatTu.Command;
using DuTruVatTu.Models;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class BacDaoTaoController : BaseController
    {
        // GET: Admin/BacDaoTao
        public ActionResult Index()
        {
            ViewData["DSBacDaoTao"] = new BacDaoTaoModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Them(string tenBacDaoTao)
        {
            BacDaoTaoModel bdt = new BacDaoTaoModel();
            bdt.TENBACDAOTAO = tenBacDaoTao;
            return bdt.Them();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int CapNhat(string msBacDaoTao, string tenBacDaoTao)
        {
            BacDaoTaoModel bdt = new BacDaoTaoModel();
            bdt.MSBACDAOTAO = int.Parse(msBacDaoTao);
            bdt.TENBACDAOTAO = tenBacDaoTao;
            return bdt.CapNhat();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Xoa(string msBacDaoTao)
        {
            BacDaoTaoModel bdt = new BacDaoTaoModel();
            bdt.MSBACDAOTAO = int.Parse(msBacDaoTao);
            return bdt.Xoa();
        }
    }
}