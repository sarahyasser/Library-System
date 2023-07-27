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
    public partial class AdminInfo : Form
    {
        public AdminInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection SQLconnection = new SqlConnection("Data Source=LAPTOP-IABDDTKN;Initial Catalog=MyLibrary;Integrated Security=True");
            SQLconnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = SQLconnection;
            sqlCommand.CommandText = "Update admin set salary = '"+Salary.Text+"' , HireYear = '"+HireYear.Text+"' where Admin.AdminID = (select max(AdminID)from admin )";
            sqlCommand.ExecuteNonQuery();
            SQLconnection.Close();
            MessageBox.Show("Registered!");

            this.Hide();
            
            new Admin().Show();

        }

        private void HireYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
