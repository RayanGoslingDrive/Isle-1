using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private float formheight = 0;
        private float formwidth = 0;
        private static List<string> lines = new List<string>();
        public static string text = "";

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            int N;
            int M;     
            
            List<string> l = textBox1.Text.Replace("\r", "").Split('\n').ToList();

            N = Convert.ToInt32(l[0]);
            l.RemoveAt(0);
            M = Convert.ToInt32(l[0]);
            l.RemoveAt(0);
            for (int i = N; i < l.Count(); i++)
            {
                if (l[i] == "")
                {
                    l.RemoveAt(i);
                    i--;
                }
            }
            if (Calculate(l, N, M))
            {
                textBox2.Text = text;
                string finalstring = "";
                foreach (string str in l)
                {
                    finalstring += str + "\r\n";
                }
                textBox1.Text = $"{N}\r\n{M}\r\n{finalstring}";
            }
            else
            {
                textBox2.Text = "Некорректный ввод"; 
            }

        }
        public static bool Calculate(List<string> l, int N, int M)
        {
            lines.Clear();
            text = "";
            if (!Check_input(l, N, M)) { return false; }


            List<Coordinate> coordinates = new List<Coordinate>();

            string[] Map = new string[N + 2];


            for (int i = 0; i < M + 2; i++)
            {
                Map[0] += ".";
            }
            for (int i = 0; i < l.Count(); i++)
            {
                Map[i + 1] = "." + l[i] + ".";
            }
            for (int i = 0; i < M + 2; i++)
            {
                Map[N + 1] += ".";
            }
            for (int i = 1; i < N + 1; i++)
            {
                for (int j = 1; j < M + 1; j++)
                {
                    if (Map[i][j] == '.' && (Map[i - 1][j] == '#' || Map[i + 1][j] == '#' || Map[i][j - 1] == '#' || Map[i][j + 1] == '#' || Map[i - 1][j - 1] == '#' || Map[i - 1][j + 1] == '#' || Map[i + 1][j - 1] == '#' || Map[i + 1][j + 1] == '#'))
                    {
                        l[i - 1] = l[i - 1].Remove(j - 1, 1).Insert(j - 1, "*");
                        coordinates.Add(new Coordinate(i, j));
                    }
                }
            }
            int y, x;
            try
            {
                y = coordinates[0].y;
                x = coordinates[0].x;
            }
            catch
            {
                return false;
            }
            int[] test = { 0, 1, -1 };
            bool found = false;
            while (coordinates.Count != 0)
            {
                lines.Add($"{y} {x}\r\n");
                coordinates.Remove(new Coordinate(y, x));
                foreach (int i in test)
                {
                    foreach (int j in test)
                    {
                        if (coordinates.Contains(new Coordinate(y + i, x + j)))
                        {

                            x += j;
                            y += i;
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {

                        found = false; break;
                    }
                }
            }
            foreach (string str in lines)
            {
                text += str;
            }
            return true;
        }
        private static bool Check_input(List<string> l, int N, int M)
        {
            if (l.Count() != N || N < 3 || N > 100)
            {
                return false;
            }
            foreach (var line in l)
            {
                if (line.Length != M || M < 3 || M > 100)
                {
                    return false;
                }
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != '.' && line[i] != '#')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox1.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            float formHeight = this.Height;
            float formWidth = this.Width;
            float sizeDiffH = formHeight / formheight;
            float sizeDiffW = formWidth / formwidth;
            SizeF ratio = new SizeF(sizeDiffW, sizeDiffH);
            textBox1.Scale(ratio);
            textBox2.Scale(ratio);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            formheight = this.Height;
            formwidth = this.Width;
        }
    }
}
