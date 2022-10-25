using System;
using System.Windows.Forms;

namespace Сheck_repetition
{
    internal class Second_Class
    {
        string clearStr = "", clearStr2 = "";
        string[] strArray, strArray2;
        public byte step = 0;
        public Second_Class(string[] mainArray, string str1, string str2, char spaceSymbol, RichTextBox obj)
        {
            // перевірка на зайвий пробіл на початку полів
            if (str1[0] == ' ')
                MessageBox.Show("На початку першого поля стоїть пробіл", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (str2[0] == ' ')
                MessageBox.Show("На початку другого поля стоїть пробіл", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                // перетворення текстових рядків у масиви слів
                strArray = str1.Split(spaceSymbol);
                strArray2 = str2.Split(spaceSymbol);
                // цикл для списку слів який вводимо в текстове поле
                for (int i = 0; i < strArray.Length; i++)
                {
                    // цикл для списку слів з яким перевіряємо на повтор перший список
                    for (int j = 0; j < mainArray.Length; j++)
                    {
                        // якщо слова співпадають то йде запис номеру позиції слова в списку
                        if (strArray[i] == mainArray[j])
                        {
                            if (step == 0)
                            {
                                // запис першого слова
                                clearStr = strArray[i];
                                clearStr2 = strArray2[i];
                                step = 1;
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
            }
            if(step == 0)
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (i == 0)
                        obj.Text = strArray[i];
                    else
                        obj.Text += $"\n{strArray[i]}";
                }
            }
            else
            {
                MessageBox.Show(
                    $"Cлова які повторюються: {clearStr}\nПереклад: {clearStr2}\nВидаліть їх буль-ласка",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
