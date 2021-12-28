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

namespace CustomerAddressBook
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Doc\source\repos\CustomerAddressBook\CustomerAddressBook\RecordDatabase.mdf;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        int ID = 0;
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }
        
        //Display Data in DataGridView  
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from CustomerRecords", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data  
        private void ClearData()
        {
            textName.Text = "";
            textEmail.Text = "";
            textState.Text = "";
            ID = 0;
        }
        //Search and display data
        private void SearchData()
        {
            if (textSearch.Text != "")
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from CustomerRecords where State=" + "'" + textSearch.Text + "'", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            else
            {
                MessageBox.Show("No Search Data Entered!");
                DisplayData();
            }
                
        }

               
        //Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
            textSearch.Text = "";
        }

        //Add Item
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" && textEmail.Text != "" && textState.Text != "")
            {
                cmd = new SqlCommand("insert into CustomerRecords(Name,Email,State) values(@name,@email,@state)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", textName.Text);
                cmd.Parameters.AddWithValue("@email", textEmail.Text);
                cmd.Parameters.AddWithValue("@state", textState.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Added!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Missing Details!");
            }
        }

        //Modify Item
        private void button1_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" && textEmail.Text != "" && textState.Text != "")
            {
                cmd = new SqlCommand("update CustomerRecords set Name=@name,Email=@email,State=@state where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", textName.Text);
                cmd.Parameters.AddWithValue("@email", textEmail.Text);
                cmd.Parameters.AddWithValue("@state", textState.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Modified!");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select Record to Modify");
            }
        }

        //Delete Item
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete CustomerRecords where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select Record to Delete");
            }
        }

        //Select Data to Modify or Delete
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textState.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
