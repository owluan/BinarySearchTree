using BinarySearchTree;
using System;
using System.Collections.Generic;
using Action = BinarySearchTree.Action;

/*
 * UNCISAL
 * Sistemas para Internet - 4º Período
 * Disciplina: Inteligência Artificial
 * Prof: Edileuza Virginio Leão
 * Projeto: Busca em Árvore(Search Shortest Path)
 * Feito por: Luan Acioly
 */
namespace BinarySearchTree
{

    public class BinarySearchTree
    {
        public static void Main(string[] args)
        {

            Stack<Node> stack = new Stack<Node>();
            List<Action> route = new List<Action>();

            Console.WriteLine("Digite o estado de origem (AL, SE, PE, PB, BA, CE, PI, MA, RN):");
            string initial = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite o estado destino (AL, SE, PE, PB, BA, CE, PI, MA, RN):");
            string final = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");

            Problem p = new Problem(initial, final, route);


            Action
            act = new Action("BA", "SE", 1, 320);
            route.Add(act);
            act = new Action("SE", "AL", 2, 270);
            route.Add(act);
            act = new Action("AL", "PE", 5, 250);
            route.Add(act);
            act = new Action("PE", "PB", 7, 120);
            route.Add(act);
            act = new Action("PB", "RN", 9, 180);
            route.Add(act);
            act = new Action("RN", "CE", 10, 550);
            route.Add(act);
            act = new Action("CE", "PI", 11, 790);
            route.Add(act);
            act = new Action("PB", "PI", 8, 1160);
            route.Add(act);
            act = new Action("PE", "PI", 6, 1130);
            route.Add(act);
            act = new Action("AL", "PI", 4, 1120);
            route.Add(act);
            act = new Action("SE", "PI", 3, 1112);
            route.Add(act);
            act = new Action("PI", "MA", 12, 800);
            route.Add(act);                                

            searchShortestPath(p, stack);
            Console.ReadKey();

        }

        public static void searchShortestPath(Problem p, Stack<Node> path)
        {            
            path.Push(new Node(p.initialState, null, 0, 0, 0));
            List<Node> checkedNodes = new List<Node>();

            while (path.Count > 0)
            {
                Node currentNode = path.Pop();
                Console.WriteLine();
                Console.WriteLine("Nó verificado: " + currentNode.nodeState);
                if (currentNode.nodeState == p.finalState)
                {
                    Console.WriteLine("Cheguei no meu destino!!!!!!");
                    Console.WriteLine("Ação que foi aplicada ao pai para gerar o nó: " + currentNode.previousAction);
                    Console.WriteLine("Distância: " + currentNode.cost + "km");
                    Console.WriteLine("Profundidade: " + currentNode.depth);
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------");
                    traveledPath(currentNode);
                    break;
                }
                else
                {
                    checkedNodes.Add(currentNode);
                    Console.WriteLine();
                    Console.WriteLine("Não é o destino final!");
                    Console.WriteLine("Destinos possíveis a partir de: " + currentNode.nodeState);
                    expandNode(currentNode, p.actions, path, checkedNodes);
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------");

                }
            }

        }


        public static void expandNode(Node n, List<Action> actions, Stack<Node> path, List<Node> checkedNodes)
        {
            foreach (Action act in actions)
            {
                if (act.initialState == n.nodeState)
                {
                    bool finish = false;
                    Node expandedNode = new Node(act.finalState, n, n.cost + act.actionCost, n.depth + 1, act.action);
                    Console.WriteLine("-> " + expandedNode.nodeState);
                    foreach (Node node in checkedNodes)
                    {
                        if (node.nodeState == expandedNode.nodeState)
                        {
                            finish = true;
                            break;
                        }
                    }
                    if (!finish)
                    {
                        path.Push(expandedNode);
                    }
                }
            }
        }

        public static void traveledPath(Node n)
        {
            Console.WriteLine();
            Console.WriteLine("Caminho percorrido para chegar ao destino final:");
            while (n != null)
            {
                Console.WriteLine("-> " + n.nodeState);
                n = n.nodeF;
            }
        }

    }

}
