using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuTruVatTu.Interface
{
    interface iMonHoc
    {
        int MSHOCPHAN { get; set; }
        string TENHOCPHAN { get; set; }
        int LYTHUYET { get; set; }
        int THUCHANH { get; set; }
    }
}
