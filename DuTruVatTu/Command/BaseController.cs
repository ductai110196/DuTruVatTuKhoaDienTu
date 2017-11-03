using DuTruVatTu.Models;
using System;
using System.Web.Mvc;

namespace DuTruVatTu.Command
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionDangNhap = (TaiKhoanDangNhapModel)Session[Contains.SESSIONKEYDANGNHAP];
            if (sessionDangNhap != null)
            {
                QuyenHanModel qh = new QuyenHanModel();
                qh.SetJSON(sessionDangNhap.PHANQUYEN);
                bool st = false;
                string action = this.ControllerContext.RouteData.Values["action"].ToString();
                string controller = this.ControllerContext.RouteData.Values["controller"].ToString();
                switch (controller)
                {
                    case "BacDaoTao":
                        st = qh.BACDAOTAO;
                        break;
                    case "LopHocPhan":
                        st = qh.LOPHOCPHAN;
                        break;
                    case "ChucVu":
                        st = qh.CHUCVU;
                        break;
                    case "DuTruVatTu":
                        st = qh.DUTRUVATTU;
                        break;
                    case "GiangVien":
                        st = qh.GIANGVIEN;
                        break;
                    case "HocKyNamHoc":
                        st = qh.HOCKYNAMHOC;
                        break;
                    case "KhoaHoc":
                        st = qh.KHOAHOC;
                        break;
                    case "MonHoc":
                        st = qh.MONHOC;
                        break;
                    case "NhomLinhVuc":
                        st = qh.NHOMLINHVUC;
                        break;
                    case "NhomVatTu":
                        st = qh.NHOMVATTU;
                        break;
                    case "PhanCongGiangDay":
                        st = qh.PHANCONGGIANGDAY;
                        break;
                    case "Phong":
                        st = qh.PHONG;
                        break;
                    case "NguoiDung":
                        st = qh.QUANLYTAIKHOAN;
                        break;
                    case "DangNhap":
                        st = qh.DANGNHAP;
                        break;
                    case "VatTu":
                        st = qh.VATTU;
                        break;
                    case "VatTuPhong":
                        st = qh.VATTUPHONG;
                        break;
                    case "ThongKeDuTruVatTu":
                        st = qh.THONGKEDUTRUVATTU;
                        break;
                    case "ThongKeVatTuPhong":
                        st = qh.THONGKEVATTUPHONG;
                        break;
                    default:
                        st = false;
                        break;
                }
                if (Array.IndexOf(Contains.LISTACTIONQUYENHAN, action) != -1)
                    st = true;
                if (!st)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                            System.Web.Routing.RouteValueDictionary(new
                            {
                                action = "Index",
                                controller = "TuChoi",
                                area = "Admin"
                            }));
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new
                    {
                        action = "Index",
                        controller = "../DangNhap"
                    }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}