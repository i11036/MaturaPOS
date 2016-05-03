using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatGUI
{
    class State
    {
        protected string name_;

        public string Name { get { return name_; } }
        public bool IsFinalState { get; set; }
        protected Dictionary<char, State> paths;

        public State(string name) : this(name, false) { }

        public State(string name, bool isEndState)
        {
            name_ = name;
            IsFinalState = isEndState;
            paths = new Dictionary<char, State>();
        }

        public State(State state)
        {
            name_ = state.Name;
            IsFinalState = state.IsFinalState;
            paths = new Dictionary<char, State>(state.paths);
        }

        public void AddPath(char token, State next)
        {
            paths[token] = next;
        }

        public State GetNext(char token)
        {
            if (paths.ContainsKey(token))
            {
                return paths[token];
            }
            return null;
        }

        public void UpdatePaths(Dictionary<string, State> states,
            Equivalences equivs)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                KeyValuePair<char, State> path = paths.ElementAt(i);
                string state = path.Value.Name;
                Equivalence equiv = equivs.GetEqual(state);

                if (equiv == null)
                {
                    // old state
                    if (states.ContainsKey(state))
                    {
                        paths[path.Key] = states[state];
                    }
                }
                else
                {
                    // combined state
                    if (states.ContainsKey(equiv.Name))
                    {
                        paths[path.Key] = states[equiv.Name];
                    }
                }
            }
        }

        public void UpdatePaths(Dictionary<string, State> states)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                KeyValuePair<char, State> path = paths.ElementAt(i);
                string state = path.Value.Name;

                if (states.ContainsKey(state))
                {
                    paths[path.Key] = states[state];
                }
            }
        }

        public bool Equals(State compare)
        {
            if (compare == null)
            {
                return false;
            }

            if (Name != compare.Name)
            {
                return false;
            }

            if (IsFinalState != compare.IsFinalState)
            {
                return false;
            }

            return true;
        }
    }
}