using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class Action
    {
        public string initialState;
        public string finalState;
        public int action;
        public int actionCost;

        public Action(string initialState, string finalState, int action, int actionCost)
        {
            this.initialState = initialState;
            this.finalState = finalState;
            this.action = action;
            this.actionCost = actionCost;
        }
    }
}
