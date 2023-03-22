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
    public partial class add_new_user : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sri20\OneDrive\Documents\Git\IMS\IMS\inventory.mdf;Integrated Security=True");    
        public add_new_user()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration where username='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into registration values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd1.ExecuteNonQuery();
                //empty the Text boxes
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";

                MessageBox.Show("User record inserted succesfully");
            }
            else
            {
                MessageBox.Show("This username already registered please choose another");
            }
        }

        private void add_new_user_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            display();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void display()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from registration where id =" + id +"";
            cmd.ExecuteNonQuery();

            display();

        }
    }
}
