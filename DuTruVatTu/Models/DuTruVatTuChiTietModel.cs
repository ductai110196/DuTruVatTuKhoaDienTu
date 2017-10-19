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
    public class DuTruVatTuChiTietModel : iDuTruVatTuChiTiet, iVatTu, iDuTruVatTu
    {
        public int MSDUTRUVATTUCHITIET { get; set; }
        public int SOLUONGVATTU { get; set; }
        public int MSVATTU { get; set; }
        public string TENVATTU { get; set; }
        public string DONVITINH { get; set; }
        public string HINHANH { get; set; }
        public int MSDUTRUVATTU { get; set; }
        public DateTime NGAYDUTRU { get; set; }

        public DuTruVatTuChiTietModel()
        {
        }

        public DuTruVatTuChiTietModel(int mSDUTRUVATTUCHITIET, int sOLUONGVATTU, int mSVATTU, string tENVATTU, 
            string dONVITINH, string hINHANH, int mSDUTRUVATTU, DateTime nGAYDUTRU)
        {
            MSDUTRUVATTUCHITIET = mSDUTRUVATTUCHITIET;
            SOLUONGVATTU = sOLUONGVATTU;
            MSVATTU = mSVATTU;
            TENVATTU = tENVATTU;
            DONVITINH = dONVITINH;
            HINHANH = hINHANH;
            MSDUTRUVATTU = mSDUTRUVATTU;
            NGAYDUTRU = nGAYDUTRU;
        }

        public List<DuTruVatTuChiTietModel> DanhSach()
        {
            List<DuTruVatTuChiTietModel> list = new List<DuTruVatTuChiTietModel>();
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTUCHITIET", DBNull.Value),
                new SqlParameter("@mSDUTRUVATTU", DBNull.Value),
                new SqlParameter("@mSVATTU", DBNull.Value),
                new SqlParameter("@sOLUONGVATTU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_DuTruVatTuChiTiet", par);
            foreach (DataRow item in dt.Rows)
            {
                DuTruVatTuChiTietModel dtru = new DuTruVatTuChiTietModel();
                dtru.MSDUTRUVATTUCHITIET = int.Parse(item["MSDUTRUVATTUCHITIET"].ToString());
                dtru.SOLUONGVATTU = int.Parse(item["SOLUONGVATTU"].ToString());
                dtru.MSVATTU = int.Parse(item["MSVATTU"].ToString());
                dtru.TENVATTU = item["TENVATTU"].ToString();
                dtru.DONVITINH = item["DONVITINH"].ToString();
                dtru.HINHANH = item["HINHANH"].ToString(); ;
                dtru.MSDUTRUVATTU = int.Parse(item["MSDUTRUVATTU"].ToString());
                dtru.NGAYDUTRU = DateTime.ParseExact(item["NGAYDUTRU"].ToString(), "dd/MM/yyyy", null);
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
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTUCHITIET", DBNull.Value),
                new SqlParameter("@mSDUTRUVATTU", MSDUTRUVATTU),
                new SqlParameter("@mSVATTU", MSVATTU),
                new SqlParameter("@sOLUONGVATTU", SOLUONGVATTU),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_DuTruVatTuChiTiet", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTUCHITIET", MSDUTRUVATTUCHITIET),
                new SqlParameter("@mSDUTRUVATTU", MSDUTRUVATTU),
                new SqlParameter("@mSVATTU", MSVATTU),
                new SqlParameter("@sOLUONGVATTU", SOLUONGVATTU),
                new SqlParameter("@kEY", DBKey.UPDATE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_DuTruVatTuChiTiet", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSDUTRUVATTUCHITIET", MSDUTRUVATTUCHITIET),
                new SqlParameter("@mSDUTRUVATTU", DBNull.Value),
                new SqlParameter("@mSVATTU", DBNull.Value),
                new SqlParameter("@sOLUONGVATTU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_DuTruVatTuChiTiet", par).Rows[0][0].ToString());
        }
    }
}