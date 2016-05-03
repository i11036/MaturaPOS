using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatGUI
{
    class Equivalence
    {
        private List<string> equiv;

        public string Name
        {
            get
            {
                string name = "";

                foreach (string state in equiv)
                {
                    name += state;
                }

                return name;
            }
        }

        public Equivalence()
        {
            equiv = new List<string>();
        }

        public Equivalence(string state)
        {
            equiv = new List<string>();
            equiv.Add(state);
        }

        public Equivalence(string state1, string state2)
        {
            equiv = new List<string>();
            equiv.Add(state1);
            equiv.Add(state2);
            equiv.Sort();
        }

        public void Add(string state)
        {
            if (!equiv.Contains(state))
            {
                equiv.Add(state);
                equiv.Sort();
            }
        }

        public bool Contains(string state)
        {
            if (equiv.Contains(state))
            {
                return true;
            }
            return false;
        }

        public bool IsFirst(string state)
        {
            if (equiv.Count > 0)
            {
                return equiv[0] == state;
            }
            return false;
        }

        public string GetFirst()
        {
            if (equiv.Count > 0)
            {
                return equiv[0];
            }
            return null;
        }

        public void Print()
        {
            for (int i = 0; i < equiv.Count; i++)
            {
                Console.Write(equiv[i]);
                if (i + 1 < equiv.Count)
                {
                    Console.Write(" = ");
                }
            }
            Console.WriteLine();
        }
    }
}
