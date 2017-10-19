using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuTruVatTu.Interface
{
    interface iGiangVien
    {
        int MSGIANGVIEN { get; set; }
        string MAGIANGVIEN { get; set; }
        string TENGIANGVIEN { get; set; }
        DateTime NGAYSINH { get; set; }
        string GIOITINH { get; set; }
    }
}
