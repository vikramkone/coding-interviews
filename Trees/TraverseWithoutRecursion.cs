using System;

namespace BST
{
    public partial class TraverseWithoutRecursion
    {
        public static void PrintInOrder(BNode node)
        {
            BNode curr = node;
            BNode next = null;
            BNode prev = null;

            while (curr != null)
            {
                if (curr.parent == prev)
                {
                    if (curr.left != null)
                    {
                        next = curr.left;
                    }
                    else
                    {
                        Console.WriteLine(curr.item + " ");
                        next = curr.right != null ? curr.right : curr.parent;
                    }
                }
                else
                {
                    if (curr.left == prev)
                    {
                        Console.WriteLine(curr.item + " ");
                        next = curr.right != null ? curr.right : curr.parent;
                    }
                    else
                    {
                        next = curr.parent;
                    }
                }

                prev = curr;
                curr = next;
            }
        }

        public static void PrintPreOrder(BNode node)
        {
            BNode curr = node;
            BNode next = null;
            BNode prev = null;

            while (curr != null)
            {
                if (curr.parent == prev)
                {
                    Console.WriteLine(curr.item + " ");

                    if (curr.left != null)
                    {
                        next = curr.left;
                    }
                    else
                    {
                        next = curr.right != null ? curr.right : curr.parent;
                    }
                }
                else
                {
                    if (curr.left == prev)
                    {
                        next = curr.right != null ? curr.right : curr.parent;
                    }
                    else
                    {
                        next = curr.parent;
                    }
                }

                prev = curr;
                curr = next;
            }
        }

        public static void PrintPostOrder(BNode node)
        {
            BNode curr = node;
            BNode next = null;
            BNode prev = null;

            while (curr != null)
            {
                if (curr.parent == prev)
                {
                    if (curr.left != null)
                    {
                        next = curr.left;
                    }
                    else
                    {
                        if (curr.right != null)
                        {
                            next = curr.right;
                        }
                        else
                        {
                            Console.WriteLine(curr.item + " ");
                            next = curr.parent;
                        }
                    }
                }
                else
                {
                    if (curr.left == prev)
                    {
                        if (curr.right != null)
                        {
                            next = curr.right;
                        }
                        else
                        {
                            next = curr.parent;
                        }
                    }
                    else
                    {
                        Console.WriteLine(curr.item + " ");
                        next = curr.parent;
                    }
                }

                prev = curr;
                curr = next;
            }
        }
    }
}
