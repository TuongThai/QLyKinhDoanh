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
    public partial class frmAdmin : Form
    {
        BUS_Taikhoan busTK = new BUS_Taikhoan();
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder builder;
        public frmAdmin()
        {
            InitializeComponent();
            load_User();
        }
        public void load_User()
        {
            cn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from taikoan", cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            lbUser.Text = "Admin: " + table.Rows[0]["Name"].ToString();
            cn.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
        /*public void loadState()
        {
            string sql = "select * from taikoan";
            da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "Tinhtrang");
            cbLoai.DataSource = ds.Tables["Tinhtrang"];
            cbLoai.DisplayMember = "State";
            cbLoai.ValueMember = "Username";
        }*/

        public void loadData()
        {
            string sql = "select * from taikoan";
            da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "taikhoan");
            dtgvTaikhoan.DataSource = ds.Tables["taikhoan"];
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            cbLoai.SelectedIndex = 0;
            loadData();
            builder = new SqlCommandBuilder(da);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (cbLoai.Text == "Quản Lý")
            {              
                DataTable dt = ds.Tables["taikhoan"];
                DataRow r = dt.NewRow();
                r[0] = txtUsername.Text;
                r[1] = txtpass.Text;
                r[2] = txtName.Text;
                r[3] = cbLoai.SelectedItem.ToString();
                r[4] = 1;
                dt.Rows.Add(r);
                //Cập nhật dữ liệu từ Dataset xuống Database
                da.Update(ds, "taikhoan");
                MessageBox.Show("Đã thêm");
            }
            else
            {
                DataTable dt = ds.Tables["taikhoan"];
                DataRow r = dt.NewRow();
                r[0] = txtUsername.Text;
                r[1] = txtpass.Text;
                r[2] = txtName.Text;
                r[3] = cbLoai.SelectedItem.ToString();
                r[4] = 2;
                dt.Rows.Add(r);
                //Cập nhật dữ liệu từ Dataset xuống Database
                da.Update(ds, "taikhoan");
                MessageBox.Show("Đã thêm");
            }
            cn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = dtgvTaikhoan.CurrentCell.RowIndex;
            if (i >= 0)
            {
                if (cbLoai.Text == "Quản Lý")
                {
                    DataTable dt = ds.Tables["taikhoan"];
                    DataRow r = dt.Rows[i];
                    r[0] = txtUsername.Text;
                    r[1] = txtpass.Text;
                    r[2] = txtName.Text;
                    r[3] = cbLoai.SelectedItem.ToString();
                    r[4] = 1;
                }
                else
                {
                    DataTable dt = ds.Tables["taikhoan"];
                    DataRow r = dt.Rows[i];
                    r[0] = txtUsername.Text;
                    r[1] = txtpass.Text;
                    r[2] = txtName.Text;
                    r[3] = cbLoai.SelectedItem.ToString();
                    r[4] = 2;
                }
                da.Update(ds, "taikhoan");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rd = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo);
            if(rd == DialogResult.Yes)
            {
                int i = dtgvTaikhoan.CurrentCell.RowIndex;
                DataTable dt = ds.Tables["taikhoan"];
                dt.Rows[i].Delete();
                da.Update(ds, "taikhoan");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dtgvTaikhoan.DataSource = ds.Tables["taikhoan"];
            txtUsername.Clear();
            txtpass.Clear();
            txtName.Clear();
            cbLoai.SelectedIndex = 0;
        }
        private void dtgvTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvTaikhoan.CurrentCell.RowIndex;
            txtUsername.Text = dtgvTaikhoan.Rows[i].Cells[0].Value.ToString();
            txtpass.Text = dtgvTaikhoan.Rows[i].Cells[1].Value.ToString();
            txtName.Text = dtgvTaikhoan.Rows[i].Cells[2].Value.ToString();
            cbLoai.Text = dtgvTaikhoan.Rows[i].Cells[3].Value.ToString();
        }

        private void btnNhacungcap_Click(object sender, EventArgs e)
        {
            this.Close();
            frmNhacungcap f = new frmNhacungcap();
            f.ShowDialog();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            this.Close();
            frmKho f = new frmKho();
            f.ShowDialog();
        }

        private void btnLoaihang_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLoaiHang f = new frmLoaiHang();
            f.ShowDialog();
        }
        private void btnThongke_Click(object sender, EventArgs e)
        {
            this.Close();
            frmThongke f = new frmThongke();
            f.ShowDialog();
        }
    }
}
