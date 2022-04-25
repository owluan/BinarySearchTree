using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class Problem
    {
        public string initialState;
        public string finalState;
        public List<Action> actions;

        public Problem(string initialState, string finalState, List<Action> actions)
        {
            this.initialState = initialState;
            this.finalState = finalState;
            this.actions = actions;
        }
    }
}
