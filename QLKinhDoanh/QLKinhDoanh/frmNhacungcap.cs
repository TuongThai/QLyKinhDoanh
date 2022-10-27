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
    public partial class frmNhacungcap : Form
    {
        BUS_NSX busNSX = new BUS_NSX();
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        public frmNhacungcap()
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
            if(txtTenncc.Text != "" && txtDiachincc.Text != "")
            {
                DTO_NhaSX nsx = new DTO_NhaSX(0, txtTenncc.Text, txtDiachincc.Text);
                if (busNSX.themNSX(nsx))
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
            if(dtgvData.CurrentCell.RowIndex >= 0)
            {
                if(txtTenncc.Text != "" && txtDiachincc.Text != "")
                {
                    int i = dtgvData.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(dtgvData.Rows[i].Cells[0].Value.ToString());
                    DTO_NhaSX nsx = new DTO_NhaSX(id, txtTenncc.Text, txtDiachincc.Text);
                    if (busNSX.suaNSX(nsx))
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
                MessageBox.Show("Hãy chọn thành viên muốn sửa");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dtgvData.CurrentCell.RowIndex >= 0)
            {
                int i = dtgvData.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dtgvData.Rows[i].Cells[0].Value.ToString());
                if (busNSX.xoaNSX(id))
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
            dtgvData.DataSource = busNSX.getNSX();
            txtTenncc.Clear();
            txtDiachincc.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void frmNhacungcap_Load(object sender, EventArgs e)
        {
            dtgvData.DataSource = busNSX.getNSX();
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

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvData.CurrentCell.RowIndex;
            txtTenncc.Text = dtgvData.Rows[i].Cells[1].Value.ToString();
            txtDiachincc.Text = dtgvData.Rows[i].Cells[2].Value.ToString();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
        }
    }
}
