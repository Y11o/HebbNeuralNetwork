using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HebbNeuralNetwork
{
    internal class HebbAlg
    {
        private KnowledgeBase knowledgeBase;
        private const int fields = 16;
        private const int epochLimit = 10;
        private int[,] w;   //Матрица весов
        private int[] x = new int[17];   //Матрица входов
        private int[] y = new int[4];   //Матрица выходов
        private bool baseTeached = false;


        public HebbAlg(KnowledgeBase knowledgeBase)
        {
            this.knowledgeBase = knowledgeBase;
            w = new int[fields + 1, knowledgeBase.Dictionary.Count];
        }


        public Letter hebbAlg(Letter letterToRecognize)
        {
            if (!baseTeached)
            {
                baseTeached = true;
                teachDictionary();
            }
            for (int exit = 0; exit < knowledgeBase.Dictionary.Count; exit++)
            {
                int suM = 0;
                for (int currW = 1; currW < fields + 1; currW++)
                {
                    suM += letterToRecognize.X.ElementAt(currW - 1) * w[currW, exit];
                }
                suM += w[0, exit];
                letterToRecognize.T[exit] = suM > 0 ? 1 : -1;
            }
            foreach (Letter letter in knowledgeBase.Dictionary)
            {
                if (letter.T.SequenceEqual(letterToRecognize.T))
                {
                    return letter;
                }
            }
            Letter notRecognized = new Letter();
            for (int i = 0; i < knowledgeBase.Dictionary.Count; i++)
            {
                notRecognized.T.Add(0);
            }
            return notRecognized;
        }

        private void teachDictionary()  //Расчёт весов для эталонных букв
        {
            for (int j = 0; j < fields + 1; j++)
            {
                for (int i = 0; i < knowledgeBase.Dictionary.Count; i++)
                {
                    w[j, i] = 0;
                }
            }
            int lettersTeached = 0;
            for (int epoch = 0; epoch < epochLimit; epoch++)
            {
                if (lettersTeached > knowledgeBase.Dictionary.Count * 2 - 1)
                {
                    break;
                }
                foreach (Letter letter in knowledgeBase.Dictionary)
                {
                    Letter testLetter = new Letter();
                    testLetter.X = letter.X;
                    testLetter.T = new List<int>() { 0, 0, 0, 0 };
                    while (!hebbAlg(testLetter).T.SequenceEqual(letter.T))
                    {
                        x[0] = 1;
                        for (int pos = 1; pos < letter.X.Count + 1; pos++)
                        {
                            x[pos] = letter.X.ElementAt(pos - 1);
                        }
                        for (int exit = 0; exit < letter.T.Count; exit++)
                        {
                            y[exit] = letter.T.ElementAt(exit);
                        }
                        for (int j = 0; j < knowledgeBase.Dictionary.Count; j++)
                        {
                            for (int i = 0; i < fields + 1; i++)
                            {
                                w[i, j] = w[i, j] + x[i] * y[j];
                            }
                        }
                    }
                    lettersTeached++;
                }
            }
            printModel();   //Печать модели w[,] в файл model.txt
        }

        private void printModel()
        {
            string path = @"D:\My projects\VS repos\HebbNeuralNetwork\model.txt";
            string model = "[ ";
            for (int j = 0; j < knowledgeBase.Dictionary.Count; j++)
            {
                for (int i = 0; i < fields + 1; i++)
                {
                    model += w[i, j] + ", ";
                }
                model += "\n";
            }
            model += "]";
            FileStream fsAppend = new FileStream(path, FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fsAppend))
            {
                writer.Write(model);
            }
        }
    }
}
