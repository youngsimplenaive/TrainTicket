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

namespace WindowsFormsApplication1
{
    public partial class welcome : Form
    {
        private string user;

        public welcome(string text)
        {
            user = text;
            InitializeComponent();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void welcome_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();


            SqlConnection mcon1 = new SqlConnection();
            mcon1.ConnectionString = @"Data Source=CZL;Initial Catalog=train;Integrated Security=true";
            mcon1.Open();
            string sql1 = "select * from [user] where [username]='" + user + "'";
            SqlDataAdapter oleada = new SqlDataAdapter(sql1, mcon1);//
            SqlCommandBuilder olebuid = new SqlCommandBuilder(oleada);
            DataSet ds = new DataSet();
            oleada.Fill(ds, "用户");
            BindingSource bind = new BindingSource();
            bind.DataSource = ds.Tables["用户"];
            label6.DataBindings.Add("Text", bind, "name");
            label6.Text += "，您好！！";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Show();
            label4.Show();
            label5.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ticket ticket = new ticket(user);
            ticket.Show();
        }
    }
}
