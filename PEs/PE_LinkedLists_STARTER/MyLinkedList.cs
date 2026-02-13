namespace PE_LinkedLists
{
    /// <summary>
    /// A custom linked list.
    /// </summary>
    /// <typeparam name="T">This list is NOT sorted, but it requires types to implement IComparable
    /// so that later we can wrap this and make a custom sorted LL</typeparam>
    class MyLinkedList<T> where T : IComparable
    {
        // *******************************************************************************
        // DO NOT CHANGE/ADD TO THE CLASS FIELDS!
        // *******************************************************************************

        // Don't want to lose the chain of nodes, so track the head of the chain
        private MyLinkedNode<T> head = null;

        // *******************************************************************************
        // Properties and indexers
        // *******************************************************************************

        /// <summary>
        /// Auto-properties automatically create backing fields for us. In this case,
        /// it it only allows the underlying field for the count to be set within this
        /// class.
        /// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add an indexer that allows get and set access to the data within 
        /// an existing node by index. For both get & set, make sure to throw an 
        /// IndexOutOfRangeException if the index given is out of range based on 
        /// the current count of the list.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                // TODO: Implement the get for the indexer
                MyLinkedNode<T> currNode;

                // Check the index
                if (index < Count)
                {
                    // Start at the head
                    currNode = new MyLinkedNode<T>(head.Data);
                    currNode.Next = head.Next;

                    // Hop down the chain index # of times
                    for (int i = 0; i < index; i++)
                    {
                        currNode = currNode.Next;
                    }

                    // Return the data where we stopped
                    return currNode.Data;
                    

                }
                throw new IndexOutOfRangeException();

                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            set
            {
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                // TODO: Implement the set for the indexer
                MyLinkedNode<T> currNode;

                // Check the index
                if (index < Count)
                {
                    // Start at the head
                    currNode = new MyLinkedNode<T>(head.Data);
                    currNode.Next = head.Next;

                    // Hop down the chain index # of times
                    for (int i = 0; i < index; i++)
                    {
                        currNode = currNode.Next;
                    }

                    // Return the data where we stopped
                    currNode.Data = value;

                }
                throw new IndexOutOfRangeException();
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
        }

        /// <summary>
        /// Add a new node with given data to the END of the list
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement the Add method
            // Adding to an empty list, set the head
            MyLinkedNode<T> currNode;

            if (Count == 0)
            {
                head = new MyLinkedNode<T>(data);
            }

            // Adding to the end of a non - empty list!
            else
            {
                // We need to find the end first - and we have to start at head to do that
                currNode = head;
                do
                {
                    // Hop down the chain of nodes until we hit the end (i.e. the node with no next)
                    if(currNode.Next == null)
                    {
                        // Now make that last node refer to the new one
                        currNode.Next = new MyLinkedNode<T>(data);
                        currNode = new MyLinkedNode<T>(currNode.Data);
                        break;
                    }
                    //If it isnt the end, keep searching
                    else
                    {
                        currNode = currNode.Next;
                    }
                }
                while (currNode.Next != null);
            }

            // No matter how we added, update the count
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            Count++;
        }

        /// <summary>
        /// Look for the node with a specific piece of data and remove it
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement the Remove method
            MyLinkedNode<T> currNode;

            // Quit if nothing to remove
            if (Count == 0)
            {
                return false;
            }

            // If the data is at the head, change head to reference head's Next, 
            // reduce the count, and return true
            else if(head.Data.Equals(data))
            {
                head = head.Next;
                Count--;
                return true;
            }

            // If it's after head (anywhere after head), we have to search for it
            currNode = head;

            // Hop down the chain checking if we found what to remove as we go
            do
            {
                // We actually want to check if we're removing the node AFTER the one
                // we're currently on.
                if (currNode.Next.Equals(data))
                {
                    currNode.Next = new MyLinkedNode<T>(currNode.Next.Next.Data);
                    break;
                }
                //If it isnt the end, keep searching
                else
                {
                    currNode = new MyLinkedNode<T>(currNode.Next.Data);
                }
            }
            while (currNode.Next != null);

            // If we got this far, we didn't find anything to remove
            return false;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        /// <summary>
        /// Clear the LL by abandoning all the nodes
        /// </summary>
        public void Clear()
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Implement the Clear method. You do NOT need a loop here!!!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            head.Next = null;
            head.Data = default(T);
        }
    }
}
