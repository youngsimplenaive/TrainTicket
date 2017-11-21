using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class index : Form
    {

        public index()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            iticket_message message = new iticket_message();
            message.Show();
            message.tabControl1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilogin login = new ilogin();
            login.Show();
           
        }

        private void index_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ColorChange));
            thread.Start();
   


        }
        private void ColorChange()
        {
            Random random = new Random();
            while (true)
            {
                int red = random.Next(1, 256);
                int green = random.Next(1, 256);
                int blue = random.Next(1, 256);
                this.label1.ForeColor = Color.FromArgb(red, green, blue);
                Thread.Sleep(500);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left -= 5;
            if (label1.Right < 0)
            {
                label1.Left = Width;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iticket_message message = new iticket_message();
            message.Show();
            message.tabControl1.SelectedIndex = 1;
        }
    }
}
