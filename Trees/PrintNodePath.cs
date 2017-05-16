namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    public class PrintNodePath : TreeTraversal, ISolution
    {
        public void Run()
        {
            //List<int> path = new List<int>();
            //this.FindPath(this.root, 3, path);
            //path.Reverse();
            //path.ForEach(x => Console.WriteLine("{0},", x));
            //var paths = FindNodePath(this.root, 7);
            //var paths = GetNodePath(3);
            //paths.ForEach(x => Console.WriteLine("{0}", x));
            PrintNodePathIterative(this.root, 3);
        }

        private bool FindPath(TreeNode node, int target, List<int> path)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value == target ||
            FindPath(node.Left, target, path) ||
            FindPath(node.Right, target, path))
            {
                path.Add(node.Value);
                return true;
            }

            return false;
        }

        private List<string> FindNodePath(TreeNode node, int target)
        {
            List<string> path = new List<string>();
            if (node == null)
            {
                return path;
            }

            if (node.Value == target)
            {
                path.Add(node.Value.ToString());
            }
            else
            {
                FindNodePath(node.Left, target).ForEach(x => path.Add(string.Format("{0}->{1}", node.Value, x)));
                FindNodePath(node.Right, target).ForEach(x => path.Add(string.Format("{0}->{1}", node.Value, x)));
            }
            return path;
        }

        private List<string> GetNodePath(int target)
        {
            List<string> path = new List<string>();
            GetNodePath(this.root, target, "", path);
            return path;
        }

        private void GetNodePath(TreeNode node, int target, string path, List<string> paths)
        {
            if (node.Value == target) paths.Add(path + node.Value);
            if (node.Left != null) GetNodePath(node.Left, target, path + node.Value + "->", paths);
            if (node.Right != null) GetNodePath(node.Right, target, path + node.Value + "->", paths);
        }

        private void PrintNodePathIterative(TreeNode root, int target)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            Dictionary<TreeNode, TreeNode> parents = new Dictionary<TreeNode, TreeNode>();
            stack.Push(root);
            parents.Add(root, null);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                if (node.Value == target)
                {
                    PrintParents(node, parents);
                    break;
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                    parents[node.Left] = node;
                }

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                    parents[node.Right] = node;
                }
            }
        }

        public void PrintParents(TreeNode node, Dictionary<TreeNode, TreeNode> parents)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (node != null)
            {
                stack.Push(node);
                node = parents[node];
            }

            while (stack.Count != 0)
            {
                Console.Write("{0},", stack.Pop().Value);
            }

            Console.WriteLine();
        }
    }
}