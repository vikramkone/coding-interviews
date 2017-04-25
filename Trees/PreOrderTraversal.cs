namespace CodingQuestions
{
    using System;
    public class PreOrderTraversal : TreeTraversal, ISolution
    {
        public void Run()
        {
            this.PreOrder(this.root);
        }

        private void PreOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Value);
            this.PreOrder(node.Left);
            this.PreOrder(node.Right);
        }
    }
}