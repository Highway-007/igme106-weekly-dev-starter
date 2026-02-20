using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Stacks___Queues
{
    internal class MyStack<T> : IStack<T>
    {
        //Fields
        private int count;
        List<T>? stack;

        //Properties
        /// <summary>
        /// Gets the current count of items in the stack
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Gets whether or not there are items in the stack
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
        public MyStack()
        {
            count = 0;
            stack = new List<T>();
        }

        //Methods
        /// <summary>
        /// Removes and returns the data on top
        /// of the stack.  Returns the default
        /// value of T or throws an exception if the stack is empty.
        /// </summary>
        public T Pop()
        {
            T toRemove;
            if (!IsEmpty)
            {
                //Remove last item
                toRemove = stack[count - 1];
                stack.RemoveAt(count - 1);

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
        /// Adds new data to the top of the stack.
        /// </summary>
        /// <param name="item">The data to add</param>
        public void Push(T item)
        {
            //add item
            stack.Add(item);

            //increase count
            count++;
        }

        /// <summary>
        /// Look at and return the top of the stack. Returns the default
        /// value of T or throws an exception if the stack is empty.
        /// </summary
        public T Peek()
        {
            if(!IsEmpty)
            {
                return stack[count - 1];
            }

            //If you've reached this point, the stack is empty
            return default(T);
            throw new Exception();
        }

    }
}
