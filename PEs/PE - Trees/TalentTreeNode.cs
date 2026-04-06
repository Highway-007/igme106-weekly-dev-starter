using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Trees
{
    internal class TalentTreeNode
    {
        //Fields
        private string name;
        private bool learned;
        private TalentTreeNode left;
        private TalentTreeNode right;

        //Properties
        /// <summary>
        /// A get only property for the name value
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// A get only property for the Learned boolean field
        /// </summary>
        public bool Learned
        {
            get { return learned; }
        }

        /// <summary>
        /// A get and set property for the left node, allows moving between nodes
        /// </summary>
        public TalentTreeNode Left
        {
            get { return left; }
            set { left = value; }
        }

        /// <summary>
        /// A get and set property for the right node, allows moving between nodes
        /// </summary>
        public TalentTreeNode Right
        {
            get { return right; }
            set { right = value; }
        }

        /// <summary>
        /// Constructor for the current TalentTreeNode
        /// </summary>
        /// <param name="data">The name of the ability</param>
        /// <param name="learned">if the ability is learned</param>
        public TalentTreeNode(string data, bool learned) 
        {
            name = data;
            left = null;
            right = null;
            this.learned = learned;
        }

        /// <summary>
        /// A recursive method to print every node in order
        /// </summary>
        public void ListAllAbilities()
        {
            //in order traversal, all lefts before rights, then work your way up
            if(left != null)
            {
                //recursive step/State change
                left.ListAllAbilities();
            }

            //Base Case
            Console.WriteLine(name);

            if (right != null)
            {
                //recursive step/State change
                right.ListAllAbilities();
            }
        }

        /// <summary>
        /// A recursive method to print every node that has been learned
        /// </summary>
        public void ListKnownAbilities()
        {
            if (learned)
            {
                //Base Case
                Console.WriteLine("Known Ability: " + name);
            }

            if (left != null && left.learned)
            {
                //recursive step/State change
                left.ListKnownAbilities();
            }
            if (right != null && right.learned)
            {
                right.ListKnownAbilities();
            }

            //No need to check unlearned nodes, as their children also cant be learned
        }

        /// <summary>
        /// A recursive method to print every node that has a parent where learned is true
        /// </summary>
        public void ListPossibleAbilities()
        {
            if (learned)
            {
                //Recursive Case/State Change
                left.ListPossibleAbilities();
                right.ListPossibleAbilities();
            }

            if (learned && right != null && !right.learned)
            {
                //Base case
                Console.WriteLine("Possible Ability: " + right.name);
            }

            if(learned && left != null && !left.learned)
            {
                //base case
                Console.WriteLine("Possible Ability: " + left.name);
            }
        }
    }
}
