using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Program1
{
    public partial class Form3 : Form
    {
        string iCount;

        public Form3(string i)
        {
            iCount = i;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint CustomerId = uint.Parse(textBox1.Text);
            string CustomerName = textBox2.Text;
            string CustomerPhone = textBox3.Text;
            string pattern2 = "1[0-9]{10}$";
            if (!Regex.IsMatch(CustomerPhone, pattern2))
            {
                throw new OrderIdException("手机号格式错误");
            }
            Customer customer = new Customer(CustomerId, CustomerName,CustomerPhone);
            Form1.os.UpdateCustomer(iCount, customer);
            Form1.orderBindingSource.DataSource = null;
            Form1.orderBindingSource.DataSource = Form1.os.orderDict.Values.ToList();
            Close();
        }
    }
}
