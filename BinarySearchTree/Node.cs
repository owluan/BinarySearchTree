using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class Node
    {
        public string nodeState;
        public Node nodeF;
        public int cost;
        public int depth;
        public int previousAction;

        public Node(string nodeState, Node nodeF, int cost, int depth, int previousAction)
        {
            this.nodeState = nodeState;
            this.nodeF = nodeF;
            this.cost = cost;
            this.depth = depth;
            this.previousAction = previousAction;
        }
    }
}
