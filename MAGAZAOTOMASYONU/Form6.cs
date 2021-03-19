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
    public partial class Form6 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=IREMNG; Initial Catalog =alisveris; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public Form6()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            dt.Clear();
            da = new SqlDataAdapter("select sum(urunfiyat) from tblsayac", baglanti); 
            da.Fill(dt);
            //SqlDataAdapter da2 = new SqlDataAdapter("select count(*) as 'Toplam Kayıtlı Ürün Sayısı' from urunbilgi0", baglanti);
            //da2.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "TOPLAM KAR";
            
            baglanti.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Close();        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Çıkış yapmak istediğinizden Emin misiniz ? ", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Close();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
