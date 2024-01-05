using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WinForms_Draft_2
{

    public partial class Form1 : Form
    {
        const int SCREEN = 512;                                                         //столько байтов помещается на экране
        static int BYTES_in_LINE = 8;                                                    //количество байтов в строке
        static int CHAR_in_LINE = 1 + CHAR_in_NUMBER + BYTES_in_LINE * CHAR_in_BYTE;     //количество символов строке
        const int CHAR_in_BYTE = 4;                                                     //количество символов в одном байте (2 символа - сам байт + 2 пробела)
        const int CHAR_in_NUMBER = 13;                                                  //количество символов в нумерации
        byte[] BinBufferFirstFile = new byte[1 * SCREEN];                               //буффер для левого текстбокса (первый буффер)
        byte[] BinBufferSecondFile = new byte[1 * SCREEN];                              //буффер для левого текстбокса (первый буффер)
        int RealReadingByteFirstFile = 0;                                               //сколько действительно было прочитано байтов в первый буффер
        int RealReadingByteSecondFile = 0;                                              //сколько действительно было прочитано байтов во второй буффер
        string StrBufferFirstFile;                                                      //строка, в которой выведены номерация и байты первого (левого) файла
        string StrBufferSecondFile;                                                     //строка, в которой выведены номерация и байты второго (правого) файла

        public Form1()
        {
            InitializeComponent();
        }



        string filename1;
        string filename2;
        bool DivisionAllBytes = false;  //Сравниваются ли файлы
        bool DivisionOneByte = false;  //Подсвечиваются ли следущее/предыдущее различие



        int ReadByte(string filename, byte[] buffer, long offset)
        {
            using (FileStream fstream = new FileStream(filename, FileMode.Open))
            {
                fstream.Seek(offset * BYTES_in_LINE, SeekOrigin.Begin);
                int realByte;
                realByte = fstream.Read(buffer, 0, SCREEN);
                return realByte;
            }
        }

        /// <summary>
        /// Функция выводит в тестбокс часть байтов файла и заполняет буффер и строку.
        /// </summary>
        /// <param name="filename">путь к файлу</param>
        /// <param name="buffer">буффер, в который записываются байты</param>
        /// <param name="realByte">количество байтов в буффере</param>
        /// <param name="strBuffer">строка, в которое записывается содержимое (нимерация и байты, разделеенные пробелами)</param>
        /// <param name="textBox">текстбокс, в который зписывается строка strBuffer</param>
        /// <param name="offset">отступ от начала файла</param>
        void BinaryDisplay(string filename, byte[] buffer, int realByte, string strBuffer, RichTextBox textBox, long offset = 0)
        {

            strBuffer = "";

            realByte = ReadByte(filename, buffer, offset);
            for (int numberOfByte = 0; numberOfByte < realByte; numberOfByte += 8)
            {
                strBuffer += (offset * BYTES_in_LINE + numberOfByte).ToString("X8") + ":  |\t";
                for (int indexByteInLine = 0; indexByteInLine < BYTES_in_LINE; indexByteInLine++)
                {
                    if ((numberOfByte + indexByteInLine) >= realByte)
                    {
                        break;
                    }
                    strBuffer += buffer[numberOfByte + indexByteInLine].ToString("X2") + "  ";
                }
                strBuffer += '\n';

            }


            if (textBox == leftTextBox)
            {
                StrBufferFirstFile = strBuffer;
                RealReadingByteFirstFile = realByte;
            }
            else
            {
                StrBufferSecondFile = strBuffer;
                RealReadingByteSecondFile = realByte;
            }
            textBox.Text = strBuffer;

        }

        /// <summary>
        /// Принимает два буффера, две строки, два текстбокса. Перекрашивает различающиеся байты в красный цвет.
        /// </summary>
        /// <param name="b1">Буффер левого файла</param>
        /// <param name="b2">Буффер правого файла</param>
        /// <param name="str1">Содердимое левого текстбокса</param>
        /// <param name="str2">Содердимое правого текстбокса</param>
        /// <param name="leftTextBox">Левый текстбокс</param>
        /// <param name="rightTextBox">Правый текстбокс</param>
        /// <param name="realByte1">Количество байтов в левом буффере</param>
        /// <param name="realByte2">Количество байтов в правом буффере</param>
        void BinaryDivision(byte[] b1, byte[] b2, string str1, string str2, RichTextBox leftTextBox, RichTextBox rightTextBox,
            int realByte1, int realByte2)
        {
            leftTextBox.Text = str1;
            rightTextBox.Text = str2;
            int realChar1 = (realByte1 / BYTES_in_LINE) * CHAR_in_LINE;
            if (realByte1 % BYTES_in_LINE != 0)
                realChar1 += CHAR_in_NUMBER + realByte1 % BYTES_in_LINE * CHAR_in_BYTE;         //количество символов в строке из левого текстбокса
            int realChar2 = (realByte2 / BYTES_in_LINE) * CHAR_in_LINE;
            if (realByte2 % BYTES_in_LINE != 0)
                realChar2 += CHAR_in_NUMBER + realByte2 % BYTES_in_LINE * CHAR_in_BYTE;         //количество символов в строке из правого текстбокса

            //перекраска символов до момента, когда заканчивается более кортокий файл
            for (int numberOfChar = 0; numberOfChar < (Math.Min(realChar1, realChar2)); numberOfChar += CHAR_in_LINE)
            {
                int indexCharInLine = 0;
                while (indexCharInLine < (CHAR_in_LINE - CHAR_in_NUMBER - 1))
                {
                    if (b1[(numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE] != b2[(numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE])
                    {
                        leftTextBox.SelectionStart = numberOfChar + indexCharInLine + CHAR_in_NUMBER;
                        rightTextBox.SelectionStart = numberOfChar + indexCharInLine + CHAR_in_NUMBER;
                        int length = 0;
                        while (b1[(numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE] != b2[(numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE])
                        {
                            indexCharInLine += CHAR_in_BYTE;
                            length += CHAR_in_BYTE;
                            if (indexCharInLine >= CHAR_in_LINE - CHAR_in_NUMBER - 1)
                                break;
                            if (((numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE) == SCREEN)
                            {
                                break;
                            }
                        }
                        leftTextBox.SelectionLength = length;
                        rightTextBox.SelectionLength = length;
                        leftTextBox.SelectionColor = Color.Red;
                        rightTextBox.SelectionColor = Color.Red;


                    }
                    else
                    {
                        while (b1[(numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE] == b2[(numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE])
                        {
                            indexCharInLine += CHAR_in_BYTE;
                            if (indexCharInLine > CHAR_in_LINE - CHAR_in_NUMBER - 1)
                                break;
                            if ((numberOfChar / CHAR_in_LINE) * BYTES_in_LINE + indexCharInLine / CHAR_in_BYTE == SCREEN)
                            {
                                break;
                            }
                        }
                    }
                }


            }

            //докраска оставшихся байтов в случае, если первый файл больше
            if (realChar1 > realChar2)
            {
                if ((realChar2 % CHAR_in_LINE) - CHAR_in_NUMBER > 0)
                {
                    for (int i = realChar2; i < ((realChar2 + CHAR_in_LINE - 1) / CHAR_in_LINE) * CHAR_in_LINE - 1; i += CHAR_in_BYTE)
                    {
                        leftTextBox.SelectionStart = i;
                        leftTextBox.SelectionLength = CHAR_in_BYTE;
                        leftTextBox.SelectionColor = Color.Red;

                    }

                }
                for (int i = ((realChar2 + CHAR_in_LINE - 1) / CHAR_in_LINE) * CHAR_in_LINE; i < realChar1; i += CHAR_in_LINE)
                {
                    leftTextBox.SelectionStart = i + CHAR_in_NUMBER;
                    leftTextBox.SelectionLength = CHAR_in_LINE - CHAR_in_NUMBER - 1;
                    leftTextBox.SelectionColor = Color.Red;
                }
            }

            //докраска оставшихся байтов в случае, если второй файл больше
            if (realChar2 > realChar1)
            {
                if ((realChar1 % CHAR_in_LINE) - CHAR_in_NUMBER > 0)
                {
                    for (int i = realChar1; i < ((realChar1 + CHAR_in_LINE - 1) / CHAR_in_LINE) * CHAR_in_LINE - 1; i += CHAR_in_BYTE)
                    {
                        rightTextBox.SelectionStart = i;
                        rightTextBox.SelectionLength = CHAR_in_BYTE;
                        rightTextBox.SelectionColor = Color.Red;

                    }

                }
                for (int i = ((realChar1 + CHAR_in_LINE - 1) / CHAR_in_LINE) * CHAR_in_LINE; i < realChar2; i += CHAR_in_LINE)
                {
                    rightTextBox.SelectionStart = i + CHAR_in_NUMBER;
                    rightTextBox.SelectionLength = CHAR_in_LINE - CHAR_in_NUMBER - 1;
                    rightTextBox.SelectionColor = Color.Red;
                }
            }
        }



        //static int nowPosition = 0;
        static long n_Pos = -1;
        long preposition = 0;
        static bool IsColourNow = false;
        void FindNextDifference(string filename1, byte[] BinBufferFirstFile, string StrBufferFirstFile, RichTextBox leftTextBox,
            string filename2, byte[] BinBufferSecondFile, string StrBufferSecondFile, RichTextBox rightTextBox, long offset = 0)
        {
            int realByte1 = ReadByte(filename1, BinBufferFirstFile, offset);
            int realByte2 = ReadByte(filename2, BinBufferSecondFile, offset);

            for (long position = n_Pos + 1; position < Math.Max(realByte1, realByte2); position++)
            {
                if (BinBufferFirstFile[position] != BinBufferSecondFile[position])
                {
                    BinaryDisplay(filename1, BinBufferFirstFile, realByte1, StrBufferFirstFile, leftTextBox, VScrollBar1.Value);
                    BinaryDisplay(filename2, BinBufferSecondFile, realByte2, StrBufferSecondFile, rightTextBox, VScrollBar1.Value);
                    StrBufferFirstFile = leftTextBox.Text;
                    StrBufferSecondFile = rightTextBox.Text;
                    BinaryDivision(BinBufferFirstFile, BinBufferSecondFile, StrBufferFirstFile, StrBufferSecondFile, leftTextBox, rightTextBox,
                    RealReadingByteFirstFile, RealReadingByteSecondFile);
                    ColourDiffByte(position, preposition, leftTextBox, rightTextBox);
                    n_Pos = position;
                    preposition = position - 1;
                    break;
                }
            }



        }



        void FindPervDifference(string filename1, byte[] BinBufferFirstFile, string StrBufferFirstFile, RichTextBox leftTextBox,
           string filename2, byte[] BinBufferSecondFile, string StrBufferSecondFile, RichTextBox rightTextBox, long offset = 0)
        {
            int realByte1 = ReadByte(filename1, BinBufferFirstFile, offset);
            int realByte2 = ReadByte(filename2, BinBufferSecondFile, offset);

            for (long position = n_Pos - 1; position > 0; position--)
            {
                if (BinBufferFirstFile[position] != BinBufferSecondFile[position])
                {
                    BinaryDisplay(filename1, BinBufferFirstFile, realByte1, StrBufferFirstFile, leftTextBox, VScrollBar1.Value);
                    BinaryDisplay(filename2, BinBufferSecondFile, realByte2, StrBufferSecondFile, rightTextBox, VScrollBar1.Value);
                    StrBufferFirstFile = leftTextBox.Text;
                    StrBufferSecondFile = rightTextBox.Text;
                    BinaryDivision(BinBufferFirstFile, BinBufferSecondFile, StrBufferFirstFile, StrBufferSecondFile, leftTextBox, rightTextBox,
                    RealReadingByteFirstFile, RealReadingByteSecondFile);
                    ColourDiffByte(position, preposition, leftTextBox, rightTextBox);
                    n_Pos = position;
                    preposition = position++;
                    break;
                }
            }
        }




        void ColourDiffByte(long n_Pos, long preposition, RichTextBox leftTextBox, RichTextBox rightTextBox)
        {
            int nowScroll = VScrollBar1.Value;
            long n_Line = n_Pos / 8;
            long pre_Line = preposition / 8;
            if (nowScroll > n_Line)
            {
                if (IsColourNow)
                {
                    try
                    {
                        leftTextBox.SelectionStart = (int)(n_Pos / 8 * 46 + n_Pos % 8 * 4 - nowScroll * 8);
                        leftTextBox.SelectionLength = 2;
                        leftTextBox.SelectionBackColor = Color.White;
                        rightTextBox.SelectionStart = (int)(n_Pos / 8 * 46 + n_Pos % 8 * 4 - nowScroll * 8);
                        rightTextBox.SelectionLength = 2;
                        rightTextBox.SelectionBackColor = Color.White;
                        IsColourNow = false;
                    }
                    catch
                    {
                        leftTextBox.SelectionStart = 0;
                        leftTextBox.SelectionLength = SCREEN * 46;
                        leftTextBox.SelectionBackColor = Color.White;
                        rightTextBox.SelectionStart = 0;
                        rightTextBox.SelectionLength = SCREEN * 46;
                        rightTextBox.SelectionBackColor = Color.White;
                        IsColourNow = false;
                    }
                }

            }
            else
            {
                if (nowScroll * BYTES_in_LINE + SCREEN > n_Pos)
                {
                    int PRE_BetweenScrStart_and_Byte = (int)(n_Line - nowScroll);
                    int PRE_Indent = (int)(n_Pos % BYTES_in_LINE);
                    leftTextBox.SelectionStart = PRE_BetweenScrStart_and_Byte * CHAR_in_LINE + PRE_Indent * CHAR_in_BYTE + CHAR_in_NUMBER;
                    leftTextBox.SelectionLength = 2;
                    leftTextBox.SelectionBackColor = Color.White;
                    rightTextBox.SelectionStart = PRE_BetweenScrStart_and_Byte * CHAR_in_LINE + PRE_Indent * CHAR_in_BYTE + CHAR_in_NUMBER;
                    rightTextBox.SelectionLength = 2;
                    rightTextBox.SelectionBackColor = Color.White;


                    int BetweenScrStart_and_Byte = (int)(n_Line - nowScroll);
                    int Indent = (int)(n_Pos % BYTES_in_LINE);
                    leftTextBox.SelectionStart = BetweenScrStart_and_Byte * CHAR_in_LINE + Indent * CHAR_in_BYTE + CHAR_in_NUMBER;
                    leftTextBox.SelectionLength = 2;
                    leftTextBox.SelectionBackColor = Color.Yellow;
                    rightTextBox.SelectionStart = BetweenScrStart_and_Byte * CHAR_in_LINE + Indent * CHAR_in_BYTE + CHAR_in_NUMBER;
                    rightTextBox.SelectionLength = 2;
                    rightTextBox.SelectionBackColor = Color.Yellow;
                    IsColourNow = true;
                }
                else
                {
                    if (IsColourNow)
                    {
                        leftTextBox.SelectionStart = (int)(n_Pos / BYTES_in_LINE * CHAR_in_LINE + n_Pos % BYTES_in_LINE * CHAR_in_BYTE - nowScroll * BYTES_in_LINE);
                        leftTextBox.SelectionLength = 2;
                        leftTextBox.SelectionBackColor = Color.White;
                        rightTextBox.SelectionStart = (int)(n_Pos / BYTES_in_LINE * CHAR_in_LINE + n_Pos % BYTES_in_LINE * CHAR_in_BYTE - nowScroll * BYTES_in_LINE);
                        rightTextBox.SelectionLength = 2;
                        rightTextBox.SelectionBackColor = Color.White;
                        IsColourNow = false;
                    }
                }
            }

        }

        //выбор файла в левый текстбокс через диалоговое окно
        private void leftChooseButton_Click(object sender, EventArgs e)
        {
            //открытие диалогового окна
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename1 = openFileDialog1.FileName;
            leftPathBox.Text = filename1;
            //мастабирование скроллбара с учётом только что открытого файла
            long numberOfAllBytes2 = 0;
            long numberOfAllBytes1 = new FileInfo(filename1).Length;
            if (File.Exists(filename2))
            {
                numberOfAllBytes2 = new FileInfo(filename2).Length;
            }
            VScrollBar1.Minimum = 0;
            VScrollBar1.Maximum = (int)((numberOfAllBytes1 + 7) / 8);
            if ((int)(numberOfAllBytes2 / 8) > VScrollBar1.Maximum)
            {
                VScrollBar1.Maximum = (int)((numberOfAllBytes2 + 7) / 8);
            }

            //вывод байтов
            BinaryDisplay(filename1, BinBufferFirstFile, RealReadingByteFirstFile, StrBufferFirstFile, leftTextBox);
            if (rightPathBox.Text != "")
                BinaryDisplay(rightPathBox.Text, BinBufferSecondFile, RealReadingByteSecondFile, StrBufferSecondFile, rightTextBox);
            DivisionAllBytes = false;
            DivisionOneByte = false;
            n_Pos = -1;
        }


        //выбор файла в правый текстбокс через диалоговое окно и открытие файла
        private void rightChooseButton_Click(object sender, EventArgs e)
        {
            //открытие диалогового окна
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename2 = openFileDialog1.FileName;
            rightPathBox.Text = filename2;
            //мастабирование скроллбара с учётом только что открытого файла
            VScrollBar1.Minimum = 0;
            long numberOfAllBytes1 = 0;
            long numberOfAllBytes2 = new FileInfo(filename2).Length;
            if (File.Exists(filename1))
            {
                numberOfAllBytes1 = new FileInfo(filename1).Length;
            }

            VScrollBar1.Maximum = (int)((numberOfAllBytes2 + 7) / 8);
            if ((int)((numberOfAllBytes1 + 7) / 8) > VScrollBar1.Maximum)
            {
                VScrollBar1.Maximum = (int)((numberOfAllBytes1 + 7) / 8);
            }

            //вывод байтов
            BinaryDisplay(filename2, BinBufferSecondFile, RealReadingByteSecondFile, StrBufferSecondFile, rightTextBox);
            if (leftPathBox.Text != "")
                BinaryDisplay(leftPathBox.Text, BinBufferFirstFile, RealReadingByteFirstFile, StrBufferFirstFile, leftTextBox);
            DivisionAllBytes = false;
            DivisionOneByte = false;
            n_Pos = -1;
        }


        //выбор файла в левый текстбокс через путь, написанный вручную, и открытие файла
        private void leftPathBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')      //нажатие Enter означает подтверждение имени файла
                {
                    filename1 = leftPathBox.Text;
                    BinaryDisplay(filename1, BinBufferFirstFile, RealReadingByteFirstFile, StrBufferFirstFile, leftTextBox);
                    if (rightPathBox.Text != "")
                        BinaryDisplay(rightPathBox.Text, BinBufferSecondFile, RealReadingByteSecondFile, StrBufferSecondFile, rightTextBox);
                    DivisionAllBytes = false;
                    DivisionOneByte = false;
                    n_Pos = -1;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в имени фйла");

            }
        }


        //выбор файла в правый текстбокс через путь, написанный вручную, и открытие файла
        private void rightPathBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    filename2 = rightPathBox.Text;
                    BinaryDisplay(filename2, BinBufferSecondFile, RealReadingByteSecondFile, StrBufferSecondFile, rightTextBox);
                    if (leftPathBox.Text != "")
                        BinaryDisplay(leftPathBox.Text, BinBufferFirstFile, RealReadingByteFirstFile, StrBufferFirstFile, leftTextBox);
                    DivisionAllBytes = false;
                    DivisionOneByte = false;
                    n_Pos = -1;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в имени фйла");
            }
        }


        //Бинарное сравнение файлов при нажатии на кнопку
        private void CompareButton_Click(object sender, EventArgs e)
        {
            string oldData1 = "", oldData2 = "";
            try
            {
                long offset = VScrollBar1.Value;
                oldData1 = leftTextBox.Text;
                oldData2 = rightTextBox.Text;
                leftTextBox.Text = ("");
                rightTextBox.Text = ("");
                BinaryDivision(BinBufferFirstFile, BinBufferSecondFile, StrBufferFirstFile, StrBufferSecondFile, leftTextBox, rightTextBox,
                    RealReadingByteFirstFile, RealReadingByteSecondFile);
                DivisionAllBytes = true;
            }
            catch
            {
                //при отловке исключения текстбоксы остаются с содержимым как до вхождения в функцию
                leftTextBox.Text = oldData1;
                rightTextBox.Text = oldData2;
            }
        }


        //обработка при изменении положения скроллбара
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            long offset = VScrollBar1.Value;        //отступ(c какой сточки начинает считываться файл)

            //если файлы или файл выводится, но не сравниваются
            if (!DivisionAllBytes)
            {
                if (File.Exists(filename1))
                {
                    BinaryDisplay(filename1, BinBufferFirstFile, RealReadingByteFirstFile, StrBufferFirstFile, leftTextBox, offset);
                }
                if (File.Exists(filename2))
                {
                    BinaryDisplay(filename2, BinBufferSecondFile, RealReadingByteSecondFile, StrBufferSecondFile, rightTextBox, offset);
                }
            }


            //если файлы сравниваются
            else
            {
                if (File.Exists(filename1))
                {
                    BinaryDisplay(filename1, BinBufferFirstFile, RealReadingByteFirstFile, StrBufferFirstFile, leftTextBox, offset);
                }
                if (File.Exists(filename2))
                {
                    BinaryDisplay(filename2, BinBufferSecondFile, RealReadingByteSecondFile, StrBufferSecondFile, rightTextBox, offset);
                }
                DivisionAllBytes = true;
                BinaryDivision(BinBufferFirstFile, BinBufferSecondFile, StrBufferFirstFile, StrBufferSecondFile, leftTextBox, rightTextBox,
                    RealReadingByteFirstFile, RealReadingByteSecondFile);
                if (DivisionOneByte)
                {
                    if (n_Pos != -1)
                    {
                        ColourDiffByte(n_Pos, preposition, leftTextBox, rightTextBox);
                    }

                }
            }

        }

        private void nextDifferenceButton_Click(object sender, EventArgs e)
        {
            string oldData1 = "", oldData2 = "";
            try
            {
                oldData1 = leftTextBox.Text;
                oldData2 = rightTextBox.Text;
                FindNextDifference(filename1, BinBufferFirstFile, StrBufferFirstFile, leftTextBox, filename2, BinBufferSecondFile, StrBufferSecondFile, rightTextBox, VScrollBar1.Value);
                DivisionAllBytes = true;
                DivisionOneByte = true;
            }

            catch
            {
                leftTextBox.Text = oldData1;
                rightTextBox.Text = oldData2;
                MessageBox.Show("Откройте оба файла!");
            }

        }

        private void pervDifferenceButton_Click(object sender, EventArgs e)
        {
            string oldData1 = "", oldData2 = "";
            try
            {
                oldData1 = leftTextBox.Text;
                oldData2 = rightTextBox.Text;
                FindPervDifference(filename1, BinBufferFirstFile, StrBufferFirstFile, leftTextBox, filename2, BinBufferSecondFile, StrBufferSecondFile, rightTextBox, VScrollBar1.Value);

                DivisionAllBytes = true;
            }

            catch
            {
                leftTextBox.Text = oldData1;
                rightTextBox.Text = oldData2;
                MessageBox.Show("Откройте оба файла!");
            }
        }
    }
}
