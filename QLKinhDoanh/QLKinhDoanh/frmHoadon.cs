using ClosedXML.Excel;
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
    public partial class frmHoadon : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
        DataTable dt = new DataTable();
        DataGridView data;
        string ngay;
        DataSet ds = new DataSet();

        public DataGridView Data { get => data; set => data = value; }
        public string Ngay { get => ngay; set => ngay = value; }

        public frmHoadon()
        {
            InitializeComponent();
        }
        public void load_User()
        {
            cn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from taikoan", cn);
            DataTable table = new DataTable();
            adapter.Fill(table);     
            lbNguoiban.Text = table.Rows[1]["Name"].ToString();          
            dt = (DataTable)dtgvHoadon.DataSource;
            lbNgayxuat.Text = Ngay;
            ds.Tables.Add(dt.Copy());
            cn.Close();
        }
        public void load_Thanhtien()
        {
            float tong = 0;
            foreach(DataRow row in dt.Rows)
            {
                int sl = Convert.ToInt32(row["Số lượng"].ToString());
                float gia = float.Parse(row["Đơn giá"].ToString());
                float tien = sl * gia;
                tong = tong + tien;
            }
            lbThanhtien.Text = Convert.ToString(tong);
        }

        private void lkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void frmHoadon_Load(object sender, EventArgs e)
        {
            dtgvHoadon.DataSource = data.DataSource;
            load_User();
            load_Thanhtien();
            //load_Hoadon();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Hoadon|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(ds);
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất hóa đơn thành công!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
