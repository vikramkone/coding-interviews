namespace CodingQuestions
{
    public class TreeTraversal
    {
        public class TreeNode
        {
            public TreeNode(int value)
            {
                this.Value = value;
            }

            public TreeNode Left;
            public TreeNode Right;
            public int Value;
        }

        protected TreeNode root; 

        public TreeTraversal()
        {
            TreeNode rootNode = new TreeNode(5);
            rootNode.Left = new TreeNode(2);
            rootNode.Left.Left = new TreeNode(1);
            rootNode.Left.Right = new TreeNode(4);
            rootNode.Left.Right.Left = new TreeNode(3);
            rootNode.Right = new TreeNode(6);
            rootNode.Right.Right = new TreeNode(8);
            rootNode.Right.Right.Left = new TreeNode(7);

            this.root = rootNode;
        }
    }
}