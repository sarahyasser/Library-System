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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection SQLconnection = new SqlConnection("Data Source=LAPTOP-IABDDTKN;Initial Catalog=MyLibrary;Integrated Security=True");
            SQLconnection.Open();
            SqlCommand sda = new SqlCommand("SELECT count(*) from LibraryUser WHERE Username = '" + Username.Text + "' AND Password = '"+Password.Text+"' ", SQLconnection);

            object obj = sda.ExecuteScalar();

            if (Convert.ToInt32(obj) != 1)
            {
                MessageBox.Show(" Wrong username or password ! ");
            }

            else
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = SQLconnection;
                sqlCommand.CommandText = "Select count(*) from LibraryUser , Admin where LibraryUser.Username = Admin.Username AND Admin.Username = '" + Username.Text+"' ";
                sqlCommand.ExecuteNonQuery();

                obj = sqlCommand.ExecuteScalar();

                SQLconnection.Close();

                if (Convert.ToInt32(obj) == 1)
                {
                    this.Hide();
                    new Admin().Show();
                }
                else
                {
                    this.Hide();
                    new Student().Show();
                }

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
