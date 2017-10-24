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
    public class ChucVuModel : iChucVu
    {
        public int MSCHUCVU { get; set; }
        public string TENCHUCVU { get; set; }

        public ChucVuModel()
        {
        }

        public ChucVuModel(int mSCHUCVU, string tENCHUCVU)
        {
            MSCHUCVU = mSCHUCVU;
            TENCHUCVU = tENCHUCVU;
        }

        public List<ChucVuModel> DanhSach()
        {
            List<ChucVuModel> list = new List<ChucVuModel>();
            Object[] par = {
                new SqlParameter("@mSCHUCVU", DBNull.Value),
                new SqlParameter("@tENCHUCVU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_ChucVu", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new ChucVuModel(
                            int.Parse(item["MSCHUCVU"].ToString()),
                            item["TENCHUCVU"].ToString()
                        ));
            }
            return list;
        }

        public int Them()
        {
            Object[] par = {
                new SqlParameter("@mSCHUCVU", DBNull.Value),
                new SqlParameter("@tENCHUCVU", this.TENCHUCVU),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_ChucVu", par).Rows[0][0].ToString());
        }

        public int Xoa()
        {
            Object[] par = {
                new SqlParameter("@mSCHUCVU", this.MSCHUCVU),
                new SqlParameter("@tENCHUCVU", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_ChucVu", par).Rows[0][0].ToString());
        }

        public int CapNhat()
        {
            Object[] par = {
                new SqlParameter("@mSCHUCVU", this.MSCHUCVU),
                new SqlParameter("@tENCHUCVU", this.TENCHUCVU),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_ChucVu", par).Rows[0][0].ToString());
        }

        public List<ChucVuModel> KiemTraChucVu()
        {
            List<ChucVuModel> list = new List<ChucVuModel>();
            Object[] par = {
                new SqlParameter("@mSCHUCVU", this.MSCHUCVU),
                new SqlParameter("@tENCHUCVU", this.TENCHUCVU),
                new SqlParameter("@kEY", DBKey.CHECK),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_ChucVu", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new ChucVuModel(
                            int.Parse(item["MSCHUCVU"].ToString()),
                            item["TENCHUCVU"].ToString()
                        ));
            }
            return list;
        }
    }
}