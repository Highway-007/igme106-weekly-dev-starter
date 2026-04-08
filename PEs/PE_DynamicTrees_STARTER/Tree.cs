using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PE_DynamicTrees
{
    /// <summary>
    /// DO NOT MODIFY EXCEPT WHERE MARKED "TODO"!
    /// 
    /// Represents a tree-centric data structure
    /// that can have data dynamically inserted based on the rules of a
    /// binary search tree, and can be drawn as a literal "tree" on the screen
    /// </summary>
    class Tree : DrawableTree
    {
        // Already has an inherited root node field called "root"

        /// <summary>
        /// Creates a tree that can be drawn
        /// </summary>
        /// <param name="sb">The sprite batch used to draw</param>
        /// <param name="treeColor">The color of this tree</param>
        public Tree(Color treeColor)
            : base(treeColor)
        { }

        /// <summary>
        /// Public facing Insert method
        /// </summary>
        /// <param name="data">The data to insert</param>
        public void Insert(int data)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement this method! - COMPLETED
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //If there is no root, make one!
            if(root == null)
            {
                root = new TreeNode(data);
            }
            else
            {
                //Otherwise call the private version of Insert
                Insert(data, root);
            }
        }

        /// <summary>
        /// Private recursive insert method. Data is inserted based on the rules
        /// of a binary search treee
        /// </summary>
        /// <param name="data">The data to insert</param>
        /// <param name="node">The node to attempt to insert into</param>
        private void Insert(int data, TreeNode node)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement this method! - COMPLETED
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //if the data is less than the current node's: go left
            if(node.Data > data)
            {
                //If there is no left child, make it
                //Base Case
                if(node.Left == null)
                {
                    node.Left = new TreeNode(data);
                }

                //otherwise, continue going down the tree
                else
                {
                    //Recursive step/State Change
                    Insert(data, node.Left);
                }
            }

            //If the data is equal or greater than the current node's: go right
            else
            {
                //if there is no right child, make one
                //Base case
                if(node.Right == null)
                {
                    node.Right = new TreeNode(data);
                }

                //Otherwise, continue down the tree
                else
                {
                    //Recursive step/State change
                    Insert(data, node.Right);
                }
            }
        }
    }
}
