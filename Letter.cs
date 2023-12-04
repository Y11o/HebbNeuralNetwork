using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HebbNeuralNetwork
{
    internal class Letter
    {
        private List<int> x = new List<int>();
        private List<int> t = new List<int>();
        public List<int> X { get => x; set => x = value; }
        public List<int> T { get => t; set => t = value; }
    }
}
