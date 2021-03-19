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
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=IREMNG; Initial Catalog =alisveris; Integrated Security = True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Hide();

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //satılan ve iade edilen ürüne göre
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Çıkış Yapmak İstediğinizden Emin misiniz ? ", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Uygulamayı kapatmak istediğinizden emin misiniz ? ", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Application.Exit();
            }
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
