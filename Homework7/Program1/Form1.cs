using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.XPath;

namespace Program1
{

    public partial class Form1 : Form
    {

        public static OrderService os = new OrderService();

        public Form1()
        {
            InitializeComponent();
            
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = os.QueryAllOrders();
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
                    os.RemoveOrder(dataGridView1.CurrentRow.Cells[0].Value.ToString());
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
                MessageBox.Show(os.GetById(dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToString());
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
                new Form3(dataGridView1.CurrentRow.Cells[0].Value.ToString()).ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = os.QueryAllOrders();
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
                orderBindingSource.DataSource = os.GetById(textBox1.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            os.Export(os.GetById(dataGridView1.CurrentRow.Cells[0].Value.ToString()), 
                "out" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + ".xml");
            XmlTextWriter writer = null;
            try
            {
                //声明XslTransform类实例
                XmlDocument doc = new XmlDocument();
                doc.Load("out" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + ".xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load("../../trans.xslt");

                FileStream outFileStream = File.OpenWrite("out" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + ".html");
                writer = new XmlTextWriter(outFileStream, Encoding.UTF8);
                xt.Transform(nav, null, writer);
                MessageBox.Show("Order"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"创建html文件成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"创建html失败：{ex.Message}");
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
