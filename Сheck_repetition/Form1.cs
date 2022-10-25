using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Сheck_repetition
{
    public partial class Form1 : Form
    {
        string[] strArrayWords = { "elder", "ypypy", "dersten", "red", "duck", "dark", "yellow", "blue", "true" };
        public Form1(){InitializeComponent();}
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < strArrayWords.Length; i++)
            {
                if (i == 0)
                    richTextBox1.Text = strArrayWords[i];
                else
                    richTextBox1.Text += "\n"+strArrayWords[i];
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Second_Class second_class = new Second_Class(strArrayWords, textBox1.Text, textBox2.Text, ' ', richTextBox2);
        }
        private void button2_Click(object sender, EventArgs e){ Close();}
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
