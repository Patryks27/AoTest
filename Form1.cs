using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ao11
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imie = Imie.Text;
            string nazwisko = Nazwisko.Text;
            string email = Email.Text;
            string uczelnia = Uczelnia.Text;

            if(string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(uczelnia))
            {
                Error.Visible = true;
            }
            else
            {
                //zapis do bazy danych
                Error.Visible = false;

                this.Hide();
                string SQLConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|database.mdf;Integrated Security=True";// @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='database.mdf';Integrated Security=True";
                SqlConnection conn2;
                conn2 = new SqlConnection();
                conn2.ConnectionString = SQLConnection;


                string value = String.Format("'{0}', '{1}', '{2}', '{3}'", imie, nazwisko, email, uczelnia);

                //string sqlCmd = @"INSERT INTO Users ( Imie, Nazwisko, Email, Uczelnia)" + value;
                //                " + "VALUES('{0}', '{1}', '{2}', '{3}')",imie, nazwisko, email, uczelnia;

                string query = "EXEC  ADDUSER "+ value;//(@imie, @nazwisko, @email, @uczelnia)";

                using (SqlCommand command = new SqlCommand(query, conn2))
                {
                    //command.Parameters.AddWithValue("@imie", imie);
                    //command.Parameters.AddWithValue("@nazwisko", nazwisko);
                    //command.Parameters.AddWithValue("@email", email);
                    //command.Parameters.AddWithValue("@uczelnia", uczelnia);
                    conn2.Open();
                    command.ExecuteNonQuery();
                }


                //SqlDataReader reader = command.ExecuteReader();

                //try
                //{
                //    reader.me
                //    while (reader.Read())
                //    {

                //         MessageBox.Show(  reader[""].ToString());
                //    }
                //}
                //finally
                //{
                //    // Always call Close when done reading.
                //    reader.Close();
                //}
                conn2.Close();


                AddFormularzView newView = new AddFormularzView();
                newView.BringToFront();
                newView.Show();
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = openFileDialog1.FileName;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
