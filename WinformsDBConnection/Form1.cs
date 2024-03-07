using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinformsDBConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string connectionstring = "server=localhost;port=3306;uid=root;" + "pwd=Irpt@1110;database=practice";
            MySqlConnection con = new MySqlConnection(connectionstring);
            try
            {
                con.Open();
                string commandString = "Select * from expenses;";

                using (MySqlCommand command = new MySqlCommand(commandString, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Not Established");
            }

            dataGridView1.DataSource = table;
        }

    }
}
