using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Code
    {

        public string CheckCode()//获取随即数
        {
            int number;
            char code;
            int codelength = 4;
            string checkCode = String.Empty;
            Random random = new Random();
            for (int i = 0; i < codelength; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                checkCode += "" + code.ToString();
            }
            return checkCode;
        }

        public Bitmap DrawVerifyCodePicture(string verifyCode)//画验证码图
        {
            int imageWidth = 15 * (verifyCode.Length + 1);//定义图片宽度。。
            int imageHeight = 30;//定义图片高度。。
            Color[] colors = {Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Chocolate,
                             Color.Brown, Color.Purple, Color.DarkGoldenrod};//验证码颜色集合。。
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体",
                             "华文隶书", "Arial Black", "幼圆"};//验证码字体集合。。
            Random rand = new Random((int)DateTime.Now.Ticks);//创建Random类的实例rand。。
            Bitmap image = new Bitmap(imageWidth, imageHeight);//创建一个图像实例。。
            Graphics graphics = Graphics.FromImage(image);//从该图创建一个绘画实例。。
            graphics.Clear(Color.LightCyan);//先清空画面，接着用颜色填充。。
            Pen pen = new Pen(Color.LightGray, 0);//定义pen，用于绘制背景点。。
            for (int i = 0; i < verifyCode.Length * 50; i++)
            {
                int x = rand.Next(imageWidth);//定义背景点横坐标。。
                int y = rand.Next(imageHeight);//定义背景点纵坐标。。
                graphics.DrawRectangle(pen, x, y, 1, 1);//在矩形框中绘制背景点。。
            }
            for (int i = 0; i < verifyCode.Length; i++)//逐个定义字符的颜色、字体、高度等，并绘制。。
            {
                int colorIndex = rand.Next(colors.Length);//定义验证码颜色索引值。。
                int fontIndex = rand.Next(fonts.Length);//定义验证码字体索引值。。
                Brush brush = new SolidBrush(colors[colorIndex]);//颜色。。
                Font font = new Font(fonts[fontIndex], 16, FontStyle.Bold);//字体。。
                string singleCode = verifyCode.Substring(i, 1);//提取单个字符。。
                int x = 5 + (i * 15);//定义字符绘制的横坐标。。
                int y = 2;//定义字符绘制的纵坐标。。
                if (i % 2 == 0)//用于控制所有验证码不在同一高度上。。
                {
                    y = 1;
                }
                graphics.DrawString(singleCode, font, brush, x, y);//开始绘制。。
            }
            graphics.Dispose();//释放对象。。
            return (image);
        }




    }
}
