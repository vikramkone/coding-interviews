namespace CodingQuestions
{
    using System;
    public class PostOrderTraversal : TreeTraversal, ISolution
    {
        public void Run()
        {
            this.PostOrder(this.root);
        }

        private void PostOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            this.PostOrder(node.Left);
            this.PostOrder(node.Right);
            Console.WriteLine(node.Value);
        }
    }
}