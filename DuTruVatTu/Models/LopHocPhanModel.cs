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
    public class LopHocPhanModel : iMonHoc, iLopHocPhan, iHocKy
    {
        public int MSLOPHOCPHAN { get; set; }
        public string MALOPHOCPHAN { get; set; }
        public string TENLOPHOCPHAN { get; set; }
        public int SISO { get; set; }
        public int LOAILOPHOCPHAN { get; set; }
        public int MSHOCPHAN { get; set; }
        public string TENHOCPHAN { get; set; }
        public int LYTHUYET { get; set; }
        public int THUCHANH { get; set; }
        public int MSHOCKY { get; set; }
        public string TENHOCKY { get; set; }
        public DateTime NGAYBATDAU { get; set; }
        public DateTime NGAYKETTHUC { get; set; }
        public DateTime THOIGIANBATDAUDUTRU { get; set; }
        public DateTime THOIGIANKETTHUCDUTRU { get; set; }

        public LopHocPhanModel()
        {
        }

        public LopHocPhanModel(int mSLOPHOCPHAN, string mALOPHOCPHAN, string tENLOPHOCPHAN,
                                int sISO, int lOAILOPHOCPHAN, int mSHOCPHAN, int mSHOCKY)
        {
            MSLOPHOCPHAN = mSLOPHOCPHAN;
            MALOPHOCPHAN = mALOPHOCPHAN;
            TENLOPHOCPHAN = tENLOPHOCPHAN;
            SISO = sISO;
            LOAILOPHOCPHAN = lOAILOPHOCPHAN;
            MSHOCPHAN = mSHOCPHAN;
            MSHOCKY = mSHOCKY;
        }

        public LopHocPhanModel(string mALOPHOCPHAN, string tENLOPHOCPHAN,
                                int sISO, int lOAILOPHOCPHAN, int mSHOCPHAN, int mSHOCKY)
        {
            MALOPHOCPHAN = mALOPHOCPHAN;
            TENLOPHOCPHAN = tENLOPHOCPHAN;
            SISO = sISO;
            LOAILOPHOCPHAN = lOAILOPHOCPHAN;
            MSHOCPHAN = mSHOCPHAN;
            MSHOCKY = mSHOCKY;
        }

        public LopHocPhanModel(int mSLOPHOCPHAN)
        {
            MSLOPHOCPHAN = mSLOPHOCPHAN;
        }

        public LopHocPhanModel(int mSHOCPHAN, int mSHOCKY)
        {
            MSHOCKY = mSHOCKY;
            MSHOCPHAN = mSHOCPHAN;
        }

        public List<LopHocPhanModel> DanhSach()
        {
            List<LopHocPhanModel> list = new List<LopHocPhanModel>();
            Object[] par = {
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSHOCKY", MSHOCKY),
                new SqlParameter("@mSHOCPHAN", MSHOCPHAN),
                new SqlParameter("@mALOPHOCPHAN", DBNull.Value),
                new SqlParameter("@tENLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@sISO", DBNull.Value),
                new SqlParameter("@lOAILOPHOCPHAN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_LopHocPhan", par);
            foreach (DataRow item in dt.Rows)
            {
                LopHocPhanModel lhp = new LopHocPhanModel();
                lhp.MSLOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                lhp.MALOPHOCPHAN = item["MALOPHOCPHAN"].ToString();
                lhp.TENLOPHOCPHAN = item["TENLOPHOCPHAN"].ToString();
                lhp.SISO = int.Parse(item["SISO"].ToString());
                lhp.LOAILOPHOCPHAN = int.Parse(item["LOAILOPHOCPHAN"].ToString());
                lhp.MSHOCPHAN = int.Parse(item["MSHOCPHAN"].ToString());
                lhp.TENHOCPHAN = item["TENHOCPHAN"].ToString();
                lhp.LYTHUYET = int.Parse(item["LYTHUYET"].ToString());
                lhp.THUCHANH = int.Parse(item["THUCHANH"].ToString());
                lhp.MSHOCKY = int.Parse(item["MSHOCKY"].ToString());
                lhp.TENHOCKY = item["TENHOCKY"].ToString();
                lhp.NGAYBATDAU = DateTime.ParseExact(item["NGAYBATDAU"].ToString(), "dd/MM/yyyy", null);
                lhp.NGAYKETTHUC = DateTime.ParseExact(item["NGAYKETTHUC"].ToString(), "dd/MM/yyyy", null);
                lhp.THOIGIANBATDAUDUTRU = DateTime.ParseExact(item["THOIGIANBATDAUDUTRU"].ToString(), "dd/MM/yyyy", null);
                lhp.THOIGIANKETTHUCDUTRU = DateTime.ParseExact(item["THOIGIANKETTHUCDUTRU"].ToString(), "dd/MM/yyyy", null);
                list.Add(lhp);
            }
            return list;
        }

        public List<LopHocPhanModel> KiemTra()
        {
            List<LopHocPhanModel> list = new List<LopHocPhanModel>();
            Object[] par = {
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSHOCKY", MSHOCKY),
                new SqlParameter("@mSHOCPHAN", DBNull.Value),
                new SqlParameter("@mALOPHOCPHAN", DBNull.Value),
                new SqlParameter("@tENLOPHOCPHAN", TENLOPHOCPHAN),
                new SqlParameter("@sISO", DBNull.Value),
                new SqlParameter("@lOAILOPHOCPHAN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.CHECK),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_LopHocPhan", par);
            foreach (DataRow item in dt.Rows)
            {
                LopHocPhanModel lhp = new LopHocPhanModel();
                MSLOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                MALOPHOCPHAN = item["MALOPHOCPHAN"].ToString();
                TENLOPHOCPHAN = item["MALOPHOCPHAN"].ToString();
                SISO = int.Parse(item["MSLOPHOCPHAN"].ToString());
                LOAILOPHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                MSHOCPHAN = int.Parse(item["MSLOPHOCPHAN"].ToString());
                TENHOCPHAN = item["MALOPHOCPHAN"].ToString();
                LYTHUYET = int.Parse(item["MSLOPHOCPHAN"].ToString());
                THUCHANH = int.Parse(item["MSLOPHOCPHAN"].ToString());
                MSHOCKY = int.Parse(item["MSLOPHOCPHAN"].ToString());
                TENHOCKY = item["MALOPHOCPHAN"].ToString();
                NGAYBATDAU = DateTime.ParseExact(item["MALOPHOCPHAN"].ToString(), "dd/MM/yyyy", null);
                NGAYKETTHUC = DateTime.ParseExact(item["MALOPHOCPHAN"].ToString(), "dd/MM/yyyy", null);
                THOIGIANBATDAUDUTRU = DateTime.ParseExact(item["MALOPHOCPHAN"].ToString(), "dd/MM/yyyy", null);
                THOIGIANKETTHUCDUTRU = DateTime.ParseExact(item["MALOPHOCPHAN"].ToString(), "dd/MM/yyyy", null);
                list.Add(lhp);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@mSHOCKY", MSHOCKY),
                new SqlParameter("@mSHOCPHAN", MSHOCPHAN),
                new SqlParameter("@mALOPHOCPHAN", MALOPHOCPHAN),
                new SqlParameter("@tENLOPHOCPHAN", TENLOPHOCPHAN),
                new SqlParameter("@sISO", SISO),
                new SqlParameter("@lOAILOPHOCPHAN", LOAILOPHOCPHAN),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_LopHocPhan", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSLOPHOCPHAN", MSLOPHOCPHAN),
                new SqlParameter("@mSHOCKY", MSHOCKY),
                new SqlParameter("@mSHOCPHAN", MSHOCPHAN),
                new SqlParameter("@mALOPHOCPHAN", MALOPHOCPHAN),
                new SqlParameter("@tENLOPHOCPHAN", TENLOPHOCPHAN),
                new SqlParameter("@sISO", SISO),
                new SqlParameter("@lOAILOPHOCPHAN", LOAILOPHOCPHAN),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_LopHocPhan", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSLOPHOCPHAN", MSLOPHOCPHAN),
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSHOCPHAN", DBNull.Value),
                new SqlParameter("@mALOPHOCPHAN", DBNull.Value),
                new SqlParameter("@tENLOPHOCPHAN", DBNull.Value),
                new SqlParameter("@sISO", DBNull.Value),
                new SqlParameter("@lOAILOPHOCPHAN", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_LopHocPhan", par).Rows[0][0].ToString());
        }
    }
}