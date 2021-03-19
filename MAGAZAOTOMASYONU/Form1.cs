using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAGAZAOTOMASYONU
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=IREMNG; Initial Catalog =alisveris; Integrated Security = True");
        SqlCommand komut = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new SqlCommand("select*from tblyonetici where kAdi=@kadi and kSifre=@ksifre", baglanti);
            komut.Parameters.AddWithValue("@kadi", textBox1.Text);
            komut.Parameters.AddWithValue("@ksifre", textBox2.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
                MessageBox.Show("Hoşgeldin " + dr[3] + " yönetici olarak giriş yaptın.");

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı...");

            }
            baglanti.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //giriş yapan personel ise veritabanındaki personel kullanıcı adı ve şifre uyumuna göre giriş yapıyor
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            komut = new SqlCommand("select*from tblPersonel where kAdi=@kadi and kSifre=@ksifre", baglanti);
            komut.Parameters.AddWithValue("@kadi", textBox1.Text);
            komut.Parameters.AddWithValue("@ksifre", textBox2.Text); 
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                Form3 frm3 = new Form3();
                frm3.Show();
                this.Hide();
                MessageBox.Show("Hoşgeldin " + dr[2] + " personel olarak giriş yaptın.");
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı...");
            }
            baglanti.Close();


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
                textBox2.PasswordChar = '*';
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
                textBox2.PasswordChar = '*';
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            if (this.WindowState== FormWindowState.Normal) {

                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
