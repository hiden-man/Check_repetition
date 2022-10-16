using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Сheck_repetition
{
    public partial class Form1 : Form
    {
        string[] strArrayWords = { "elder", "ypypy", "dersten", "red", "duck", "dark", "yellow", "blue", "true" };
        string clearStr;
        int numbItem = 0,ter = 0;
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
        private void button1_Click(object sender, EventArgs e){ Xxtyr();}
        private void button2_Click(object sender, EventArgs e){ Close();}
        public void Xxtyr()
        {
            string str;
            str = textBox1.Text;
            string[] strArray = str.Split(' ');
            int x = strArray.Length;
            clearStr = "";
            numbItem = 0;
            for (int i = 0; i < x; i++)
            {
            //NextWor:
                for (int j = 0; j < strArrayWords.Length; j++)
                {
                    // якщо останнє слово в текстбоксі співпадає зі словом в списку то видає помилку вихід за межі масиву
                    if (strArray[i] == strArrayWords[j])
                    {
                        if (numbItem == 0)
                        {
                            clearStr = strArray[i];
                            numbItem++;
                        }
                        else
                            clearStr += ", "+strArray[i];

                        //i++;
                        //numbItem++;
                        //goto NextWor;
                    }
                }
                //if (numbItem == 0)
                //    clearStr = strArray[i];
                //if(numbItem > 0)
                //    clearStr += " "+strArray[i];
                //if (i == x+1)
                //{
                //    break;
                //}

                //richTextBox2.Text += "\n"+ter++;
            }
            if (numbItem > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Такі слова вже є в списку:\n{clearStr}\nВідмінити зберігання слів?",
                    "Увага",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    foreach (string newStr in strArray)
                    {
                        richTextBox1.Text += $"\n{newStr}";
                    }
                }
            }
            else 
            {
                string checkInSpace = textBox1.Text;
                if (checkInSpace[0] != ' ')
                {
                    foreach (string newStr in strArray)
                    {
                        richTextBox1.Text += $"\n{newStr}";
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Видаліть пробіл на початку текстового поля!",
                        "Увага",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            //textBox1.Text = clearStr;
        }

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
