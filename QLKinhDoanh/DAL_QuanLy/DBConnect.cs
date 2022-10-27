using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DBConnect
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-S2H0P8JC\SQLEXPRESS;Initial Catalog=QLKD;Integrated Security=True");
    }
}
