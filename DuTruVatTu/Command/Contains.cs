using DuTruVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuTruVatTu.Command
{
    public class Contains
    {
        public static string SESSIONKEYDANGNHAP = "SESSION_KEY_DANGNHAP";
        public static TaiKhoanDangNhapModel TAIKHOANDANGNHAP = null;
        public static string [] LISTACTIONQUYENHAN = new string[]{
            "DanhSachGiangVienJSON",
            "HocKyTheoKhoaHocJSON",
            "LayDanhSachHocKyHienTaiTheoKhoaJson",
            "LopHocPhanJSON",
            "MonHocTheoBacDaoTaoJson",
            "DSNhomVatTuJSON",
            "DSVatTuJSON"
        };
    }
}