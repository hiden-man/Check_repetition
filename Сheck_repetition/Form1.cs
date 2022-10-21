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
        private void button1_Click(object sender, EventArgs e){ CheakList(); }
        private void button2_Click(object sender, EventArgs e){ Close();}
        /*
        public void Xxtyr()
        {
            // незакінчений метод
            byte step = 0;
            string strNumberOfItem = "";
            string str, strText2, str2 = "", str3 = "";
            str = textBox1.Text;
            strText2 = textBox2.Text;
            string[] strArray = str.Split(' '), strArray2 = strText2.Split(' ');
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
                if (q == intPosition[stepForIndex]) // вихід за межу масиву " intPosition "
                {
                    if (stepForIndex < intPosition.Length)
                    {
                        stepForIndex++;
                        continue;
                    }
                    else
                        stepForIndex = intPosition.Length-1;
                }
                else if (q != intPosition[stepForIndex])
                {
                    if (stepForIndex2 == 0)
                    {
                        str2 = strArray[q];
                        stepForIndex2++;
                    }
                    else
                        str2 += $"\n{strArray[q]}";
                }
                else if (q == strArray.Length)
                {
                    break;
                }
            }
            //richTextBox2.Text = strNumberOfItem;
            richTextBox2.Text += str2;
            //------------------------------------------------------------
            stepForIndex = 0;
            stepForIndex2 = 0;
            for (int f = 0; f < strArray2.Length; f++)
            {
                if (f == intPosition[stepForIndex])
                {
                    stepForIndex++;
                    continue;
                }
                else
                {
                    if (stepForIndex2 == 0)
                    {
                        str3 = strArray2[f];
                        stepForIndex2++;
                    }
                    else
                        str3 += $" {strArray2[f]}";
                }
                if (f == strArray2.Length)
                {
                    break;
                }
            }
            textBox2.Text = str3;
        }
        */

        public void CheakList() // зробити сповіщення через меседжбокс
        {
            byte step = 0;
            string clearStr = "", clearStr2 = "", numberOfItems = "";
            string str, strText2;
            int w = 0;
            str = textBox1.Text;
            strText2 = textBox2.Text;
            string[] strArray = str.Split(' '), strArray2 = strText2.Split(' ');
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
                            // запис першого слова
                            clearStr = strArray[i];
                            clearStr2 = strArray2[i];
                            step++;
                        }
                        else
                        {
                            // запис інших слів
                            clearStr += $", {strArray[i]}";
                            clearStr2 += $", {strArray2[i]}";
                            step = 1;
                        }
                    }
                }
            }
            DialogResult resoult = MessageBox.Show(
                $"Cлова які повторюються: {clearStr}\nПереклад: {clearStr2}\nВидаліть їх буль-ласка",
                "Увага",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
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
