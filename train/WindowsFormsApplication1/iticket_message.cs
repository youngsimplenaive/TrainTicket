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
    public partial class iticket_message : Form
    {
        private SqlDataAdapter adapter = null;
        private SqlCommand cmd = null;
        private DataSet dSet = null;
        public iticket_message()
        {
            InitializeComponent();
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
                string sql = "select [车次],[出发站],[到达站],[出发时间],[到达时间],[历时],[余票] from [number] ";
                string sql1 = "[出发站] ='" + textBox1.Text + "' and [到达站] ='" + textBox2.Text + "'and [出发日] ='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
                sql = sql + "where" + sql1;
                string str = @"Data Source = CZL;Initial Catalog = train;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                cmd = new SqlCommand(sql, con);
                adapter = new SqlDataAdapter(cmd);
                dSet = new DataSet();
                //填充数据集DataSet
                adapter.Fill(dSet, "number");
                dataGridView1.DataSource = dSet.Tables["number"];


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("请选择出发地和目的地");
            }
            if ((textBox3.Text == "" && textBox4.Text != "") || (textBox4.Text == "" && textBox3.Text != ""))
            {
                MessageBox.Show("出发站和目的站两者中其一不能为空!!!!");
            }
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                string sql = "select [车次],[出发站],[到达站],[出发时间],[到达时间],[历时],[票价] from [price] ";
                string sql1 = "[出发站] ='" + textBox3.Text + "' and [到达站] ='" + textBox4.Text + "'";
                sql = sql + "where" + sql1;
                string str = @"Data Source = CZL;Initial Catalog = train;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                cmd = new SqlCommand(sql, con);
                adapter = new SqlDataAdapter(cmd);
                dSet = new DataSet();
                //填充数据集DataSet
                adapter.Fill(dSet, "price");
                dataGridView2.DataSource = dSet.Tables["price"];


            }
        }

        private void iticket_message_Load(object sender, EventArgs e)
        {

        }
    }
}
