using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Stacks___Queues
{
    internal class MyQueue<T> : IQueue<T>
    {
        //Fields
        private int count;
        List<T>? queue;

        //Properties
        /// <summary>
        /// Gets the current count of items in the queue
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Gets whether or not there are items in the queue
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        //Constructor
        /// <summary>
        /// Sets count to 0 when stack is created
        /// </summary>
        public MyQueue()
        {
            count = 0;
            queue = new List<T>();
        }

        //Methods
        /// <summary>
        /// Removes and returns the data in the front
        /// of the queue.  Returns the default
        /// value of T or throws an exception if the queue is empty
        public T Dequeue()
        {
            T toRemove;

            if (!IsEmpty)
            {
                //Remove first item
                toRemove = queue[0];
                queue.RemoveAt(0);

                //Decrement count
                count--;

                //return removed item
                return toRemove;
            }

            //If you've reached this point, the stack is empty
            return default(T);
            throw new Exception();
        }


        /// <summary>
        /// Adds new data to the end of the queue.
        /// </summary>
        /// <param name="item">The data to add</param>
        public void Enqueue(T item)
        {
            //add item
            queue.Add(item);

            //increase count
            count++;
        }

        /// <summary>
        /// Look at and return the front of the queue. Returns the default
        /// value of T or throws an exception if the queue is empty.
        /// </summary
        public T Peek()
        {
            if (!IsEmpty)
            {
                return queue[0];
            }

            //If you've reached this point, the stack is empty
            return default(T);
            throw new Exception();
        }

    }
}

