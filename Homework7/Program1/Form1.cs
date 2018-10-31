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

    public partial class Form1 : Form
    {

        public static OrderService os = new OrderService();

        public Form1()
        {
            InitializeComponent();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods Apple = new Goods(1, "Apple", 1.01);
            Goods Milk = new Goods(2, "Milk", 3.06);
            Goods Egg = new Goods(3, "Egg", 2.05);

            OrderDetail orderDetails1 = new OrderDetail(1, Apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, Egg, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, Milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            //order1.AddOrderDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);
            
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = os.orderDict.Values.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeOrder();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void DeleteRow()
        {
            try
            {
                int iCount = dataGridView1.SelectedRows.Count;
                if (DialogResult.Yes ==
                    MessageBox.Show("是否删除选中行的数据？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    os.orderDict.Remove(uint.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    dataGridView1.Rows.RemoveAt(iCount);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowDetail()
        {
            try
            {
                MessageBox.Show(os.orderDict[uint.
                    Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())]
                    .ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ChangeOrder()
        {
            try
            {
                new Form3(uint.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())).ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = os.orderDict.Values.ToList();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            GetId();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = os.QueryByGoodsName(textBox2.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = os.QueryByCustomerName(textBox3.Text);
        }

        private void GetId()
        {
            try
            {
                orderBindingSource.DataSource = os.GetById(uint.Parse(textBox1.Text));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
