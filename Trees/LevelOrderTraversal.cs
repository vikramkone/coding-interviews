namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    
    public class LevelOrderTraversal : TreeTraversal, ISolution
    {
        public void Run()
        {
            this.LevelOrder(this.root);
        }

        private void LevelOrder(TreeNode node)
        {
            Queue<TreeNode> queueue = new Queue<TreeNode>();

            queueue.Enqueue(node);

            while (queueue.Count != 0)
            {
                TreeNode current = queueue.Dequeue();
                Console.WriteLine(current.Value);

                if (current.Left != null)
                {
                    queueue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queueue.Enqueue(current.Right);
                }
            }
        }
    }
}