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
    
        public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=IREMNG; Initial Catalog =alisveris; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        

        public Form4()
        {
            InitializeComponent();
        }
        

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                komut = new SqlCommand("insert into urunbilgi0 (uAdi,uFiyat,uAdet,ubarkod,uMagz) values (@uadi,@ufiyat,@uadet,@ubarkod,@umagz)", baglanti);
                komut.Parameters.AddWithValue("@uadi", textBox1.Text);
                komut.Parameters.AddWithValue("@ufiyat", textBox2.Text);
                komut.Parameters.AddWithValue("@uadet", textBox3.Text);
                komut.Parameters.AddWithValue("@ubarkod", textBox4.Text);
                komut.Parameters.AddWithValue("@umagz", textBox5.Text);
                komut.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                baglanti.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
                MessageBox.Show("KAYDETME İŞLEMİ İÇİN VERİ GİRİŞİ YAPMADINIZ...","UYARI",MessageBoxButtons.OK);


        }

        private void Button2_Click(object sender, EventArgs e)
        {

            ds.Clear();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            da = new SqlDataAdapter("select*from urunbilgi0 order by uAdi , uAdet desc, uMagz asc ", baglanti);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (dataGridView1.CurrentRow.Selected == true)
            {
                DialogResult durum = MessageBox.Show("Silmek istediğinizden emin misiniz?", "SİLME", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    int secilen = dataGridView1.CurrentRow.Index;
                    int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                    komut = new SqlCommand("delete from urunbilgi0 where ıd='" + ID + "'", baglanti);
                    komut.ExecuteNonQuery();
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                    MessageBox.Show("ÜRÜN SİLME İŞLEMİ BAŞARILI..", "", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("İşlem iptal edildi...");
            }
            else
                MessageBox.Show("Silme işlemi için seçim yapınız...","UYARI",MessageBoxButtons.OK);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (dataGridView1.CurrentRow.Selected == true)
            {
                DialogResult durum = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "SİLME", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
                    {
                        int secilen = dataGridView1.CurrentRow.Index;
                        int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                        komut = new SqlCommand("update urunbilgi0 set uAdi=@ad,uFiyat=@fiyat,uAdet=@adet,ubarkod=@barkod,uMagz=@magz where ıd='" + ID + "'", baglanti);
                        komut.Parameters.AddWithValue("@ad", textBox1.Text);
                        komut.Parameters.AddWithValue("@fiyat", textBox2.Text);
                        komut.Parameters.AddWithValue("@adet", textBox3.Text);
                        komut.Parameters.AddWithValue("@barkod", textBox4.Text);
                        komut.Parameters.AddWithValue("@magz", textBox5.Text);
                        komut.ExecuteNonQuery();
                        dataGridView1.DataSource = dt;
                        baglanti.Close();
                        MessageBox.Show("ÜRÜN GÜNCELLEME BAŞARILI..", "", MessageBoxButtons.OK);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }
                    else
                        MessageBox.Show("Bilgileri Giriniz...", "Hata", MessageBoxButtons.OK);
                
                }
                else
                    MessageBox.Show("İşlem ipatl edildi...","İpal",MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Güncelleme işlemi için seçim yapınız...","UYARI",MessageBoxButtons.OK);

        }

        private void Button6_Click(object sender, EventArgs e)
        {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Close();
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Uygulamayı kapatmak istediğinizden emin misiniz ? ", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Application.Exit();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'alisverisDataSet4.urunbilgi0' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.urunbilgi0TableAdapter.Fill(this.alisverisDataSet4.urunbilgi0);
            


        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            if (dataGridView1.CurrentRow.Selected == true)
            {
                int secilen = dataGridView1.CurrentRow.Index;
                int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                komut = new SqlCommand("select*from urunbilgi0 where ıd='" + ID + "'", baglanti);
                da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["uAdi"].ToString();
                    textBox2.Text = dr["uFiyat"].ToString();
                    textBox3.Text = dr["uAdet"].ToString();
                    textBox4.Text = dr["ubarkod"].ToString();
                    textBox5.Text = dr["uMagz"].ToString();
                }
                else
                {
                    MessageBox.Show("ÜRÜN BULUNAMADI...", "UYARI", MessageBoxButtons.OK);
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Seçim yapınız...","UYARI",MessageBoxButtons.OK);
            }

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {

                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }
    }
}
