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

namespace WindowsFormsApp6
{
   
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Student\source\repos\WindowsFormsApp6\WindowsFormsApp6\Database1.mdf;Integrated Security = True");

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Register1' table. You can move, or remove it, as needed.
            this.register1TableAdapter.Fill(this.database1DataSet1.Register1);
            // TODO: This line of code loads data into the 'database1DataSet.Register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.database1DataSet.Register);

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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
