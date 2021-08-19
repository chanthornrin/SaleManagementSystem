using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale_Management
{
    public partial class DashBoardForm : Form
    {
        public DashBoardForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelShow.Text = "Sale Management";
            setBackColorSale();
            FormSale frm = new FormSale();
            frm.TopLevel = false;
            panelDisplay.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelShow.Text = "Product Mangement";
            setBackColorDashProduct();
            FormProduct frm = new FormProduct();
            frm.TopLevel = false;
            panelDisplay.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setBackColorEmployee();
            labelShow.Text = "Employee Mangement";
            FormEmployee frm = new FormEmployee();
            frm.TopLevel = false;
            panelDisplay.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setBackColorRegisterUser();
            labelShow.Text = "Register User";
            FormRegister_User frm =new FormRegister_User();
            frm.TopLevel = false;
            panelDisplay.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        public void setBackColorDashBoard()
        {
            btnDashBoard.BackColor = Color.MediumBlue;
            btnProduct.BackColor = Color.Blue;
            btnSale.BackColor = Color.Blue;
            btnEmployee.BackColor = Color.Blue;
            btnRegister.BackColor = Color.Blue;
        }
        public void setBackColorDashProduct()
        {
            btnDashBoard.BackColor = Color.Blue;
            btnProduct.BackColor = Color.MediumBlue;
            btnSale.BackColor = Color.Blue;
            btnEmployee.BackColor = Color.Blue;
            btnRegister.BackColor = Color.Blue;
        }
        public void setBackColorSale()
        {
            btnDashBoard.BackColor = Color.Blue;
            btnProduct.BackColor = Color.Blue;
            btnSale.BackColor = Color.MediumBlue;
            btnEmployee.BackColor = Color.Blue;
            btnRegister.BackColor = Color.Blue;
        }
        public void setBackColorEmployee()
        {
            btnDashBoard.BackColor = Color.Blue;
            btnProduct.BackColor = Color.Blue;
            btnSale.BackColor = Color.Blue;
            btnEmployee.BackColor = Color.MediumBlue;
            btnRegister.BackColor = Color.Blue;
        }
        public void setBackColorRegisterUser()
        {
            btnDashBoard.BackColor = Color.Blue;
            btnProduct.BackColor = Color.Blue;
            btnSale.BackColor = Color.Blue;
            btnEmployee.BackColor = Color.Blue;
            btnRegister.BackColor = Color.MediumBlue;
        }
        private void panelShow_Paint(object sender, PaintEventArgs e)
        {
            setBackColorDashBoard();
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            setBackColorDashBoard();
            labelShow.Text = "DashBoard";
        }
    }
}
