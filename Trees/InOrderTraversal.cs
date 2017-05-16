namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;

    public class InOrderTraversal : TreeTraversal, ISolution
    {
        public void Run()
        {
            this.InOrderIterative(this.root);
        }

        private void InOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            this.InOrder(node.Left);
            Console.WriteLine(node.Value);
            this.InOrder(node.Right);
        }

        private void InOrderIterative(TreeNode root)
        {
            Stack<TreeNode> Stack = new Stack<TreeNode>();

            TreeNode node = root;
            while (node != null)
            {
                Stack.Push(node);
                node = node.Left;
            }

            while (Stack.Count != 0)
            {
                node = Stack.Pop();
                Console.WriteLine(node.Value);

                if (node.Right != null)
                {
                    node = node.Right;

                    while (node != null)
                    {
                        Stack.Push(node);
                        node = node.Left;
                    }
                }
            }
        }
    }
}