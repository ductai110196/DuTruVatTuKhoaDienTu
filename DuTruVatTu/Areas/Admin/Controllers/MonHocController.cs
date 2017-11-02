using DuTruVatTu.Command;
using DuTruVatTu.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace DuTruVatTu.Areas.Admin.Controllers
{
    public class MonHocController : BaseController
    {
        // GET: Admin/MonHoc
        public ActionResult Index()
        {
            ViewData["DSBacDaoTao"] = new BacDaoTaoModel().DanhSach();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public string MonHocTheoBacDaoTaoJson(string maBacDaoTao)
        {
            MonHocModel mh = new MonHocModel();
            mh.MSBACDAOTAO = int.Parse(maBacDaoTao);
            return JsonConvert.SerializeObject(
                mh.DanhSach()
                );
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Them(string maBacDaoTao, string maHocPhan, string tenMonHoc, string lyThuyet, string thucHanh)
        {
            MonHocModel mh = new MonHocModel();
            mh.MSBACDAOTAO = int.Parse(maBacDaoTao);
            mh.MAHOCPHAN = maHocPhan;
            mh.TENHOCPHAN = tenMonHoc;
            mh.LYTHUYET = int.Parse(lyThuyet);
            mh.THUCHANH = int.Parse(thucHanh);
            return mh.Them();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int CapNhat(string maBacDaoTao, string mSMonHoc,
            string maMonHoc, string tenMonHoc, string lyThuyet, string thucHanh)
        {
            MonHocModel mh = new MonHocModel();
            mh.MSHOCPHAN = int.Parse(mSMonHoc);
            mh.MSBACDAOTAO = int.Parse(maBacDaoTao);
            mh.MAHOCPHAN = maMonHoc;
            mh.TENHOCPHAN = tenMonHoc;
            mh.LYTHUYET = int.Parse(lyThuyet);
            mh.THUCHANH = int.Parse(thucHanh);
            return mh.CapNhat();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int Xoa(string mSMonHoc)
        {
            MonHocModel mh = new MonHocModel();
            mh.MSHOCPHAN = int.Parse(mSMonHoc);
            return mh.Xoa();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public int KiemTra(string maBacDaoTao, string maMonHoc, string tenMonHoc)
        {
            MonHocModel mh = new MonHocModel();
            mh.MAHOCPHAN = maMonHoc;
            mh.MSBACDAOTAO = int.Parse(maBacDaoTao);
            mh.TENHOCPHAN = tenMonHoc;
            return mh.KiemTraMonHoc().Count;
        }
    }
}