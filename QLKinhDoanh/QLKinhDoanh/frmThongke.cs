using BUS_QuanLy;
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
    public partial class frmThongke : Form
    {
        BUS_Hoadon bushd = new BUS_Hoadon();
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        public frmThongke()
        {
            InitializeComponent();
        }

        private void btnDetailThongke_Click(object sender, EventArgs e)
        {
            string ngay = dtpkNgay.Value.ToString();
            dtgvData.DataSource = bushd.getTheongay(ngay);
        }

        private void frmThongke_Load(object sender, EventArgs e)
        {
            dtgvData.DataSource = bushd.getHoadon();
            load_User();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
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

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKho f = new frmKho();
            f.ShowDialog();
        }

        private void btnLoaihang_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoaiHang f = new frmLoaiHang();
            f.ShowDialog();
        }

        private void btnNhacungcap_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhacungcap f = new frmNhacungcap();
            f.ShowDialog();
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvData.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dtgvData.Rows[i].Cells[0].Value.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bushd.xoaHD(id);
            }
            else return;
            dtgvData.DataSource = bushd.getHoadon();
        }
    }
}
