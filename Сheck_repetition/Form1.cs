using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Сheck_repetition
{
    public partial class Form1 : Form
    {
        string[] strArrayWords = { "elder", "ypypy", "dersten", "red", "duck", "dark", "yellow", "blue", "true" };
        string strNumberOfItem;
        byte step = 0;
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
            step = 0;
            strNumberOfItem = "";
            string str, str2 = "";
            str = textBox1.Text;
            string[] strArray = str.Split(' ');
            // цикл для списку слів який вводимо в текстове поле
            for (int i = 0; i < strArray.Length; i++)
            {
                // цикл для списку слів з яким перевіряємо на повтор перший список
                for (int j = 0; j < strArrayWords.Length; j++)
                {
                    // якщо слова співпадають то йде запис номеру позиції слова в списку
                    if (strArray[i] == strArrayWords[j])
                    {
                        if (step == 0)
                        {
                            // запис першої позиції
                            strNumberOfItem = i.ToString();
                            step++;
                        }
                        else
                        {
                            // запис інших позицій
                            strNumberOfItem += $",{i}";
                            step = 1;
                        }
                    }
                }
            }
            // створення текствого масиву номерів позицій слів у списку
            string[] strNumberOfPositionOfWord = strNumberOfItem.Split(',');
            int[] intPosition = new int[strNumberOfPositionOfWord.Length];
            for (int n = 0; n < strNumberOfPositionOfWord.Length; n++)
                intPosition[n] = Convert.ToInt32(strNumberOfPositionOfWord[n]);
            int stepForIndex = 0, stepForIndex2 = 0;
            for (int q = 0; q < strArray.Length; q++)
            {
                if (q == intPosition[stepForIndex])
                {
                    stepForIndex++;
                    continue;
                }
                else
                {
                    if (stepForIndex2 == 0)
                    {
                        str2 = strArray[q];
                        stepForIndex2++;
                    }
                    else
                        str2 += $" {strArray[q]}";
                }
                if (q == strArray.Length)
                {
                    break;
                }
            }
            richTextBox2.Text = strNumberOfItem;
            richTextBox2.Text += "\n"+str2;
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
