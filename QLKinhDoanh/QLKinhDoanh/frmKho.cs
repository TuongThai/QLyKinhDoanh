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
    public partial class frmKho : Form
    {
        SqlDataAdapter da;
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        DataSet ds;
        BUS_Kho busKho = new BUS_Kho();
        BUS_LoaiSP busSP = new BUS_LoaiSP();
        BUS_NSX busNSX = new BUS_NSX();
        public frmKho()
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
        public void loadSP()
        {
            string sql = "select * from LoaiSanPham";
            da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "Sanpham");
            cbLoaisp.DataSource = ds.Tables["Sanpham"];
            cbLoaisp.DisplayMember = "LoaiSP";
            cbLoaisp.ValueMember = "MaLoai";
        }
        public void loadNSX()
        {
            string sql = "select * from NhaSanXuat";
            da = new SqlDataAdapter(sql, cn);
            da.Fill(ds, "Nhasx");
            cbNhasx.DataSource = ds.Tables["Nhasx"];
            cbNhasx.DisplayMember = "TenNSX";
            cbNhasx.ValueMember = "MaNSX";
        }
        public int get_idSP(string sp)
        {
            cn.Open();
            string sql = string.Format("select MaLoai from LoaiSanPham where LoaiSP = '{0}'", sp);
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = int.Parse(rdr["MaLoai"].ToString().Trim());
                cn.Close();
                return id;
            }
            return 0;
        }
        public int get_idNSX(string nsx)
        {
            cn.Open();
            string sql = string.Format("select MaNSX from NhaSanXuat where TenNSX = '{0}'", nsx);
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = int.Parse(rdr["MaNSX"].ToString().Trim());
                cn.Close();
                return id;
            }
            return 0;
        }
        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvData.CurrentCell.RowIndex;
            txtTensp.Text = dtgvData.Rows[i].Cells[3].Value.ToString();
            txtGia.Text = dtgvData.Rows[i].Cells[6].Value.ToString();
            txtSoluong.Text = dtgvData.Rows[i].Cells[7].Value.ToString();
            cbLoaisp.Text = dtgvData.Rows[i].Cells[4].Value.ToString();
            cbNhasx.Text = dtgvData.Rows[i].Cells[5].Value.ToString();
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            dtgvData.DataSource = busKho.getKho();
            this.dtgvData.Columns["Makho"].Visible = false;
            this.dtgvData.Columns["MaLoai"].Visible = false;
            this.dtgvData.Columns["MaNSX"].Visible = false;
            loadSP();
            loadNSX();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTensp.Text != "" && txtSoluong.Text != "" && txtGia.Text != "")
            {
                int id_sp = get_idSP(cbLoaisp.Text);
                int id_nsx = get_idNSX(cbNhasx.Text);
                DTO_Kho kho = new DTO_Kho(0, id_sp, id_nsx, txtTensp.Text, cbLoaisp.Text, cbNhasx.Text, float.Parse(txtGia.Text), Convert.ToInt32(txtSoluong.Text));
                if (busKho.themKho(kho))
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
                if (txtTensp.Text != "" && txtSoluong.Text != "" && txtGia.Text != "")
                {
                    int i = dtgvData.CurrentCell.RowIndex;
                    int id = Convert.ToInt32(dtgvData.Rows[i].Cells[0].Value.ToString());
                    int id_sp = get_idSP(cbLoaisp.Text);
                    int id_nsx = get_idNSX(cbNhasx.Text);
                    DTO_Kho kh = new DTO_Kho(id, id_sp, id_nsx, txtTensp.Text, cbLoaisp.Text, cbNhasx.Text, float.Parse(txtGia.Text), Convert.ToInt32(txtSoluong.Text));
                    if (busKho.suaKho(kh))
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
                MessageBox.Show("Hãy chọn vị trí cần sửa");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentCell.RowIndex >= 0)
            {
                int i = dtgvData.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dtgvData.Rows[i].Cells[0].Value.ToString());
                if (busKho.xoaKho(id))
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
            dtgvData.DataSource = busKho.getKho();
            txtTensp.Clear();
            txtGia.Clear();
            txtSoluong.Clear();
            cbLoaisp.SelectedIndex = 0;
            cbNhasx.SelectedIndex = 0;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
        }

        private void btnLoaihang_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmLoaiHang f = new frmLoaiHang();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
