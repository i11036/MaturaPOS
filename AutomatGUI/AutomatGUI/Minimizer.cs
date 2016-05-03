using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatGUI
{
    class Minimizer
    {
        private Dictionary<string, State> autStates;
        private List<char> autAlph;
        private Dictionary<string, Dictionary<string, bool>> equalStates;

        public Minimizer(Dictionary<string, State> states,
            List<char> alphabet)
        {
            autStates = new Dictionary<string, State>(states);
            autAlph = alphabet;
            equalStates = new Dictionary<string, Dictionary<string, bool>>();

            foreach (string state1 in states.Keys)
            {
                foreach (string state2 in states.Keys)
                {
                    if (state1.CompareTo(state2) < 0)
                    {
                        Set(state1, state2, true);
                    }
                }
            }
        }

        public Equivalences Evaluate()
        {
            bool changed = true;

            while (changed)
            {
                changed = false;

                foreach (string state1 in autStates.Keys)
                {
                    foreach (string state2 in autStates.Keys)
                    {
                        if (state1.CompareTo(state2) < 0
                            && Get(state1, state2))
                        {
                            changed = Compare(state1, state2);
                        }
                    }
                }
            }

            Equivalences equivs = new Equivalences();

            foreach (string state1 in autStates.Keys)
            {
                foreach (string state2 in autStates.Keys)
                {
                    if (state1.CompareTo(state2) < 0
                        && Get(state1, state2))
                    {
                        equivs.Add(state1, state2);
                    }
                }
            }

            return equivs;
        }

        private bool Compare(string state1, string state2)
        {
            Console.WriteLine();
            Console.WriteLine("Evaluating...\t\t{0} - {1}",
                                state1, state2);

            if (autStates[state1].IsFinalState
                != autStates[state2].IsFinalState)
            {
                if (Get(state1, state2))
                {
                    Console.WriteLine(
                        "Unequal termintaion:\t{0} - {1}",
                       state1, state2);
                    Set(state1, state2, false);
                    return true;
                }
            }
            else
            {
                if (autAlph != null)
                {
                    foreach (char token in autAlph)
                    {
                        Console.WriteLine("Checking token {0} for\t{1} - {2}",
                            token, state1, state2);
                        State state1Next = autStates[state1].GetNext(token);
                        State state2Next = autStates[state2].GetNext(token);

                        if (!Get(state1Next.Name, state2Next.Name))
                        {
                            Set(state1, state2, false);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool Get(string state1, string state2)
        {
            if (state1.CompareTo(state2) > 0)
            {
                string h = state1;
                state1 = state2;
                state2 = h;
            }

            if (state1 == state2)
            {
                return true;
            }

            if (equalStates.ContainsKey(state1)
                && equalStates[state1].ContainsKey(state2))
            {
                return equalStates[state1][state2];
            }

            return false;
        }

        private void Set(string state1, string state2, bool equal)
        {
            if (state1.CompareTo(state2) > 0)
            {
                string h = state1;
                state1 = state2;
                state2 = h;
            }

            if (!equalStates.ContainsKey(state1))
            {
                equalStates[state1] = new Dictionary<string, bool>();
            }

            equalStates[state1][state2] = equal;
        }
    }
}
