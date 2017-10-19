using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuTruVatTu.Interface
{
    interface iTaiKhoanDangNhap
    {
        int MATAIKHOAN { get; set; }
        string TENDANGNHAP { get; set; }
        string MATKHAU { get; set; }
        string PHANQUYEN { get; set; }
        string ANHDAIDIEN { get; set; }
        string EMAIL { get; set; }
    }
}
