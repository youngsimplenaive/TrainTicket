using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ilogin : Form
    {
        private string verifyCode;

        public ilogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ilogin_Load(object sender, EventArgs e)
        {

            Code code = new Code();
            verifyCode = code.CheckCode();//将verifyCode声明为全局的string对象，以便其它方法使用。。
            Bitmap image = code.DrawVerifyCodePicture(verifyCode);
            pictureBox1.Image = image;
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
            this.label10.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool registerflag = false;
            bool nameflag = false;
            SqlConn con = new SqlConn();
            string sql = "select username from [User]";
            SqlDataReader dr;
            dr = con.GetDataReader(sql);
            while (dr.Read())
            {
                if (textBox4.Text.Trim() == dr["username"].ToString().Trim())
                {
                    nameflag = true;//该用户名在数据库中已经存在
                }

            }
            dr.Close();





            if (textBox4.Text == null || textBox5.Text == null || textBox6.Text == null || textBox7.Text == null || textBox8.Text == null)
            {
                MessageBox.Show("内容不能为空！", "提示信息");
            }
            else if (6 > textBox5.Text.Trim().Length || textBox5.Text.Trim().Length > 14)
            {
                MessageBox.Show("请输入6--14位的密码", "提示信息");
            }
            else if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("密码输入不一致", "提示信息");
            }
            else if (textBox4.Text.Trim().Length > 20)
            {
                MessageBox.Show("用户名长度应小于20个字符！", "提示信息");
            }
            else if (nameflag == true)
            {
                label10.Text = "该用户名在数据库中已经存在！";
                label10.Show();
            }
            else
            {
                registerflag = true;//允许注册
                label10.Hide();
            }

            string passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(textBox5.Text.Trim(), "md5");
           
   
            if (registerflag == true)
            {
                string sql2 = "insert into [User](username,password,name,phone,status) values ('" + textBox4.Text.Trim() + "','" + passWord + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + comboBox1.SelectedItem.ToString() + "')";
                int i = con.ExecuteSQL(sql2);
                if (i >= 1)
                {
                    MessageBox.Show("注册成功！", "信息");
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    this.Close();

                }
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, password;
            string sql = "select [username],[password] from [User]";
            SqlConn con = new SqlConn();
            SqlDataReader dr;
            dr = con.GetDataReader(sql);

            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null)
            {
                MessageBox.Show("填入信息禁止为空！", "信息提示");
            }

            else
            {
                bool flag = false;
                while (dr.Read())//遍历dr
                {
                    name = dr["username"].ToString();
                    password = dr["password"].ToString();
                    string passWord = FormsAuthentication.HashPasswordForStoringInConfigFile(textBox2.Text.Trim(), "md5");

                    if (name.Trim() == this.textBox1.Text.Trim() && password.Trim() == passWord)
                    {
                        flag = true;  //true时表示登录输入正确
                    }

                }
                dr.Close();
                con.close();

                if (flag == true)
                {
                    bool i = (textBox3.Text.ToUpper() == verifyCode.ToUpper());
                    if (i == false)
                    {
                        MessageBox.Show("验证码输入错误！", "信息提示");
                        textBox3.Clear();
                        textBox3.Focus();
                        Code code = new Code();
                        verifyCode = code.CheckCode();//将verifyCode声明为全局的string对象，以便其它方法使用。。
                        Bitmap image = code.DrawVerifyCodePicture(verifyCode);
                        pictureBox1.Image = image;
                        pictureBox1.Height = image.Height;
                        pictureBox1.Width = image.Width;
                    }
                    else
                    {
                        MessageBox.Show("登录成功！", "信息提示");
                        welcome welcome = new welcome(this.textBox1.Text);
                        welcome.Show();

                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！", "错误提示");
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    this.textBox3.Clear();
                    this.textBox1.Focus();
                    Code code = new Code();
                    verifyCode = code.CheckCode();//将verifyCode声明为全局的string对象，以便其它方法使用。。
                    Bitmap image = code.DrawVerifyCodePicture(verifyCode);
                    pictureBox1.Image = image;
                    pictureBox1.Height = image.Height;
                    pictureBox1.Width = image.Width;

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
