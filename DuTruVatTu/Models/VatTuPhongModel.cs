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
    public class VatTuPhongModel : iVatTu, iPhong, iVatTuPhong, iGiangVien
    {
        public int MSVATTU { get; set; }
        public string TENVATTU { get; set; }
        public string DONVITINH { get; set; }
        public string HINHANH { get; set; }
        public int MSPHONG { get; set; }
        public string TENPHONG { get; set; }
        public int MSVATTUPHONG { get; set; }
        public int SOLUONG { get; set; }
        public int MSGIANGVIEN { get; set; }
        public string MAGIANGVIEN { get; set; }
        public string TENGIANGVIEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }

        public List<VatTuPhongModel> DanhSach()
        {
            List<VatTuPhongModel> list = new List<VatTuPhongModel>();
            Object[] par = {
                new SqlParameter("@mSVATTUPHONG", DBNull.Value),
                new SqlParameter("@mSVATTU", DBNull.Value),
                new SqlParameter("@mSPHONG", MSPHONG),
                new SqlParameter("@sOLUONG", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_VatTuPhong", par);
            foreach (DataRow item in dt.Rows)
            {
                VatTuPhongModel nlv = new VatTuPhongModel();
                nlv.MSVATTUPHONG = int.Parse(item["MSVATTUPHONG"].ToString());
                nlv.TENVATTU = item["TENVATTU"].ToString();
                nlv.MSVATTU = int.Parse(item["MSVATTU"].ToString());
                nlv.SOLUONG = int.Parse(item["SOLUONG"].ToString());
                nlv.HINHANH = item["HINHANH"].ToString();
                list.Add(nlv);
            }
            return list;
        }

        public List<VatTuPhongModel> KiemTra()
        {
            List<VatTuPhongModel> list = new List<VatTuPhongModel>();
            Object[] par = {
                new SqlParameter("@mSVATTUPHONG", DBNull.Value),
                new SqlParameter("@mSVATTU", MSVATTU),
                new SqlParameter("@mSPHONG", MSPHONG),
                new SqlParameter("@sOLUONG", DBNull.Value),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@kEY", DBKey.CHECK)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_VatTuPhong", par);
            foreach (DataRow item in dt.Rows)
            {
                VatTuPhongModel nlv = new VatTuPhongModel();
                nlv.MSVATTUPHONG = int.Parse(item["MSVATTUPHONG"].ToString());
                nlv.MSVATTU = int.Parse(item["MSVATTU"].ToString());
                nlv.SOLUONG = int.Parse(item["SOLUONG"].ToString());
                nlv.HINHANH = item["HINHANH"].ToString();
                list.Add(nlv);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSVATTUPHONG", DBNull.Value),
                new SqlParameter("@mSVATTU", MSVATTU),
                new SqlParameter("@mSPHONG", MSPHONG),
                new SqlParameter("@sOLUONG", SOLUONG),
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_VatTuPhong", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSVATTUPHONG", MSVATTUPHONG),
                new SqlParameter("@mSVATTU", MSVATTU),
                new SqlParameter("@mSPHONG", MSPHONG),
                new SqlParameter("@sOLUONG", SOLUONG),
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@kEY", DBKey.UPDATE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_VatTuPhong", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSVATTUPHONG", MSVATTUPHONG),
                new SqlParameter("@mSVATTU",  DBNull.Value),
                new SqlParameter("@mSPHONG",  DBNull.Value),
                new SqlParameter("@sOLUONG",  DBNull.Value),
                new SqlParameter("@mSGIANGVIEN",  DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_VatTuPhong", par).Rows[0][0].ToString());
        }
    }
}