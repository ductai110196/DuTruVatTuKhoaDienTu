using DuTruVatTu.Database;
using DuTruVatTu.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DuTruVatTu.Models
{
    public class DuTruVatTuModel : iLopHocPhan, iGiangVien, iDuTruVatTu
    {
        public int MSLOPHOCPHAN { get; set; }
        public string MALOPHOCPHAN { get; set; }
        public string TENLOPHOCPHAN { get; set; }
        public int SISO { get; set; }
        public int LOAILOPHOCPHAN { get; set; }
        public int MSGIANGVIEN { get; set; }
        public string MAGIANGVIEN { get; set; }
        public string TENGIANGVIEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public int MSDUTRUVATTU { get; set; }
        public DateTime NGAYDUTRU { get; set; }

        public DuTruVatTuModel()
        {
        }

        public DuTruVatTuModel(int mSLOPHOCPHAN, int mSGIANGVIEN, int mSDUTRUVATTU, DateTime nGAYDUTRU)
        {
            MSLOPHOCPHAN = mSLOPHOCPHAN;
            MSGIANGVIEN = mSGIANGVIEN;
            MSDUTRUVATTU = mSDUTRUVATTU;
            NGAYDUTRU = nGAYDUTRU;
        }

        public DuTruVatTuModel(int mSDUTRUVATTU)
        {
            MSDUTRUVATTU = mSDUTRUVATTU;
        }

        public List<DuTruVatTuModel> DanhSach()
        {
            List<DuTruVatTuModel> list = new List<DuTruVatTuModel>();
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTU", DBNull.Value),
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@nGAYDUTRU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_DuTruVatTu", par);
            foreach (DataRow item in dt.Rows)
            {
                DuTruVatTuModel dtru = new DuTruVatTuModel();
                dtru.MSLOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.MALOPHOCPHAN = item["MALOPHOCPHAN"].ToString();
                dtru.TENLOPHOCPHAN = item["TENLOPHOCPHAN"].ToString();
                dtru.SISO = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.LOAILOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.MSGIANGVIEN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                dtru.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                dtru.NGAYSINH = DateTime.ParseExact(item["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                dtru.GIOITINH = item["GIOITINH"].ToString();
                MSDUTRUVATTU = int.Parse(item["MSDUTRUVATTU"].ToString()); ;
                NGAYDUTRU = DateTime.ParseExact(item["NGAYDUTRU"].ToString(), "dd/MM/yyyy", null);
                list.Add(dtru);
            }
            return list;
        }

        // Chưa làm
        public List<DuTruVatTuModel> KiemTra()
        {
            List<DuTruVatTuModel> list = new List<DuTruVatTuModel>();
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTU", DBNull.Value),
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@nGAYDUTRU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.CHECK),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_DuTruVatTu", par);
            foreach (DataRow item in dt.Rows)
            {
                DuTruVatTuModel dtru = new DuTruVatTuModel();
                dtru.MSLOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.MALOPHOCPHAN = item["MALOPHOCPHAN"].ToString();
                dtru.TENLOPHOCPHAN = item["TENLOPHOCPHAN"].ToString();
                dtru.SISO = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.LOAILOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.MSGIANGVIEN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                dtru.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                dtru.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                dtru.NGAYSINH = DateTime.ParseExact(item["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                dtru.GIOITINH = item["GIOITINH"].ToString();
                MSDUTRUVATTU = int.Parse(item["MSDUTRUVATTU"].ToString()); ;
                NGAYDUTRU = DateTime.ParseExact(item["NGAYDUTRU"].ToString(), "dd/MM/yyyy", null);
                list.Add(dtru);
            }
            return list;
        }

        public int Them()
        {
            List<DuTruVatTuModel> list = new List<DuTruVatTuModel>();
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTU", DBNull.Value),
                new SqlParameter("@mSLOPHOCPHAN", MSLOPHOCPHAN),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@nGAYDUTRU", NGAYDUTRU),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_DuTruVatTu", par).Rows[0][0].ToString());
        }


        public int CapNhat()
        {
            List<DuTruVatTuModel> list = new List<DuTruVatTuModel>();
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTU", MSDUTRUVATTU),
                new SqlParameter("@mSLOPHOCPHAN", MSLOPHOCPHAN),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@nGAYDUTRU", NGAYDUTRU),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_DuTruVatTu", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            List<DuTruVatTuModel> list = new List<DuTruVatTuModel>();
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTU", MSDUTRUVATTU),
                new SqlParameter("@mSLOPHOCPHAN", MSLOPHOCPHAN),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@nGAYDUTRU", NGAYDUTRU),
                new SqlParameter("@kEY", DBKey.DELETE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_DuTruVatTu", par).Rows[0][0].ToString());
        }
    }
}