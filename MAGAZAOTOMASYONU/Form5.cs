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
    public partial class Form5 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=IREMNG; Initial Catalog =alisveris; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public Form5()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "")
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                komut = new SqlCommand("insert into tblPersonel values (@ptc,@padi,@padres,@ptel,@pmagz,@kAdi,@kSifre)", baglanti);
                komut.Parameters.AddWithValue("@ptc", textBox1.Text);
                komut.Parameters.AddWithValue("@padi", textBox2.Text);
                komut.Parameters.AddWithValue("@padres", textBox3.Text);
                komut.Parameters.AddWithValue("@ptel", textBox4.Text);
                komut.Parameters.AddWithValue("@pmagz", textBox5.Text);
                komut.Parameters.AddWithValue("@kAdi", textBox6.Text);
                komut.Parameters.AddWithValue("@kSifre", textBox7.Text);
                komut.ExecuteNonQuery();
                dataGridView1.DataSource = dt;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                MessageBox.Show("personelin kullanıcı adı : " + textBox6.Text + "\n personelin şifresi : " + textBox7.Text, "", MessageBoxButtons.OK);
                textBox6.Text = "";
                textBox7.Text = "";
                MessageBox.Show("Personel Kaydedildi..", "", MessageBoxButtons.OK);
                baglanti.Close();
            }
            else
                MessageBox.Show("Personel bilgilerini giriniz...");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (dataGridView1.CurrentRow.Selected == true)
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "")
                {
                    int secilen = dataGridView1.CurrentRow.Index;
                    int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                    komut = new SqlCommand("update tblPersonel set pTc=@tc,pAdi=@adi,pAdres=@adres,pTel=@tel,pMagz=@magz,kAdi=@kAdi,kSifre=@kSifre where ıd='" + ID + "'", baglanti);
                    komut.Parameters.AddWithValue("@textbox8tc", textBox8.Text);
                    komut.Parameters.AddWithValue("@tc", textBox1.Text);
                    komut.Parameters.AddWithValue("@adi", textBox2.Text);
                    komut.Parameters.AddWithValue("@adres", textBox3.Text);
                    komut.Parameters.AddWithValue("@tel", textBox4.Text);
                    komut.Parameters.AddWithValue("@magz", textBox5.Text);
                    komut.Parameters.AddWithValue("@kAdi", textBox6.Text);
                    komut.Parameters.AddWithValue("@kSifre", textBox7.Text);
                    komut.ExecuteNonQuery();
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    baglanti.Close();
                    MessageBox.Show("Personel Güncellendi..", "GÜNCELLENDİ", MessageBoxButtons.OK);
                    MessageBox.Show("Personelin Yeni Kullanıcı Adı : " + textBox6.Text + "\n Personelin Yeni Şifresi : " + textBox7.Text, "", MessageBoxButtons.OK);
                    textBox6.Text = "";
                    textBox7.Text = "";
                    dt.Clear();
                }
                else
                    MessageBox.Show("Bilgileri giriniz...", "Hata", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Seçim yapınız...");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            ds.Clear();
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            da = new SqlDataAdapter("select*from tblPersonel", baglanti);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (dataGridView1.CurrentRow.Selected == true)
            {
                int secilen = dataGridView1.CurrentRow.Index;
                int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                komut = new SqlCommand("select*from tblPersonel where ıd='"+ID+"'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    DialogResult durum = MessageBox.Show("Personeli Silmek İstediğinizden Emin misiniz ? ", "", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        komut = new SqlCommand("delete from tblPersonel where ıd='"+ID+"'", baglanti);
                        komut.ExecuteNonQuery();
                        dt.Clear();
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Personel silindi...", "", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("İşlem İpatl Edildi");
                }
                else
                    MessageBox.Show("Personel Bulunamadı...");
            }
            else
                MessageBox.Show("Silmek istediğiniz personeli seçiniz...");
            baglanti.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();

            if (dataGridView1.CurrentRow.Selected == true)
            {
                int secilen = dataGridView1.CurrentRow.Index;
                int ID = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
                komut = new SqlCommand("select*from tblPersonel where ıd='" + ID + "'", baglanti);
                da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["pTc"].ToString();
                    textBox2.Text = dr["pAdi"].ToString();
                    textBox3.Text = dr["pAdres"].ToString();
                    textBox4.Text = dr["pTel"].ToString();
                    textBox5.Text = dr["pMagz"].ToString();
                    textBox6.Text = dr["kAdi"].ToString();
                    textBox7.Text = dr["kSifre"].ToString();
                }
                else
                {
                    MessageBox.Show("PERSONEL BULUNAMADI...", "", MessageBoxButtons.OK);
                }
                baglanti.Close();
            }
            else
                MessageBox.Show("Seçim yapınız...", "UYARI", MessageBoxButtons.OK);
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            if (textBox8.Text.Trim() != "")
            {
                dt.Clear();
                da = new SqlDataAdapter("select*from tblPersonel ", baglanti);
                da.Fill(dt);
                DataView dv = new DataView(dt);
                dv.RowFilter = "pTc like '%" + textBox8.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            else
            {
                dt.Clear();
            }
            baglanti.Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Uygulamayı kapatmak istediğinizden Emin misiniz ? ", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Application.Exit();

            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Close();

            
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'alisverisDataSet4.tblPersonel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblPersonelTableAdapter.Fill(this.alisverisDataSet4.tblPersonel);

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
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
