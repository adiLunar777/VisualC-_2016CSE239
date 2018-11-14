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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        /*lConnection con = new SqlConnection();*/
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Student\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database1.mdf;Integrated Security = True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet6.Emp2' table. You can move, or remove it, as needed.
            this.emp2TableAdapter.Fill(this.database1DataSet6.Emp2);
            // TODO: This line of code loads data into the 'database1DataSet5.Emp1' table. You can move, or remove it, as needed.
            this.emp1TableAdapter1.Fill(this.database1DataSet5.Emp1);
            // TODO: This line of code loads data into the 'database1DataSet4.Emp1' table. You can move, or remove it, as needed.
            this.emp1TableAdapter.Fill(this.database1DataSet4.Emp1);
            // TODO: This line of code loads data into the 'database1DataSet3.Emp' table. You can move, or remove it, as needed.
            this.empTableAdapter1.Fill(this.database1DataSet3.Emp);
            // TODO: This line of code loads data into the 'database1DataSet2.Emp' table. You can move, or remove it, as needed.
            this.empTableAdapter.Fill(this.database1DataSet2.Emp);
            // TODO: This line of code loads data into the 'database1DataSet1.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter1.Fill(this.database1DataSet1.Table);
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = (Database1)\\MSSQLLocalDB;";
            string selectCommand = "SELECT * FROM dbo.[Design]";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView2.DataSource = bs;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT into Emp2 values ('"+textBoxId.Text+"','" + textBoxNOH.Text + "','"+textBoxName.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Saved");
        }

        private void labelDept_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDept_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            double mh = double.Parse(textBoxNOH.Text);
            double tsal=0;
            
            if (mh > 8)
            {
                tsal = (1500 * 8) + ((mh - 8) * 0.2 * 1500);

            }
            else if (mh < 8)
            {
                if (mh < 5)
                {
                    
                    tsal = 750;

                }
                else
                    tsal = (8 * 1500) - ((8 - mh) * 1000);


            }
            else
                tsal = 1500 * 8;
            textBoxSal.Text = Convert.ToString(tsal);
            
            cmd.CommandText = "UPDATE Emp2 SET Department ='"+textBoxSal.Text+"'Where Id='"+textBoxId.Text +"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated");
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Emp2 where Id='" + textBoxId.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void btnDisp_Click(object sender, EventArgs e)
        {
            string connectionString =@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Student\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database1.mdf; Integrated Security = True";
            string selectCommand = "SELECT Id,Department,Name FROM dbo.[Emp2]";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            ClrTB();
            
        }
        public void ClrTB()
        {
            textBoxId.Clear();
            textBoxName.Clear();
            textBoxNOH.Clear();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
