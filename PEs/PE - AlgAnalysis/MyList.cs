using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE___AlgAnalysis
{
    internal class MyList
    {
            // Private fields. Do not ever share a reference directly to the rawData list!
            private List<int> rawData;
            private bool keepSorted = false;

            /// <summary>
            /// Provides the number of elements in the list.
            /// </summary>
            public int Count
            {
                get { return rawData.Count; }
            }

            /// <summary>
            /// Create a new list, specifying whether it should be kept sorted.
            /// </summary>
            public MyList(bool keepSorted = false)
            {
                this.keepSorted = keepSorted;
                rawData = new List<int>();
            }

            /// <summary>
            /// Add the provided value to the list (in the correct position if sorted).
            /// </summary>
            public void Add(int value)
            {
                // TODO: What is the Big O of Add when... and why...
                //     (a) not keeping the list sorted?
                //          -The Big O is O(n) because keeping the list unsorted simply just add the value, but it still must check if the list is sorted or not
                //     (b) keeping it sorted?
                //          -The Big O is O(n^2) As in its worst case it goes through every value of n for each added value

                // NOTE: Neither of these is O(1). Think about what Add has to do under the hood
                // even on an unsorted List<>
                if (keepSorted)
                {
                    bool added = false;
                    for (int i = 0; i < rawData.Count; i++)
                    {
                        if (value < rawData[i])
                        {
                            added = true;
                            rawData.Insert(i, value);
                            break;
                        }
                    }
                    if (!added)
                    {
                        rawData.Add(value);
                    }
                }
                else
                {
                    rawData.Add(value);
                }
            }

            /// <summary>
            /// If this is an unsorted list, inserts the provided value at the given index.
            /// If sorted, throws an InvalidOperationException.
            /// </summary>
            public void Insert(int index, int value)
            {
                if (keepSorted)
                {
                    // TODO: Why can't we allow insertion by index in a sorted list?
                    throw new InvalidOperationException(
                        "Insertion by index not allowed on sorted Lists.");

                }
                else
                {
                    rawData.Insert(index, value);
                }
            }

            /// <summary>
            /// Determine if the list contains the provided value by seeing if it exists at a valid index.
            /// </summary>
            public bool Contains(int value)
            {
                return IndexOf(value) >= 0;
            }

            /// <summary>
            /// If this is an unsorted list, sets the value at the given index to the provided value.
            /// If sorted, throws an InvalidOperationException.
            /// </summary>
            public void Set(int index, int value)
            {
                if (keepSorted)
                {
                    // TODO: Why can't we allow set by index in a sorted list?
                    throw new InvalidOperationException(
                        "Set by index not allowed on sorted Lists.");

                }
                else
                {
                    rawData[index] = value;
                }
            }

            /// <summary>
            /// Find the index of the provided value in the list if it exists. Otherwise, returns -1;
            /// </summary>
            public int IndexOf(int value)
            {
            // TODO: What is the Big O of IndexOf when... and why...
            //     (a) not keeping the list sorted?
            //          -The Big O is O(log(n)) as it uses the BinarySearch method, which at its worst continues to cut the list in half searching for the value
            //     (b) keeping it sorted?
            //          -The Big O is O(n - 1) as it uses the built in IndexOf method, which just brute forces through each index

            // If the list isn't sorted, we can just use the built-in IndexOf method
            // to search through the list.
            if (!keepSorted)
                {
                    return rawData.IndexOf(value);
                }
                else
                {
                    // If the list is sorted, we can use a binary search to find the index
                    // of the value in the list. Kick it off by telling it to search the
                    // entire list.
                    return BinarySearch(0, rawData.Count - 1, value);
                }
            }

            /// <summary>
            /// TODO: Implement a binary search here to find the index of the value (if it exists)
            /// https://runestone.academy/ns/books/published/pythonds/SortSearch/TheBinarySearch.html
            /// </summary>
        private int BinarySearch(int leftIndex, int rightIndex, int value)
        {
            int midpoint;

            // Base case - right < left b/c we're out of elements to check - return -1
            if(rightIndex < leftIndex)
            {
                return -1;
            }

            // Base case - We only have 1 element left (left == right). See if it has our value.
            // If so, return the index. Otherwise, return -1.
            else if (rightIndex == leftIndex)
                {
                    if (rawData[leftIndex] == value)
                    {
                        return leftIndex;
                    }
                    else
                    {
                        return -1;
                    }
                }

            // Determine which half to search
            else
            {
                // Find the midpoint of the current search space
                midpoint = (leftIndex + rightIndex) / 2;

                // Base case - midpoint is the value we're looking for - return midpoint
                if (rawData[midpoint] == value)
                {
                    return midpoint;
                }
                // Recursive case - Value we're searching for is less than midpoint,
                // search the bottom half & return result
                else if (rawData[midpoint] < value)
                {
                    return BinarySearch(midpoint + 1, rightIndex, value);
                }
                // Recursive case - Value we're searching for is greater than midpoint,
                // search the top half & return result
                else if (rawData[midpoint] > value)
                {
                    return BinarySearch(leftIndex, midpoint - 1, value);
                }
                return -1;
            }
        }

            // The remaining methods are all simple wrappers of
            // existing List functionality
            #region Misc List wrapper methods

            public int Get(int index)
            {
                return rawData[index];
            }

            public void Remove(int value)
            {
                rawData.Remove(value);
            }

            public void RemoveAt(int index)
            {
                rawData.RemoveAt(index);
            }

            public void Clear()
            {
                rawData.Clear();
            }

            #endregion
        }

    }
