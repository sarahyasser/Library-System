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

namespace MyLibrarySystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection SQLconnection = new SqlConnection("Data Source=LAPTOP-IABDDTKN;Initial Catalog=MyLibrary;Integrated Security=True");
            SQLconnection.Open();
            SqlCommand sda = new SqlCommand("SELECT count(*) from LibraryUser WHERE Username = '" + Username.Text + "'", SQLconnection);


            object obj = sda.ExecuteScalar();

            if (Type.Text != "admin" && Type.Text != "student")
                MessageBox.Show("Invalid Type\n Type must be (admin or student)");
            else

            {

                if (Convert.ToInt32(obj) == 1)
                {
                    MessageBox.Show("Taken username!");
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                }
                else if(Type.Text == "admin")
                {

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = SQLconnection;
                    sqlCommand.CommandText = "INSERT INTO LibraryUser Values('" + Username.Text + "','" + Password.Text + "','" + FirstName.Text + "','" + LastName.Text + "','" + Address.Text + "','" + Phone.Text + "','" + Birth.Text + "','" + Gender.Text + "')";
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "INSERT INTO admin Values('" + Username.Text + "','" + 0 + "','" + 0 + "')";
                    sqlCommand.ExecuteNonQuery();
                    this.Hide();
                    new AdminInfo().Show();

                    SQLconnection.Close();
                           

                }
                else
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = SQLconnection;
                    sqlCommand.CommandText = "INSERT INTO LibraryUser Values('" + Username.Text + "','" + Password.Text + "','" + FirstName.Text + "','" + LastName.Text + "','" + Address.Text + "','" + Phone.Text + "','" + Birth.Text + "','" + Gender.Text + "')";
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand.CommandText = "INSERT INTO Student(Username,Faculty) Values('" + Username.Text + "','" + null + "')";
                    sqlCommand.ExecuteNonQuery();
                    this.Hide();
                    new StudentInfo().Show();

                    SQLconnection.Close();
                }

            }
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Type_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
