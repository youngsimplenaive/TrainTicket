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
    public partial class ticket_price : Form
    {
        private SqlDataAdapter adapter = null;
        private SqlCommand cmd = null;
        private DataSet dSet = null;

        public ticket_price()
        {
            InitializeComponent();
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" )
            {
                MessageBox.Show("请选择出发地和目的地或者输入车次");
            }
            if ((textBox1.Text == "" && textBox2.Text != "") || (textBox2.Text == "" && textBox1.Text != "")) 
            {
                MessageBox.Show("出发站和目的站两者中其一不能为空!!!!");
            }
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                string sql = "select [车次],[出发站],[到达站],[出发时间],[到达时间],[历时],[票价] from [price] ";
                string sql1= "[出发站] ='"+ textBox1.Text + "' and [到达站] ='" + textBox2.Text + "'";
                sql = sql + "where" + sql1;
                string str = @"Data Source = CZL;Initial Catalog = train;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                cmd = new SqlCommand(sql, con);
                adapter = new SqlDataAdapter(cmd);
                dSet = new DataSet();
                //填充数据集DataSet
                adapter.Fill(dSet, "price");
                dataGridView1.DataSource = dSet.Tables["price"];
     

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ticket_price_Load(object sender, EventArgs e)
        {

        }
    }
}
