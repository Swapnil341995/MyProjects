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


namespace Telephone
{
    public partial class Phone : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=mydb;Integrated Security=True;Pooling=False");
        public Phone()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Phone_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into mobile(FirstName,LastName,Mobile,Email,Category)" +
                " values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+ "','" + textBox4.Text + "','" + comboBox1.Text + "')", con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Entered data is successfully saved !!!");
            Display();
        }

        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Mobile",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach(DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Mobile where (Mobile = '" + textBox3.Text+"')", con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Data is deleted successfully !!!");
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Mobile set FirstName = '"+textBox1.Text+ "',LastName = '"+textBox2.Text+ "',Email = '"+textBox3.Text+ "',Category = '" + comboBox1.Text + "' " +
                "where (Mobile = '"+textBox3.Text+"') ", con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Data is updated successfully !!!");
            Display();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Mobile where (Mobile like '%"+textBox5.Text+"%') or (FirstName like '%"+textBox5.Text+"%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["FirstName"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }
    }
}
