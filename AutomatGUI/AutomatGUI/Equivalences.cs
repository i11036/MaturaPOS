using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatGUI
{
    class Equivalences
    {
        List<Equivalence> equivs;

        public Equivalences()
        {
            equivs = new List<Equivalence>();
        }

        public void Add(string state1, string state2)
        {
            foreach (Equivalence equiv in equivs)
            {
                if (equiv.Contains(state1) && !equiv.Contains(state2))
                {
                    equiv.Add(state2);
                    return;
                }
                else if (equiv.Contains(state2) && !equiv.Contains(state1))
                {
                    equiv.Add(state1);
                    return;
                }
                else if (equiv.Contains(state2) && equiv.Contains(state1))
                {
                    return;
                }
            }

            equivs.Add(new Equivalence(state1, state2));
        }

        public Equivalence GetEqual(string state)
        {
            foreach (Equivalence equiv in equivs)
            {
                if (equiv.Contains(state))
                {
                    return equiv;
                }
            }

            return null;
        }

        public string GetEquivName(string state)
        {
            foreach (Equivalence equiv in equivs)
            {
                if (equiv.Contains(state))
                {
                    return equiv.Name;
                }
            }

            return null;
        }

        public void Print()
        {
            foreach (Equivalence equiv in equivs)
            {
                equiv.Print();
            }
        }
    }
}
