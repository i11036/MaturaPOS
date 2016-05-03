using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatGUI
{
    class GuiAutomat : Automat
    {
        private GuiState moveState;
        private GuiState fromState;

        public bool Moving
        {
            get { return moveState != null; }
        }

        public bool Connecting
        {
            get { return fromState != null; }
        }

        public GuiAutomat() : base()
        {
            moveState = null;
            fromState = null;
        }

        public void Paint(Graphics g)
        {
            foreach (State state in states.Values)
            {
                if (state is GuiState)
                {
                    ((GuiState)state).Paint(g);
                }
            }
        }

        public void InitGui()
        {
            for (int i = 0; i < states.Count; i++)
            {
                KeyValuePair<string, State> state = states.ElementAt(i);
                if (!(state.Value is GuiState))
                {
                    states[state.Key] = new GuiState(state.Value);
                }
            }

            foreach (State state in states.Values)
            {
                state.UpdatePaths(states);
            }
        }

        public bool AddState(string name, int x, int y, bool isEnd = false,
            bool isBegin = false)
        {
            if (!states.ContainsKey(name))
            {
                GuiState newState = new GuiState(name, x, y, isEnd);
                states.Add(name, newState);

                if (isBegin)
                {
                    initState = newState;
                }

                return true;
            }

            return false;
        }

        private GuiState GetState(int x, int y)
        {
            foreach (State state in states.Values)
            {
                if (state is GuiState)
                {
                    GuiState guiState = ((GuiState)state);

                    if (guiState.Contains(x, y))
                    {
                        moveState = guiState;
                        return guiState;
                    }
                }
            }

            return null;
        }

        public void BeginMove(int x, int y)
        {
            moveState = GetState(x, y);
        }

        public void Move(int x, int y)
        {
            if (moveState != null)
            {
                moveState.MoveTo(x, y);
            }
        }

        public void EndMove()
        {
            moveState = null;
        }

        public void BeginConnect(int x, int y)
        {
            fromState = GetState(x, y);
        }

        public bool EndConnect(int x, int y, char token)
        {
            GuiState toState = GetState(x, y);

            if (toState != null)
            {
                AddPath(fromState.Name, toState.Name, token);
                return true;
            }

            fromState = null;
            return false;
        }
    }
}
