using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_Taikhoan : DBConnect
    {
        public DataTable getTaikhoan()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from taikoan", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool themTaikhoan(DTO_Taikhoan tk)
        {
            try
            {
                conn.Open();
                string sql = string.Format("insert into taikoan(Username,Password,Name,State,Type)values('{0}','{1}','{2}','{3}','{4}')", tk.Username, tk.Password, tk.Name, tk.State, tk.Type);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }catch(Exception e)
            {
                
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool suaTaikhoan(DTO_Taikhoan tk)
        {
            try
            {
                conn.Open();
                string sql = string.Format("update taikoan set Username='{0}',Password='{1}',Name='{2}',State='{3}',Type='{4}' where Username = '{5}'", tk.Username, tk.Password, tk.Name, tk.State, tk.Type, tk.Username);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool xoaTaikhoan(string user)
        {
            try
            {
                conn.Open();
                string sql = string.Format("delete from taikoan where Username = '{0}'",user);
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

    }
}
