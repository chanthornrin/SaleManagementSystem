using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale_Management
{
    class connectionDB
    {
        public string MyConnnection()
        {

            string con = "Data Source=DESKTOP-9MGF6NN;Initial Catalog=Sale_Management;Integrated Security=True";

            return con;
        }
    }
}
