using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatGUI
{
    class Automat
    {
        private static readonly string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data "
            + @"Source=C:\Users\Paul\Documents\AutomatTest.accdb";

        protected Dictionary<string, State> states;
        protected State initState;
        protected List<char> alphabet;

        public Automat()
        {
            Reset();
        }

        public void SetAlphabet(List<char> tokens)
        {
            alphabet = new List<char>(tokens);
        }

        public void SetAlphabet(string tokens)
        {
            alphabet = new List<char>(tokens);
        }

        public void SetAlphabet(char[] tokens)
        {
            alphabet = new List<char>(tokens);
        }

        public void Reset()
        {
            states = new Dictionary<string, State>();
            initState = null;
            alphabet = new List<char>();
        }

        public bool CheckInput(string input)
        {
            int index = 0;
            State state = initState;

            while (state != null && index < input.Length)
            {
                char token = input.Substring(index, 1).ToCharArray()[0];
                state = state.GetNext(token);

                index++;
            }

            if (state != null && state.IsFinalState)
            {
                return true;
            }

            return false;
        }

        public bool AddState(string name, bool isEnd = false, bool isBegin = false)
        {
            if (!states.ContainsKey(name))
            {
                State newState = new State(name, isEnd);
                states.Add(name, newState);

                if (isBegin)
                {
                    initState = newState;
                }

                return true;
            }

            return false;
        }

        public void AddPath(string fromState, string toState, char token)
        {
            if (states.ContainsKey(fromState) && states.ContainsKey(toState))
            {
                states[fromState].AddPath(token, states[toState]);
            }
        }

        public void Import()
        {
            ImportStates();
            ImportPaths();
        }

        public void ImportStates()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(
                    "select * from State;", conn);

                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string stateName = (string)reader["StateID"];
                        bool isStart = (bool)reader["IsStart"];
                        bool isEnd = (bool)reader["IsEnd"];

                        AddState(stateName, isEnd, isStart);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: Database connection failed");
            }
        }

        public void ImportPaths()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand(
                    "select * from Path;", conn);

                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string fromState = (string)reader["FromState"];
                        string toState = (string)reader["ToState"];
                        string token = (string)reader["Token"];

                        AddPath(fromState, toState, token.ToCharArray()[0]);
                        AddToken(token.ToCharArray()[0]);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error: Database connection failed");
            }
        }

        public void Minimize()
        {
            Minimizer min = new Minimizer(states, alphabet);
            Equivalences equivs = min.Evaluate();
            Combine(equivs);
        }

        private void Combine(Equivalences equivs)
        {
            if (equivs != null)
            {
                equivs.Print();
                Dictionary<string, State> newStates =
                    new Dictionary<string, State>();
                State newInitState = null;

                foreach (State state in states.Values)
                {
                    Equivalence equiv = equivs.GetEqual(state.Name);
                    State newState = null;

                    if (equiv == null)
                    {
                        newState = new State(state);
                        newStates[state.Name] = newState;
                    }
                    else
                    {
                        string equivName = equivs.GetEquivName(state.Name);

                        if (equiv.IsFirst(state.Name))
                        {
                            newState = new State(equivName, state.IsFinalState);
                            newStates[newState.Name] = newState;
                        }
                        else
                        {
                            newState = newStates[equivName];
                        }
                    }

                    if (state.Equals(initState))
                    {
                        newInitState = newState;
                    }
                }

                AddNewPaths(newStates, equivs);

                states = newStates;
                initState = newInitState;

                foreach (State state in states.Values)
                {
                    state.UpdatePaths(states, equivs);
                }
            }
        }

        /*
            Add paths to all combined states.
        */
        private void AddNewPaths(Dictionary<string, State> newStates,
            Equivalences equivs)
        {
            foreach (string state in states.Keys)
            {
                Equivalence equalStates = equivs.GetEqual(state);

                if (equalStates != null)
                {
                    string first = equalStates.GetFirst();

                    if (first != null)
                    {
                        AddNewPaths(newStates, equivs, first);
                    }
                }
            }
        }

        /*
            Add paths to the given combined states.
        */
        private void AddNewPaths(Dictionary<string, State> newStates,
            Equivalences equivs, string state)
        {
            foreach (char token in alphabet)
            {
                if (states.ContainsKey(state))
                {
                    State next =
                        states[state].GetNext(token);

                    if (next != null)
                    {
                        Equivalence fromEquiv =
                            equivs.GetEqual(state);
                        Equivalence toEquiv =
                            equivs.GetEqual(next.Name);

                        if (fromEquiv != null)
                        {
                            if (toEquiv != null)
                            {
                                newStates[fromEquiv.Name].AddPath(
                                    token, newStates[toEquiv.Name]);
                            }
                            else
                            {
                                newStates[fromEquiv.Name].AddPath(
                                    token, newStates[next.Name]);
                            }
                        }
                    }
                }
            }
        }

        protected void AddToken(char token)
        {
            if (!alphabet.Contains(token))
            {
                alphabet.Add(token);
            }
        }

        public void Show()
        {
            string output = "";

            output += "States:\n";
            foreach (var state in states.Values)
            {
                output += ("[" + state.Name + "]\nIsEndState: " + state.IsFinalState + "\n");
                output += ("IsGui: " + (state is GuiState).ToString() + "\n");
            }

            output += "BeginState:" + initState.Name;
            MessageBox.Show(output);
        }
    }
}
