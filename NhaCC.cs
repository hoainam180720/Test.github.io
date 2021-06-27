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

namespace WindowsFormsApp1
{
    public partial class NhaCC : Form
    {
        public NhaCC()
        {
            InitializeComponent();
        }
        string ketnoi = @"Data Source=DESKTOP-VC895HM\SQLEXPRESS;Initial Catalog = QTDA; Integrated Security = True;";
        public void HienThi()
        {
            SqlConnection con = new SqlConnection(ketnoi);
            SqlCommand cmd = new SqlCommand("select * from NHACC order by MAncc asc", con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet set = new DataSet();
            adapter.Fill(set, "S");
            dataGridView1.DataSource = set.Tables["S"];

        }

        private void NhaCC_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ketnoi);
            try
            {
                con.Open();
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into NHACC values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')", con);
                    int kq = (int)cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Them thanh cong!");
                        HienThi();
                    }
                    else
                        MessageBox.Show("Them that bai!");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi!" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ketnoi);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update NHACC set TENNCC ='" + textBox2.Text + "',LIENHE ='" + textBox3.Text + "' where MANCC ='" + textBox1.Text + "'", con);
                int kq = (int)cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sua thanh cong!");
                    HienThi();
                }
                else
                    MessageBox.Show("Sua that bai!");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi!" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ketnoi);
            SqlCommand cmd = new SqlCommand("select * from NHACC where MANCC=@mancc", con);
            con.Open();
            cmd.Parameters.AddWithValue("mancc", textBox5.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
        }
    }
}
