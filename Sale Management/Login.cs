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

namespace Sale_Management
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
         connectionDB dbcon = new connectionDB();

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9MGF6NN;Initial Catalog=Sale_Management;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnnection());
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string query = "select * from Login WHERE username = @username and password=@password";

            con.Open();

            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.Parameters.AddWithValue("@username", txtusername.Text);
            sqlcmd.Parameters.AddWithValue("@password", txtpassword.Text);
            DataTable dtbl = new DataTable();

            SqlDataAdapter sqlsda = new SqlDataAdapter(sqlcmd);
            sqlsda.Fill(dtbl);

            con.Close();

            if (dtbl.Rows.Count == 1)
            {
               
                new FormSale().Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invalid username or password");
        }

    }

    }

