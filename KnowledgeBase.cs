using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HebbNeuralNetwork
{
    internal class KnowledgeBase
    {
        private List<Letter> dictionary = new List<Letter>();

        public List<Letter> Dictionary { get => dictionary; set => dictionary = value; }

        public void initDictionaty() 
        {
            List<int> listI = new List<int>() {1, -1, -1, 1, 1, -1, 1, 1, 1, 1, -1, 1, 1, -1, -1, 1};
            List<int> listL = new List<int>() {-1, 1, 1, -1, 1, -1, -1, 1, 1, -1, -1, 1, 1, -1, -1, 1};
            List<int> listC = new List<int>() {1, 1, 1, 1, 1, -1, -1, -1, 1, -1, -1, -1, 1, 1, 1, 1};
            List<int> listb = new List<int>() {1, -1, -1, -1, 1, 1, 1, 1, 1, -1, -1, 1, 1, 1, 1, -1};
            List<int> listIOut = new List<int>() {1, -1, -1, -1};
            List<int> listLOut = new List<int>() {-1, 1, -1, -1};
            List<int> listCOut = new List<int>() {-1, -1, 1, -1};
            List<int> listbOut = new List<int>() {-1, -1, -1, 1};
            Letter letterI = new Letter();
            Letter letterL = new Letter();
            Letter letterC = new Letter();
            Letter letterb = new Letter();
            letterI.X = listI;
            letterL.X = listL;
            letterC.X = listC;
            letterb.X = listb;
            letterI.T = listIOut;
            letterL.T = listLOut;
            letterC.T = listCOut;
            letterb.T = listbOut;
            Dictionary.Add(letterI);
            Dictionary.Add(letterL);
            Dictionary.Add(letterC);
            Dictionary.Add(letterb);
        }
    }
}
