namespace CodingQuestions
{
    using System;
    public class InOrderTraversal : TreeTraversal, ISolution
    {
        public void Run()
        {
            this.InOrder(this.root);
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
    }
}