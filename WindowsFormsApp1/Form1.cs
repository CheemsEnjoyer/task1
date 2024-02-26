using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTextBoxValues();
        }

        private void LoadTextBoxValues()
        {
            textBoxA.Text = Properties.Settings.Default.textBoxA;
            textBoxB.Text = Properties.Settings.Default.textBoxB;
            textBoxC.Text = Properties.Settings.Default.textBoxC;
        }

        private void SaveTextBoxValues()
        {
            Properties.Settings.Default.textBoxA = textBoxA.Text;
            Properties.Settings.Default.textBoxB = textBoxB.Text;
            Properties.Settings.Default.textBoxC = textBoxC.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxA.Text, out double a) &&
            double.TryParse(textBoxB.Text, out double b) &&
            double.TryParse(textBoxC.Text, out double c))
            {
                string result = Logic.checkExistence(a, b, c);
                MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа для сторон треугольника.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTextBoxValues();
        }
    }


    public class Logic
    {
        public static string checkExistence(double a, double b, double c)
        {
            string outMessageExists = "";
            if ((a < b + c) && (b < a + c) && (c < a + b))
            {
                if ((a * a == b * b + c * c) || (b * b == a * a + c * c) || (c * c == a * a + b * b))
                {
                    outMessageExists = "Треугольник является прямоугольным!";
                }
                else
                {
                    outMessageExists = "Треугольник не является прямоугольным!";
                }
            }
            else
            {
                outMessageExists = "Треугольник не существует!";
            }
            return outMessageExists;
        }
    }
}
