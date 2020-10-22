using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PansiyonKayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=EREN\\SQLEXPRESS;Integrated Security=True;Initial Catalog=Pansiyon");
        private void verileriGoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Pansiyon.dbo.Musteri ", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Giris"].ToString());
                ekle.SubItems.Add(oku["Cikis"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());

                listView1.Items.Add(ekle);
               
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();
        }
        private void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = " ";
            textBox5.Clear();
            textBox6.Clear();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Pansiyon.dbo.Musteri(id,Ad,Soyad,OdaNo,Giris,Cikis,Telefon,Hesap) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();

            komut.CommandText= "Insert into Pansiyon.dbo.doluoda(doluyerler) values('" + comboBox1.Text.ToString()+"')";
            komut.ExecuteNonQuery();
            komut.CommandText = ("Delete from Pansiyon.dbo.bosoda where bosyerler='" + comboBox1.Text.ToString() + "' ");
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
            Temizle();
        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Pansiyon.dbo.Musteri where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();

            komut.CommandText = "Insert into Pansiyon.dbo.bosoda(bosyerler) values('" + comboBox1.Text.ToString() + "')";
            komut.ExecuteNonQuery();
            komut.CommandText= ("Delete from Pansiyon.dbo.doluoda where doluyerler='"+comboBox1.Text.ToString()+"' ");
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
            Temizle();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update Pansiyon.dbo.Musteri set id='" + textBox1.Text.ToString() + "',Ad='" + textBox2.Text.ToString() + "',Soyad='" + textBox3.Text.ToString() + "',OdaNo='" + comboBox1.Text.ToString() + "',Giris='" + dateTimePicker1.Text.ToString() + "',Cikis='" + dateTimePicker2.Text.ToString() + "',Telefon='" + textBox5.Text.ToString() + "',Hesap='" + textBox6.Text.ToString() + "'where id=" + id + " ", baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoster();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Pansiyon.dbo.Musteri where Ad like '%"+textBox7.Text+"%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Giris"].ToString());
                ekle.SubItems.Add(oku["Cikis"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());

                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Pansiyon.dbo.bosoda", baglan);
            SqlDataReader oda = komut.ExecuteReader();
            while(oda.Read())
            {
                comboBox1.Items.Add(oda[0].ToString());
              
            }
            baglan.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
