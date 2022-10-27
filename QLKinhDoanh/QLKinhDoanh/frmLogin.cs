using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKinhDoanh
{
    public partial class frmLogin : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        SqlDataAdapter da;
        int t = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool OK = false;
            SqlDataReader rdr = null;
            
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from taikoan", cn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ((txtUsername.Text.Trim() == rdr["Username"].ToString().Trim()) && (txtPassword.Text.Trim() == rdr["Password"].ToString().Trim()))
                    {
                        OK = true;
                        if (Convert.ToInt32(rdr["type"].ToString().Trim()) == 1)
                        {
                            t = 1;                        
                        }
                        else
                            t = 2;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL!");
                return;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (cn != null)
                {
                    cn.Close();
                }
            }
            if (OK == false)
                MessageBox.Show("Tên đăng nhập/Mật khẩu không hợp lệ");
            else
            {
                if(t==1)
                {
                    frmAdmin f = new frmAdmin();
                    f.ShowDialog();
                }
                else
                {
                    frmStaff f = new frmStaff();
                    f.ShowDialog();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
