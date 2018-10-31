using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program1
{
    public partial class Form3 : Form
    {
        uint iCount;

        public Form3(uint i)
        {
            iCount = i;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint CustomerId = uint.Parse(textBox1.Text);
            string CustomerName = textBox2.Text;
            Customer customer = new Customer(CustomerId, CustomerName);
            Form1.os.UpdateCustomer(iCount, customer);
            Form1.orderBindingSource.DataSource = null;
            Form1.orderBindingSource.DataSource = Form1.os.orderDict.Values.ToList();
            Close();
        }
    }
}
