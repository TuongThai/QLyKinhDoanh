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
    public partial class frmLoaiHang : Form
    {
        BUS_LoaiSP busSP = new BUS_LoaiSP();
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        public frmLoaiHang()
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text != "")
            {
                DTO_LoaiSP sp = new DTO_LoaiSP(0, txtTenSP.Text);
                if (busSP.themSP(sp))
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentCell.RowIndex >= 0)
            {
                if (txtTenSP.Text != "")
                {
                    int i = dtgvData.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(dtgvData.Rows[i].Cells[0].Value.ToString());
                    DTO_LoaiSP sp = new DTO_LoaiSP(id, txtTenSP.Text);
                    if (busSP.suaSP(sp))
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn sản phẩm muốn sửa");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentCell.RowIndex >= 0)
            {
                int i = dtgvData.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dtgvData.Rows[i].Cells[0].Value.ToString());
                if (busSP.xoaSP(id))
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn thành viên muốn xóa");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dtgvData.DataSource = busSP.getSP();
            txtTenSP.Clear();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmKho f = new frmKho();
            f.ShowDialog();
        }

        private void btnNhacungcap_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmNhacungcap f = new frmNhacungcap();
            f.ShowDialog();
        }
        private void btnThongke_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmThongke f = new frmThongke();
            f.ShowDialog();
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            dtgvData.DataSource = busSP.getSP();
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvData.CurrentCell.RowIndex;
            txtTenSP.Text = dtgvData.Rows[i].Cells[1].Value.ToString();
        }

        private void lkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
