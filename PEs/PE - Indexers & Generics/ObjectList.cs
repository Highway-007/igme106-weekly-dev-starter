using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___Indexers___Generics
{
    internal class ObjectList<T>
    {
        //Fields
        private List<T> rawData = new List<T> { };

        //Properties
        /// <summary>
        /// A get only property for the number of items in rawData
        /// </summary>
        public int Count {  get { return rawData.Count; } }

        /// <summary>
        /// public indexer for a generic list rawData, allows the getting and setting of an item in rawData as long as it exists
        /// </summary>
        /// <param name="name">the value used to search for an item or set an item's value</param>
        /// <exception cref="KeyNotFoundException">thrown if an item with the value's name is not found</exception>
        public T this[string name]
        {
            get 
            {
                foreach(T item in rawData)
                {
                    if (item.ToString() == name)
                    {
                        return item;
                    }
                }
                throw new KeyNotFoundException();
            }

            set 
            {
                for(int i = 0; i < rawData.Count; i++)
                {
                    if (rawData[i].ToString() == name)
                    {
                        rawData[i] = value;
                    }
                }
                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Returns a list of names of the objects in the list as an IEnumerable.
        /// Doing this instead of returning the list directly prevents the caller 
        /// from modifying the list.
        /// </summary>
        public IEnumerable<String> Names
        {
            get
            {
                List<String> names = new List<String>();
                foreach (T item in rawData)
                {
                    names.Add(item.ToString());
                }
                return names.AsEnumerable();
            }
        }

        //Don't need constructors here
        //Methods

        /// <summary>
        /// Public method which uses a generic T parameter to add a generic item to rawData
        /// if an item with that name already exists, throws an agrument exception
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <exception cref="ArgumentException">Thrown if the item's name already is in rawData</exception>
        public void Add(T item)
        {
            foreach(T thing in rawData)
            {
                if(thing.ToString() == item.ToString())
                {
                    throw new ArgumentException();
                }
            }
            rawData.Add(item);
        }
    }
}
