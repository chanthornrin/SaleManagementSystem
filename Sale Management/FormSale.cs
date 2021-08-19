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
    public partial class FormSale : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        connectionDB dbcon = new connectionDB();
   
       // SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9MGF6NN;Initial Catalog=Sale_Management;Integrated Security=True");
        public FormSale()
        {
            con = new SqlConnection(dbcon.MyConnnection());
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loedRecod();
        }
        public void createSale()
        {

        }

        public void loedRecod()
        {
            int i = 0;
            DataGridView1.Rows.Clear();
            con.Open();
            cm = new SqlCommand("select * from saleDetail", con);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                DataGridView1.Rows.Add(dr["id"].ToString(), dr["customerID"].ToString(), dr["productID"].ToString(), dr["qty"].ToString(),
                                       dr["price"].ToString(), dr["subTotal"].ToString(), dr["paymentMethod"].ToString());
            }
            con.Close();
        }

        Double totalPayment = 0;
        private void Button1_Click(object sender, EventArgs e)
        {
            int qty = Convert.ToInt16(txtQty.Text);
            double price = Convert.ToDouble(txtPrice.Text);
            double subtotal = qty * price;
            con.Open();
            cm = new SqlCommand("INSERT INTO saleDetail(customerID,productID,qty,price,subTotal,paymentMethod) VALUES(@cID,@pID,@qty,@price,@subTotal,@PaymentMethod)", con);
           // cm.Parameters.AddWithValue("@cID", txtcustomerID.Text);
            cm.Parameters.AddWithValue("@pID", txtProductId.Text);
            cm.Parameters.AddWithValue("@qty", txtQty.Text);
            cm.Parameters.AddWithValue("@price", txtPrice.Text);
            cm.Parameters.AddWithValue("@subTotal", subtotal);
            cm.Parameters.AddWithValue("@PaymentMethod", cbPaymentMethod.Text);
            cm.ExecuteNonQuery();
            con.Close();

            totalPayment += subtotal;
            
            txtTotalPayment.Text = totalPayment + "";
            loedRecod();
            clearText();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }



        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = DataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("delete from saleDetail where id = '" + DataGridView1[0, e.RowIndex].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("saleDetail has been successfully delete.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loedRecod();
                    button2_Click(sender,e);
                }
            }
        }
        public void clearText()
        {
            txtProductId.Clear();
            txtPrice.Clear();
            txtQty.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   txtcustomerID.Clear();
            txtProductId.Clear();
            txtPrice.Clear();
            totalPayment = 0.0;
            txtQty.Clear();
           // txtSubTotal.Clear();
            txtTotalPayment.Clear();
            cbPaymentMethod.Text = "";
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        { }


        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                loedRecod();
            }
            if (e.KeyCode == Keys.Enter)
            {
                con.Open();
                DataGridView1.Rows.Clear();
                cm = new SqlCommand("select * from saleDetail where customerID = '" + txtSearch.Text + "'", con);
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    DataGridView1.Rows.Add(dr["id"].ToString(), dr["customerID"].ToString(), dr["productID"].ToString(), dr["qty"].ToString(),
                                           dr["price"].ToString(), dr["subTotal"].ToString(), dr["paymentMethod"].ToString());
                }
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            DataGridView1.Rows.Clear();
            cm = new SqlCommand("select * from saleDetail where id = '" + txtSearch.Text  + "'", con);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                DataGridView1.Rows.Add(dr["id"].ToString(), dr["customerID"].ToString(), dr["productID"].ToString(), dr["qty"].ToString(),
                                       dr["price"].ToString(), dr["subTotal"].ToString(), dr["paymentMethod"].ToString());
            }
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    
    }

