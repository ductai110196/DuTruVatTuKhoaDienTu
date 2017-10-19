using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuTruVatTu.Interface
{
    interface iHocKy
    {
        int MSHOCKY { get; set; }
        string TENHOCKY { get; set; }
        DateTime NGAYBATDAU { get; set; }
        DateTime NGAYKETTHUC { get; set; }
        DateTime THOIGIANBATDAUDUTRU { get; set; }
        DateTime THOIGIANKETTHUCDUTRU { get; set; }
    }
}
