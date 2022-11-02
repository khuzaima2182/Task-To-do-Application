using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_To_do_Application
{
    public partial class Form1 : Form
    {
        string task_type, task_level;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if(radioButton1.Checked == true)
            {
                task_type = "Home Task";
            }
            else if(radioButton2.Checked == true)
            {
                task_type = "University Task";
            }

            if (radioButton4.Checked == true)
            {
                task_level = "Important";
            }
            else if (radioButton3.Checked == true)
            {
                task_level = "Normal";
            }
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\source\repos\Task To-do Application\Task To-do Application\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Insert into HomeTask(Task_Title,Task_Description,Task_Type,Task_deadline,Task_Level) Values('" + textBox1.Text+"','"+richTextBox1.Text+"','"+task_type+"','"+dateTimePicker1.Text+"','"+task_level+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Data Inserted Successfully");
            }
            else if(i == 0)
            {
                MessageBox.Show("Data Not Inserted");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\source\repos\Task To-do Application\Task To-do Application\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from HomeTask", con);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(connection);
            sdt.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                task_type = "Home Task";
            }
            else if (radioButton2.Checked == true)
            {
                task_type = "University Task";
            }
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\source\repos\Task To-do Application\Task To-do Application\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Task_Title,Task_Description,Task_Type,Task_deadline,Task_Level from HomeTask where Task_Type ='University Task'", con);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(connection);
            sdt.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                task_type = "Home Task";
            }
            else if (radioButton2.Checked == true)
            {
                task_type = "University Task";
            }
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\source\repos\Task To-do Application\Task To-do Application\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Task_Title,Task_Description,Task_Type,Task_deadline,Task_Level from HomeTask where Task_Type ='Home Task'", con);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(connection);
            sdt.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                task_level = "Important";
            }
            else if (radioButton3.Checked == true)
            {
                task_level = "Normal";
            }
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\source\repos\Task To-do Application\Task To-do Application\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Task_Title,Task_Description,Task_Type,Task_deadline,Task_Level from HomeTask where Task_Level ='Important'", con);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(connection);
            sdt.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                task_level = "Important";
            }
            else if (radioButton3.Checked == true)
            {
                task_level = "Normal";
            }
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\source\repos\Task To-do Application\Task To-do Application\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Task_Title,Task_Description,Task_Type,Task_deadline,Task_Level from HomeTask where Task_Level ='Normal'", con);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(connection);
            sdt.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\source\repos\Task To-do Application\Task To-do Application\Database1.mdf"";Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (SqlCommand cmd = new SqlCommand("Delete HomeTask where Id =@id", con))
            {
                cmd.Parameters.AddWithValue("@id", textBox2.Text);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    label9.Text = "Deleted Succesfully";

                }
                else if (i == 0)
                {
                    label9.Text = "Aborted";
                }
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
