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
    public class GiangVienModel : iChucVu, iGiangVien
    {
        public int MSCHUCVU { get; set; }
        public string TENCHUCVU { get; set; }
        public int MSGIANGVIEN { get; set; }
        public string MAGIANGVIEN { get; set; }
        public string TENGIANGVIEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }

        public GiangVienModel()
        {
        }

        public GiangVienModel( int mSGIANGVIEN)
        {
            MSGIANGVIEN = mSGIANGVIEN;
        }

        public GiangVienModel(int mSCHUCVU, int mSGIANGVIEN, string mAGIANGVIEN, 
            string tENGIANGVIEN, DateTime nGAYSINH, string gIOITINH)
        {
            MSGIANGVIEN = mSGIANGVIEN;
            MAGIANGVIEN = mAGIANGVIEN;
            TENGIANGVIEN = tENGIANGVIEN;
            NGAYSINH = nGAYSINH;
            GIOITINH = gIOITINH;
            MSCHUCVU = mSCHUCVU;
        }

        public List<GiangVienModel> DanhSach()
        {
            List<GiangVienModel> list = new List<GiangVienModel>();
            Object[] par = {
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@mSCHUCVU", DBNull.Value),
                new SqlParameter("@mAGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENGIANGVIEN", DBNull.Value),
                new SqlParameter("@nGAYSINH", DBNull.Value),
                new SqlParameter("@gIOITINH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT)
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_GiangVien", par);
            foreach (DataRow item in dt.Rows)
            {
                GiangVienModel gv = new GiangVienModel();
                gv.MSCHUCVU = int.Parse(item["MSCHUCVU"].ToString());
                gv.TENCHUCVU = item["TENCHUCVU"].ToString();
                gv.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                gv.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                gv.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                gv.NGAYSINH = DateTime.ParseExact(item["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                gv.GIOITINH = item["GIOITINH"].ToString();
                list.Add(gv);
            }
            return list;
        }

        public List<GiangVienModel> KiemTra()
        {
            List<GiangVienModel> list = new List<GiangVienModel>();
            Object[] par = {
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@mSCHUCVU", DBNull.Value),
                new SqlParameter("@mAGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENGIANGVIEN", DBNull.Value),
                new SqlParameter("@nGAYSINH", DBNull.Value),
                new SqlParameter("@gIOITINH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_GiangVien", par);
            foreach (DataRow item in dt.Rows)
            {
                GiangVienModel gv = new GiangVienModel();
                gv.MSCHUCVU = int.Parse(item["MSCHUCVU"].ToString());
                gv.TENCHUCVU = item["TENCHUCVU"].ToString();
                gv.MSGIANGVIEN = int.Parse(item["MSGIANGVIEN"].ToString());
                gv.MAGIANGVIEN = item["MAGIANGVIEN"].ToString();
                gv.TENGIANGVIEN = item["TENGIANGVIEN"].ToString();
                gv.NGAYSINH = DateTime.ParseExact(item["NGAYSINH"].ToString(), "dd/MM/yyyy", null);
                gv.GIOITINH = item["GIOITINH"].ToString();
                list.Add(gv);
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSGIANGVIEN", DBNull.Value),
                new SqlParameter("@mSCHUCVU", MSCHUCVU),
                new SqlParameter("@mAGIANGVIEN", MAGIANGVIEN),
                new SqlParameter("@tENGIANGVIEN", TENGIANGVIEN),
                new SqlParameter("@nGAYSINH", NGAYSINH),
                new SqlParameter("@gIOITINH", GIOITINH),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_GiangVien", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@mSCHUCVU", MSCHUCVU),
                new SqlParameter("@mAGIANGVIEN", MAGIANGVIEN),
                new SqlParameter("@tENGIANGVIEN", TENGIANGVIEN),
                new SqlParameter("@nGAYSINH", NGAYSINH),
                new SqlParameter("@gIOITINH", GIOITINH),
                new SqlParameter("@kEY", DBKey.INSERT)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_GiangVien", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSGIANGVIEN", MSGIANGVIEN),
                new SqlParameter("@mSCHUCVU", DBNull.Value),
                new SqlParameter("@mAGIANGVIEN", DBNull.Value),
                new SqlParameter("@tENGIANGVIEN", DBNull.Value),
                new SqlParameter("@nGAYSINH", DBNull.Value),
                new SqlParameter("@gIOITINH", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE)
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_GiangVien", par).Rows[0][0].ToString());
        }
    }
}