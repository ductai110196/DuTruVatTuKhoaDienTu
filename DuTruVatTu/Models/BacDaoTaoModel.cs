using DuTruVatTu.Database;
using DuTruVatTu.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DuTruVatTu.Models
{
    public class BacDaoTaoModel : iBacDaoTao
    {
        public int MSBACDAOTAO { get; set ; }
        public string TENBACDAOTAO { get; set ; }

        public BacDaoTaoModel()
        {
        }

        public BacDaoTaoModel(int mSBACDAOTAO, string tENBACDAOTAO)
        {
            MSBACDAOTAO = mSBACDAOTAO;
            TENBACDAOTAO = tENBACDAOTAO;
        }

        public List<BacDaoTaoModel> DanhSach()
        {
            List<BacDaoTaoModel> list = new List<BacDaoTaoModel>();
            Object[] par = {
                new SqlParameter("@mSBACDAOTAO", DBNull.Value),
                new SqlParameter("@tENBACDAOTAO", DBNull.Value),
                new SqlParameter("@kEY", DBKey.SELECT),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_BacDaoTao", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new BacDaoTaoModel(
                            int.Parse(item["MSBACDAOTAO"].ToString()),
                            item["TENBACDAOTAO"].ToString()
                        ));
            }
            return list;
        }

        public List<BacDaoTaoModel> KiemTraBacDaoTao()
        {
            List<BacDaoTaoModel> list = new List<BacDaoTaoModel>();
            Object[] par = {
                new SqlParameter("@mSBACDAOTAO", this.MSBACDAOTAO),
                new SqlParameter("@tENBACDAOTAO", this.TENBACDAOTAO),
                new SqlParameter("@kEY", DBKey.CHECK),
            };
            DataTable dt = DBConnect.SqlStoredProcedure("sp_BacDaoTao", par);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new BacDaoTaoModel(
                            int.Parse(item["MSBACDAOTAO"].ToString()),
                            item["TENBACDAOTAO"].ToString()
                        ));
            }
            return list;
        }

        public int ThemBacDaoTao()
        {
            Object[] par = {
                new SqlParameter("@mSBACDAOTAO", this.MSBACDAOTAO),
                new SqlParameter("@tENBACDAOTAO", this.TENBACDAOTAO),
                new SqlParameter("@kEY", DBKey.INSERT),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_BacDaoTao", par).Rows[0][0].ToString());
        }

        public int XoaBacDaoTao()
        {
            Object[] par = {
                new SqlParameter("@mSBACDAOTAO", this.MSBACDAOTAO),
                new SqlParameter("@tENBACDAOTAO", DBNull.Value),
                new SqlParameter("@kEY", DBKey.DELETE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_BacDaoTao", par).Rows[0][0].ToString());
        }

        public int CapNhatBacDaoTao()
        {
            Object[] par = {
                new SqlParameter("@mSBACDAOTAO", this.MSBACDAOTAO),
                new SqlParameter("@tENBACDAOTAO", this.TENBACDAOTAO),
                new SqlParameter("@kEY", DBKey.UPDATE),
            };
            return int.Parse(DBConnect.SqlStoredProcedure("sp_BacDaoTao", par).Rows[0][0].ToString());
        }
    }
}