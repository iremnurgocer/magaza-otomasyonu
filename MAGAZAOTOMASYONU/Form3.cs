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
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=IREMNG; Initial Catalog =alisveris; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            int sayac = 0;
            if (dataGridView1.CurrentRow.Selected == true)
            {
                sayac++;
                int secilen = dataGridView1.CurrentRow.Index;
                int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                int adet = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[3].Value.ToString())-1;
                int fiyat = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[2].Value.ToString());
                string barkod = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                DialogResult durum = MessageBox.Show("Ürünü Satmak İstediğinizden Emin misiniz ? ", "", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    komut = new SqlCommand("update urunbilgi0 set uAdet=" +adet+ " where ıd=" + ID + "", baglanti);
                    komut.ExecuteNonQuery();
                    komut = new SqlCommand("insert into tblsayac (urunbarkod,urunfiyat) values (@urunbarkod,@urunfiyat) ", baglanti);
                    komut.Parameters.AddWithValue("@urunbarkod", barkod);
                    komut.Parameters.AddWithValue("@urunfiyat", fiyat);
                    komut.ExecuteNonQuery();
                    dt.Clear();
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Ürün satıldı...", "", MessageBoxButtons.OK);
                    MessageBox.Show("KAR:" + fiyat, "KAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                    MessageBox.Show("işlem İpatl edildi");
                
            }
            else
                MessageBox.Show("Satmak istediğiniz ürünü seçiniz...","UYARI",MessageBoxButtons.OK);
            baglanti.Close();
        }
        
        private void Button3_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (dataGridView1.CurrentRow.Selected == true)
            {
                int secilen = dataGridView1.CurrentRow.Index;
                int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                int adet = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[3].Value.ToString()) + 1;
                int fiyat = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[2].Value.ToString());
                string barkod = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                DialogResult durum = MessageBox.Show("Ürünü iade etmek İstediğinizden Emin misiniz ? ", "", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    komut = new SqlCommand("update urunbilgi0 set uAdet=" + adet + " where ıd=" + ID + "", baglanti);
                    komut.ExecuteNonQuery();
                    komut = new SqlCommand("insert into tblsayac (urunbarkod,urunfiyat) values (@barkod,@fiyat) ", baglanti);
                    komut.Parameters.AddWithValue("@barkod", barkod);
                    komut.Parameters.AddWithValue("@fiyat", fiyat*(-1));
                    komut.ExecuteNonQuery();
                    dt.Clear();
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Ürün Eklendi...", "", MessageBoxButtons.OK);
                    MessageBox.Show("İade edilecek tutar:" + fiyat, "İade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("işlem İpatl edildi");

            }
            else
                MessageBox.Show("İadesini İstediğiniz Ürünü Seçiniz...","UYARI",MessageBoxButtons.OK);
            baglanti.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ds.Clear();
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() == "")
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string barkod = textBox1.Text;
                da = new SqlDataAdapter("select*from urunbilgi0 where ubarkod like '%" + barkod + "%'", baglanti);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }
            else if (textBox2.Text.Trim() != "" && textBox1.Text.Trim() == "")
            {

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string adi = textBox2.Text;
                da = new SqlDataAdapter("select*from urunbilgi0 where uAdi like'%" + adi + "%'", baglanti);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }
            else if (textBox2.Text.Trim() != "" && textBox1.Text.Trim() != "")
            {

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string barkod = textBox1.Text;
                string adi = textBox2.Text;
                da = new SqlDataAdapter("select*from urunbilgi0 where uAdi like '%" + adi + "%' and ubarkod like '%" + barkod + "%'", baglanti);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Doğru bilgi girdiğinize emin olunuz! ");
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz ? ", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Close();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Uygulamayı kapatmak istediğinizden emin misiniz ? ", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Application.Exit();
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            ds.Clear();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            da = new SqlDataAdapter("select*from urunbilgi0 order by uAdi , uAdet desc, uMagz asc ", baglanti);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'alisverisDataSet4.urunbilgi0' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.urunbilgi0TableAdapter.Fill(this.alisverisDataSet4.urunbilgi0);
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click_1(object sender, EventArgs e)
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
    }
}
