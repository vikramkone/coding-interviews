namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    public class PrintLeafPaths : TreeTraversal, ISolution
    {
        public void Run()
        {
            //var paths = this.FindLeafPaths(this.root);
            // paths.ForEach(x => Console.WriteLine(x));
            //List<TreeNode> path = new List<TreeNode>();
            //PrintAllPossiblePath(this.root, path);
            //var paths = binaryTreePaths(this.root);
            //paths.ForEach(x => Console.WriteLine(x));

            PrintLeafPathsNoRecursion(this.root);
        }

        private List<string> FindLeafPaths(TreeNode node)
        {
            List<string> path = new List<string>();
            if (node == null)
            {
                return path;
            }

            if (node.Left == null && node.Right == null)
            {
                path.Add(node.Value.ToString());
            }
            else
            {
                FindLeafPaths(node.Left).ForEach(x => path.Add(string.Format("{0}->{1}", node.Value, x)));
                FindLeafPaths(node.Right).ForEach(x => path.Add(string.Format("{0}->{1}", node.Value, x)));
            }
            return path;
        }

        public void PrintAllPossiblePath(TreeNode node, List<TreeNode> nodelist)
        {
            if (node != null)
            {
                nodelist.Add(node);
                if (node.Left != null)
                {
                    PrintAllPossiblePath(node.Left, nodelist);
                }
                if (node.Right != null)
                {
                    PrintAllPossiblePath(node.Right, nodelist);
                }
                else if (node.Left == null && node.Right == null)
                {
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        Console.Write("{0},", nodelist[i].Value);
                    }
                    Console.WriteLine();
                }
                nodelist.Remove(node);
            }
        }

        public List<String> binaryTreePaths(TreeNode root)
        {
            List<String> paths = new List<String>();
            if (root != null) searchBT(root, "", paths);
            return paths;
        }
        private void searchBT(TreeNode root, String path, List<String> paths)
        {
            if (root.Left == null && root.Right == null) paths.Add(path + root.Value);
            if (root.Left != null) searchBT(root.Left, path + root.Value + "->", paths);
            if (root.Right != null) searchBT(root.Right, path + root.Value + "->", paths);
        }

        public void PrintLeafPathsNoRecursion(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            Dictionary<TreeNode, TreeNode> parents = new Dictionary<TreeNode, TreeNode>();
            stack.Push(root);
            parents.Add(root, null);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                if (node.Left == null && node.Right == null)
                {
                    PrintParents(node, parents);
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
