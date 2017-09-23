namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;

    public class IsBinarySearchTree : TreeTraversal, ISolution
    {
        public void Run()
        {
            Console.WriteLine("Is BST? {0}", this.IsBST(this.root, Int32.MinValue, Int32.MaxValue));
        }

        private bool IsBST(TreeNode node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }

            if (node.Value <= min || node.Value >= max)
            {
                return false;
            }

            return this.IsBST(node.Left, min, node.Value) && this.IsBST(node.Right, node.Value, max);
        }
    }
}