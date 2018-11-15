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
    public partial class Form2 : Form
    {

        public List<OrderDetail> GoodDetails = new List<OrderDetail>();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AddDetail();
        }

        private void AddDetail()
        {
            try
            {
                uint[] id = { 1, 2, 3 };
                string[] goods = { "Apple", "Mlik", "Egg" };
                double[] value = { 1.01, 3.06, 2.05 };
                uint detailId = uint.Parse(textBox1.Text);
                uint gid = (uint)comboBox1.SelectedIndex;
                uint quantity = uint.Parse(textBox2.Text);
                Goods a = new Goods(id[gid], goods[gid], value[gid]);
                OrderDetail orderDetail = new OrderDetail(detailId, a, quantity);
                GoodDetails.Add(orderDetail);
                detailBindingSource.DataSource = null;
                detailBindingSource.DataSource = GoodDetails;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrder();
        }

        private void AddOrder()
        {
            try
            {
                string orderId = textBox5.Text;
                string pattern = "^[0-9]{4}((0([1-9]))|(1(0|1|2)))((0[1-9]|([1-2][0-9])|3[0-1]))[0-9]{3}$";
                if (!Regex.IsMatch(orderId, pattern))
                {
                    throw new OrderIdException("订单号格式错误");
                }
                uint customerId = uint.Parse(textBox3.Text);
                string customerName = textBox4.Text;
                string customerPhone = textBox6.Text;
                string pattern2 = "1[0-9]{10}$";
                if (!Regex.IsMatch(customerPhone, pattern2))
                {
                    throw new OrderIdException("手机号格式错误");
                }
                Customer a = new Customer(customerId,customerName,customerPhone);
                Order order = new Order(orderId, a)
                {
                    details = GoodDetails
                };
                Form1.os.AddOrder(order);
                Form1.orderBindingSource.DataSource = null;
                Form1.orderBindingSource.DataSource = Form1.os.orderDict.Values.ToList();
                Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
