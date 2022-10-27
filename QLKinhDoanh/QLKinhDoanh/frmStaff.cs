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
    public partial class frmStaff : Form
    {
        int vt, soluong, vtorder, t=0, loai;
        SqlDataAdapter da;
        DataSet ds;
        public DataTable dt = new DataTable();
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        BUS_Kho busKho = new BUS_Kho();
        BUS_Hoadon busHD = new BUS_Hoadon();
        public frmStaff()
        {
            InitializeComponent();
            load_User();
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load_User()
        {
            cn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from taikoan", cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            lbUser.Text = table.Rows[1]["Name"].ToString();
            cn.Close();
        }
        public void load()
        {
            dtgvSanPham.DataSource = busKho.getKho();
            this.dtgvSanPham.Columns["MaLoai"].Visible = false;
            this.dtgvSanPham.Columns["MaNSX"].Visible = false;
            this.dtgvSanPham.Columns["LoaiSP"].Visible = false;
            this.dtgvSanPham.Columns["TenNSX"].Visible = false;
        }
        
        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = dtgvSanPham.CurrentCell.RowIndex;
            lbTenSP.Text = dtgvSanPham.Rows[vt].Cells[3].Value.ToString();
            soluong = Convert.ToInt32(dtgvSanPham.Rows[vt].Cells[7].Value.ToString());
        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtgvOrder.ColumnCount == 0)
            {
                dt.Columns.Add("Tên SP");
                dt.Columns.Add("Đơn giá");
                dt.Columns.Add("Số lượng");
                dtgvOrder.DataSource = dt;
            }
            if (nbSoluong.Value > soluong)
            {
                MessageBox.Show("Vui lòng nhập số lượng nhỏ hơn số lượng có trong kho", "Error", MessageBoxButtons.OKCancel);
            }
            else
            {
                try
                {
                    dt = dtgvOrder.DataSource as DataTable;
                    if (dt != null)
                    {
                        if (dt.Rows.Count == 0) {
                            DataRow row = dt.NewRow();
                            row["Tên SP"] = lbTenSP.Text;
                            row["Đơn giá"] = dtgvSanPham.Rows[vt].Cells[6].Value.ToString();
                            row["Số lượng"] = nbSoluong.Value.ToString();
                            dt.Rows.Add(row);
                        }
                        else 
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["Tên SP"].ToString() == lbTenSP.Text)
                                {
                                    t = t + ((int)nbSoluong.Value);
                                    dr["Số lượng"] = t;
                                    break;
                                }
                                else
                                {
                                    DataRow r = dt.NewRow();
                                    r["Tên SP"] = lbTenSP.Text;
                                    r["Đơn giá"] = dtgvSanPham.Rows[vt].Cells[6].Value.ToString();
                                    r["Số lượng"] = nbSoluong.Value.ToString();
                                    dt.Rows.Add(r);
                                }
                            }
                        }
                    }
                }
                catch (Exception databaseException)
                {
                    MessageBox.Show(databaseException.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("select * from Kho where TenSP Like N'%{0}'", txtTim.Text.Trim());
                da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgvSanPham.DataSource = dt;
                this.dtgvSanPham.Columns["MaLoai"].Visible = false;
                this.dtgvSanPham.Columns["MaNSX"].Visible = false;
                this.dtgvSanPham.Columns["LoaiSP"].Visible = false;
                this.dtgvSanPham.Columns["TenNSX"].Visible = false;
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                dtgvOrder.Rows.RemoveAt(vtorder);
            else
                return;
        }

        private void dtgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vtorder = dtgvOrder.CurrentCell.RowIndex;
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            dt = (DataTable)dtgvOrder.DataSource;
            hoadon();
            frmHoadon f = new frmHoadon();
            f.Data = dtgvOrder;
            f.Ngay = dtpkNgay.Value.ToString();
            if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cn.Open();
                foreach (DataRow row in dt.Rows)
                {
                    int sl = Convert.ToInt32(row["Số lượng"].ToString());
                    string ten = row["Tên SP"].ToString();
                    string sql = string.Format("Update Kho set soluong = soluong - '{0}' where TenSP = '{1}'", sl, ten);
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.ExecuteNonQuery();
                }
                cn.Close();                
                f.ShowDialog();
                dt.Rows.Clear();
            }
            else return;
        }
        public void hoadon()
        {
            float tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                int sl = Convert.ToInt32(row["Số lượng"].ToString());
                float gia = float.Parse(row["Đơn giá"].ToString());
                float tien = sl * gia;
                tong = tong + tien;
            }
            dtpkNgay.Value = DateTime.Today;
            string ngay = dtpkNgay.Value.ToString();
            DTO_Hoadon dto_hd = new DTO_Hoadon(0,ngay,lbUser.Text,tong);
            busHD.themHD(dto_hd);
        }
    }
}
