using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_NSX : DBConnect
    {
        public DataTable getNSX()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NhaSanXuat", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool themNSX(DTO_NhaSX nsx)
        {
            try
            {
                conn.Open();
                string sql = string.Format("insert into NhaSanXuat(TenNSX,Diachi)values('{0}','{1}')", nsx.TenNSX, nsx.DiaChi);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }catch(Exception e) { }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool suaNSX(DTO_NhaSX nsx)
        {
            try
            {
                conn.Open();
                string sql = string.Format("update NhaSanXuat set TenNSX='{0}', Diachi='{1}' where MaNSX='{2}'",nsx.TenNSX,nsx.DiaChi,nsx.Id_Nhasx);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e) { }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool xoaNSX(int id)
        {
            try
            {
                conn.Open();
                string sql = string.Format("delete from NhaSanXuat where MaNSX='{0}'",id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e) { }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
