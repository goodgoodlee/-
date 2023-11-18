using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox3.SelectedIndex = 1;
            foreach (Control control in this.Controls)
            {
                // 检查控件类型是否为TextBox
                if (control is TextBox)
                {
                    // 将KeyPress事件与处理程序关联起来
                    control.KeyPress += TextBox_KeyPress;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double fullpower = double.Parse(textBox1.Text);
            double zhiyongdian = double.Parse(textBox2.Text);
            double powerfactor = double.Parse(textBox5.Text);
            int dianya = Convert.ToInt32(comboBox3.SelectedItem);
            double conveypower = fullpower * (100 - zhiyongdian) / powerfactor / 100;
            textBox3.Text = string.Format("{0:F2}",conveypower);
            double dianliu = conveypower * 1000 / Math.Sqrt(3) / dianya / powerfactor;
            textBox4.Text = string.Format("{0:F2}", dianliu);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            double fullpower = double.Parse(textBox1.Text);
            double zhiyongdian = double.Parse(textBox2.Text);
            double powerfactor = double.Parse(textBox5.Text);
            int dianya = Convert.ToInt32(comboBox3.SelectedItem);
            double conveypower = fullpower * (100 - zhiyongdian) / powerfactor / 100;
            textBox3.Text = string.Format("{0:F2}", conveypower);
            double dianliu = conveypower * 1000 / Math.Sqrt(3) / dianya / powerfactor;
            textBox4.Text = string.Format("{0:F2}", dianliu);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            //TextBox textBox = (TextBox)sender;

            //// 检查文本是否为空
            //if (textBox.Text.Length == 0)
            //{
            //    return;
            //}

            //if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.') //判断是否是数字、小数点或者退格键
            //{
            //    e.Handled = true;  //忽略非数字输入
            //}
            //else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;  //已经输入过小数点，忽略本次输入
            //}
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf('.') >= 0)
            {
                e.Handled= true;
            }
            if (e.KeyChar == 46 && ((TextBox)sender).Text == "")
            {
                e.Handled = true;
            }
            if (e.KeyChar != 46 && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
            {
                e.Handled = true;
            }
        }
    }
}
