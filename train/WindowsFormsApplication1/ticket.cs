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
    public partial class ticket : Form
    {
        string user;

        private SqlDataAdapter adapter = null;
        private SqlCommand cmd = null;
        private DataSet dSet = null;
        public ticket(string text)
        {
            InitializeComponent();
            user = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("请选择出发地和目的地");
            }
            if ((textBox1.Text == "" && textBox2.Text != "") || (textBox2.Text == "" && textBox1.Text != ""))
            {
                MessageBox.Show("出发站和目的站两者中其一不能为空!!!!");
            }
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string sql = "select [车次],[出发站],[到达站],[出发时间],[到达时间],[历时],[余票],[票价] from [ticket] ";
                string sql1 = "[出发站] ='" + textBox1.Text + "' and [到达站] ='" + textBox2.Text + "'and [出发日] ='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
                sql = sql + "where" + sql1;
                string str = @"Data Source = CZL;Initial Catalog = train;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                cmd = new SqlCommand(sql, con);
                adapter = new SqlDataAdapter(cmd);
                dSet = new DataSet();
                //填充数据集DataSet
                adapter.Fill(dSet, "ticket");
                dataGridView1.DataSource = dSet.Tables["ticket"];
            }
        }

        private void ticket_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rows = dataGridView1.CurrentRow.Index;
            string[] str = new string[10];
            for(int i = 0; i<8;i++)
            {
                str[i]= dataGridView1.Rows[rows].Cells[i].Value.ToString();
            }
            int num = Convert.ToInt32(str[6]);
            if (num<= 0)
            {
                MessageBox.Show("该票已售完，请选择其他车次");
            }
            else
            {

                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定提交订单吗?", "购票成功", messButton);

                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    
                        num = num - 1;
                        int bianhao = 20170101;
                        bianhao = bianhao + 1;
                        
                        string date = DateTime.Now.ToLocalTime().ToString();

                        SqlConn con = new SqlConn();
                        string sql5 = "select [name] from [User] where [username]='" + user + "'";

                        SqlDataReader sdr;
                        sdr = con.GetDataReader(sql5);
                        sdr.Read();//遍历dr
                        
                          string  name = sdr["name"].ToString();

                            string string_num = Convert.ToString(num);
                            string sql2 = "UPDATE number SET 余票 ='" + string_num + "' WHERE 车次='" + str[0] + "'";
                            string sql3 = "UPDATE ticket SET 余票 ='" + string_num + "' WHERE 车次='" + str[0] + "'";
                            string sql4 = "insert into [personal](订单编号,用户名,姓名,车次,出发站,到达站,订票日期,出发日期,票价) values ('" + bianhao + "','" + user + "','" + name + "','" + str[0] + "','" + str[1] + "','" + str[2] + "','" + date + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + str[7] + "')";
                            int i = con.ExecuteSQL(sql2);
                            int j = con.ExecuteSQL(sql3);
                            int k = con.ExecuteSQL(sql4);
                            if (i >= 1 && j >= 1 && k >= 1)
                            {
                                MessageBox.Show("订票成功");
                                textBox1.Clear();
                                textBox2.Clear();
                            }
                       
                    
                        
                        con.close();
                    
                    
                }

                else//如果点击“取消”按钮

                {

                }
               

            }
        }
    }
}
