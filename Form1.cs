using System;

namespace HebbNeuralNetwork
{
    public partial class Form1 : Form
    {
        private KnowledgeBase knowledgeBase = new KnowledgeBase();
        HebbAlg hebbAlg;
        private const int fields = 16;
        public Form1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            knowledgeBase.initDictionaty();
            hebbAlg = new HebbAlg(knowledgeBase);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Может распознать буквы:";
            button2.Enabled = false;
            clear(fields + 1);
            Letter letterToRecognize = new Letter();
            List<int> listToRecognize = new List<int>();
            for (int i = 1; i < (fields + 1); i++)
            {
                Control control = this.Controls["checkBox" + i];
                CheckBox cb = (CheckBox)control;
                if (cb.Checked)
                {
                    listToRecognize.Add(1);
                }
                else
                {
                    listToRecognize.Add(-1);
                }
            }
            letterToRecognize.X = listToRecognize;
            letterToRecognize.T = new List<int>() { 0, 0, 0, 0 };
            if (listToRecognize.Contains(1))
            {
                Letter showLetter = hebbAlg.hebbAlg(letterToRecognize);
                if (showLetter.T.ElementAt(0) != 0)
                {
                    for (int i = (fields + 1); i < (fields * 2 + 1); i++)
                    {
                        Control control = this.Controls["checkBox" + i];
                        CheckBox cb = (CheckBox)control;
                        if (showLetter.X.ElementAt(i - (fields + 1)) == 1)
                        {
                            cb.Checked = true;
                        }
                    }
                }
                else
                {
                    label1.Text = "Изображение не распознано";
                }
            }
            else
            {
                label1.Text = "Пустой ввод, выберите хотя бы одно поле";
            }
            button2.Enabled = true;
        }

        public void clear(int start)
        {
            for (int i = start; i < (fields * 2 + 1); i++)
            {
                Control control = this.Controls["checkBox" + i];
                CheckBox cb = (CheckBox)control;
                cb.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear(1);
        }
    }
}