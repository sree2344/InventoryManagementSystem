using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IMS
{
    public partial class unit : Form
    {
        SqlConnection con=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sri20\OneDrive\Documents\Git\IMS\IMS\inventory.mdf;Integrated Security=True");
        public unit()
        {
            InitializeComponent();
        }

        private void unit_Load(object sender, EventArgs e)
        {
            if (con.State==ConnectionState.Open)
            { 
                con.Close(); 
            }
            con.Open();
        }

        public void disp()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from units";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into units values('"+ textBox1.Text +"')";
            cmd.ExecuteNonQuery();
        }


    }
}
