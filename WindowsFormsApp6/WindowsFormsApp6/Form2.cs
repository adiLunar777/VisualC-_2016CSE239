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
using System.IO;

namespace WindowsFormsApp6
{
   
    public partial class Form2 : Form
    {
        byte[] l;
        SqlDataAdapter dataAdapter;
        BindingSource bs = new BindingSource();
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\VisualC-_2016CSE239\WindowsFormsApp6\WindowsFormsApp6\Database1.mdf;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.Register1' table. You can move, or remove it, as needed.
            this.register1TableAdapter2.Fill(this.database1DataSet3.Register1);
            // TODO: This line of code loads data into the 'database1DataSet2.Register1' table. You can move, or remove it, as needed.
            this.register1TableAdapter1.Fill(this.database1DataSet2.Register1);
            // TODO: This line of code loads data into the 'database1DataSet1.Register1' table. You can move, or remove it, as needed.
            this.register1TableAdapter.Fill(this.database1DataSet1.Register1);
            // TODO: This line of code loads data into the 'database1DataSet.Register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.database1DataSet.Register);

        }
        public void load()
        {
            dataAdapter = new SqlDataAdapter("Select * from Register1", con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;

        }

        public void clr()
        {
            tb_id.Clear();
            tb_name.Clear();
            tb_sec.Clear();
            tb_branch.Clear();
            tb_dob.Clear();
            textBox5.Clear();
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;

            }

        }

      

        private void btn_reg_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            
           
            cmd1.CommandType = CommandType.Text;
            byte[] mypic = File.ReadAllBytes(openFileDialog1.FileName);
            cmd1.CommandText = "insert into Register1 values('" + tb_id.Text + "','" + tb_name.Text + "','" + tb_sec.Text + "','" + tb_branch.Text + "',@pic,'"+tb_dob.Text+"')";
            SqlParameter sq = new SqlParameter("@pic", SqlDbType.VarBinary, mypic.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, mypic);
            cmd1.Parameters.Add(sq);
            cmd1.ExecuteNonQuery();

           
            /*catch (Exception e1)
            {

                MessageBox.Show("Check for Valid inputs");

            }*/
            con.Close();
            MessageBox.Show("Registered Succesfully");
            clr();
            load();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            clr();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Profile from Register1 where Id='" + tb_id.Text + "'", con);
            DataTable d = new DataTable();
            da.Fill(d);
            Byte[] p = new byte[0];
            p = (byte[])d.Rows[0][0];

            MemoryStream ms = new MemoryStream(p);
            pictureBox1.Image = Image.FromStream(ms);

            con.Close();
        }
    }
}
