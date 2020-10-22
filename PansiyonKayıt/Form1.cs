using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonKayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin" && textBox2.Text=="123456")
            {
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız, lütfen kullanıcı adı veya şifrenizi düzeltiniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Substring(1) + textBox3.Text.Substring(0, 1);
        }
    }
}
