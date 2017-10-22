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
    public class HocKyModel : iHocKy, iNamHoc
    {
        public int MSHOCKY { get; set; }
        public int MSKHOAHOC { get; set; }
        public string TENHOCKY { get; set; }
        public DateTime NGAYBATDAU { get; set; }
        public DateTime NGAYKETTHUC { get; set; }
        public DateTime THOIGIANBATDAUDUTRU { get; set; }
        public DateTime THOIGIANKETTHUCDUTRU { get; set; }
        public int MSNAMHOC { get; set; }
        public string TENNAMHOC { get; set; }
        public string TRANGTHAIHOCKY { get; set; }
        public string TRANGTHAIDUTRU { get; set; }

        public HocKyModel()
        {
        }

        public HocKyModel(int mSHOCKY, int mSKHOAHOC, string tENHOCKY, DateTime nGAYBATDAU, DateTime nGAYKETTHUC, 
            DateTime tHOIGIANBATDAUDUTRU, DateTime tHOIGIANKETTHUCDUTRU, int mSNAMHOC)
        {
            MSHOCKY = mSHOCKY;
            MSKHOAHOC = mSKHOAHOC;
            TENHOCKY = tENHOCKY;
            NGAYBATDAU = nGAYBATDAU;
            NGAYKETTHUC = nGAYKETTHUC;
            THOIGIANBATDAUDUTRU = tHOIGIANBATDAUDUTRU;
            THOIGIANKETTHUCDUTRU = tHOIGIANKETTHUCDUTRU;
            MSNAMHOC = mSNAMHOC;
        }

        public HocKyModel(int mSKHOAHOC)
        {
            MSKHOAHOC = mSKHOAHOC;
        }

        public HocKyModel(string tENHOCKY, int mSNAMHOC)
        {
            TENHOCKY = tENHOCKY;
            MSNAMHOC = mSNAMHOC;
        }

        public List<HocKyModel> HocKyHienTai()
        {
            List<HocKyModel> list = new List<HocKyModel>();
            Object[] par = {
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSNAMHOC", DBNull.Value),
                new SqlParameter("@mSKHOAHOC", MSKHOAHOC),
                new SqlParameter("@tENHOCKY", DBNull.Value),
                new SqlParameter("@nGAYBATDAU", DBNull.Value),
                new SqlParameter("@nGAYKETTHUC", DBNull.Value),
                new SqlParameter("@tHOIGIANBATDAUDUTRU", DBNull.Value),
                new SqlParameter("@tHOIGIANKETTHUCDUTRU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT_CURRENT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_HocKy", par);
            foreach (DataRow item in dt.Rows)
            {
                HocKyModel hk = new HocKyModel();
                hk.MSHOCKY = int.Parse(item["MSHOCKY"].ToString());
                hk.MSKHOAHOC = int.Parse(item["MSKHOAHOC"].ToString());
                hk.TENHOCKY = item["TENHOCKY"].ToString();
                hk.NGAYBATDAU = DateTime.ParseExact(item["NGAYBATDAU"].ToString(), "dd/MM/yyyy", null);
                hk.NGAYKETTHUC = DateTime.ParseExact(item["NGAYKETTHUC"].ToString(), "dd/MM/yyyy", null);
                hk.THOIGIANBATDAUDUTRU = DateTime.ParseExact(item["THOIGIANBATDAUDUTRU"].ToString(), "dd/MM/yyyy", null);
                hk.THOIGIANKETTHUCDUTRU = DateTime.ParseExact(item["THOIGIANKETTHUCDUTRU"].ToString(), "dd/MM/yyyy", null);
                hk.MSNAMHOC = int.Parse(item["MSNAMHOC"].ToString());
                hk.TENNAMHOC = item["TENNAMHOC"].ToString();
                list.Add(hk);
            }
            return list;
        }

        public List<HocKyModel> HocKyTheoKhoaHoc()
        {
            List<HocKyModel> list = new List<HocKyModel>();
            Object[] par = {
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSNAMHOC", MSNAMHOC),
                new SqlParameter("@mSKHOAHOC", MSKHOAHOC),
                new SqlParameter("@tENHOCKY", DBNull.Value),
                new SqlParameter("@nGAYBATDAU", DBNull.Value),
                new SqlParameter("@nGAYKETTHUC", DBNull.Value),
                new SqlParameter("@tHOIGIANBATDAUDUTRU", DBNull.Value),
                new SqlParameter("@tHOIGIANKETTHUCDUTRU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_HocKy", par);
            foreach (DataRow item in dt.Rows)
            {
                HocKyModel hk = new HocKyModel();
                hk.MSHOCKY = int.Parse(item["MSHOCKY"].ToString());
                hk.MSKHOAHOC = int.Parse(item["MSKHOAHOC"].ToString());
                hk.TENHOCKY = item["TENHOCKY"].ToString();
                hk.NGAYBATDAU = DateTime.ParseExact(item["NGAYBATDAU"].ToString(), "dd/MM/yyyy", null);
                hk.NGAYKETTHUC = DateTime.ParseExact(item["NGAYKETTHUC"].ToString(), "dd/MM/yyyy", null);
                hk.THOIGIANBATDAUDUTRU = DateTime.ParseExact(item["THOIGIANBATDAUDUTRU"].ToString(), "dd/MM/yyyy", null);
                hk.THOIGIANKETTHUCDUTRU = DateTime.ParseExact(item["THOIGIANKETTHUCDUTRU"].ToString(), "dd/MM/yyyy", null);
                hk.MSNAMHOC = int.Parse(item["MSNAMHOC"].ToString());
                hk.TENNAMHOC = item["TENNAMHOC"].ToString();
                hk.TRANGTHAIHOCKY = item["TRANGTHAIHOCKY"].ToString();
                hk.TRANGTHAIDUTRU = item["TRANGTHAIDUTRU"].ToString();
                list.Add(hk);
            }
            return list;
        }

        public List<HocKyModel> KiemHocKy()
        {
            List<HocKyModel> list = new List<HocKyModel>();
            Object[] par = {
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSNAMHOC", MSNAMHOC),
                new SqlParameter("@mSKHOAHOC", DBNull.Value),
                new SqlParameter("@tENHOCKY", TENHOCKY),
                new SqlParameter("@nGAYBATDAU", DBNull.Value),
                new SqlParameter("@nGAYKETTHUC", DBNull.Value),
                new SqlParameter("@tHOIGIANBATDAUDUTRU", DBNull.Value),
                new SqlParameter("@tHOIGIANKETTHUCDUTRU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.CHECK)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_HocKy", par);
            foreach (DataRow item in dt.Rows)
            {
                HocKyModel hk = new HocKyModel();
                hk.MSHOCKY = int.Parse(item["MSHOCKY"].ToString());
                hk.MSKHOAHOC = int.Parse(item["MSKHOAHOC"].ToString());
                hk.TENHOCKY = item["TENHOCKY"].ToString();
                hk.NGAYBATDAU = DateTime.ParseExact(item["NGAYBATDAU"].ToString(), "dd/MM/yyyy", null);
                hk.NGAYKETTHUC = DateTime.ParseExact(item["NGAYKETTHUC"].ToString(), "dd/MM/yyyy", null);
                hk.THOIGIANBATDAUDUTRU = DateTime.ParseExact(item["THOIGIANBATDAUDUTRU"].ToString(), "dd/MM/yyyy", null);
                hk.THOIGIANKETTHUCDUTRU = DateTime.ParseExact(item["THOIGIANKETTHUCDUTRU"].ToString(), "dd/MM/yyyy", null);
                hk.MSNAMHOC = int.Parse(item["MSNAMHOC"].ToString());
                hk.TENNAMHOC = item["TENNAMHOC"].ToString();
                list.Add(hk);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSHOCKY", DBNull.Value),
                new SqlParameter("@mSNAMHOC", MSNAMHOC),
                new SqlParameter("@mSKHOAHOC", MSKHOAHOC),
                new SqlParameter("@tENHOCKY", TENHOCKY),
                new SqlParameter("@nGAYBATDAU", NGAYBATDAU),
                new SqlParameter("@nGAYKETTHUC", NGAYKETTHUC),
                new SqlParameter("@tHOIGIANBATDAUDUTRU", THOIGIANBATDAUDUTRU),
                new SqlParameter("@tHOIGIANKETTHUCDUTRU", THOIGIANKETTHUCDUTRU),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_HocKy", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSHOCKY", MSHOCKY),
                new SqlParameter("@mSNAMHOC", MSNAMHOC),
                new SqlParameter("@mSKHOAHOC", MSKHOAHOC),
                new SqlParameter("@tENHOCKY", TENHOCKY),
                new SqlParameter("@nGAYBATDAU", NGAYBATDAU),
                new SqlParameter("@nGAYKETTHUC", NGAYKETTHUC),
                new SqlParameter("@tHOIGIANBATDAUDUTRU", THOIGIANBATDAUDUTRU),
                new SqlParameter("@tHOIGIANKETTHUCDUTRU", THOIGIANKETTHUCDUTRU),
                new SqlParameter("@kEY", DBKey.UPDATE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_HocKy", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSHOCKY", MSHOCKY),
                new SqlParameter("@mSNAMHOC", DBNull.Value),
                new SqlParameter("@mSKHOAHOC", DBNull.Value),
                new SqlParameter("@tENHOCKY", DBNull.Value),
                new SqlParameter("@nGAYBATDAU", DBNull.Value),
                new SqlParameter("@nGAYKETTHUC", DBNull.Value),
                new SqlParameter("@tHOIGIANBATDAUDUTRU", DBNull.Value),
                new SqlParameter("@tHOIGIANKETTHUCDUTRU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_HocKy", par).Rows[0][0].ToString());
        }
    }
}