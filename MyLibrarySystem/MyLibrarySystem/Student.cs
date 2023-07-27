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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myLibraryDataSet.Author' table. You can move, or remove it, as needed.
            this.authorTableAdapter.Fill(this.myLibraryDataSet.Author);
            // TODO: This line of code loads data into the 'myLibraryDataSet.Book_Categories' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'myLibraryDataSet.Book' table. You can move, or remove it, as needed.



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection SQLconnection = new SqlConnection("Data Source=LAPTOP-IABDDTKN;Initial Catalog=MyLibrary;Integrated Security=True");
            SQLconnection.Open();
           
            SqlCommand sda = new SqlCommand("SELECT count(*) from Book WHERE title LIKE '%" +title.Text+ "%';", SQLconnection);
            
            object obj = sda.ExecuteScalar();
            if (Convert.ToInt32(obj) >= 1)
            {
                //string name=sele;
               // sda=new SqlCommand("select")
                SqlCommand cmd=new SqlCommand("Select book.title, book.book_ID,book.price,book.language,Author.Author_name from book,Author where title LIKE '%" + title.Text + "%';", SQLconnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Book_Categories where Book_ID IN (Select Book_ID from Book where title LIKE '%" + title.Text + "%');", SQLconnection);
                SqlDataAdapter db = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                db.Fill(dt2);
                dataGridView2.DataSource = dt2;


                /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
            }
            else MessageBox.Show("This book doesn't exist in our library!");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.bookTableAdapter.Fill(this.myLibraryDataSet.Book);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
