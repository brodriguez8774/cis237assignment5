// Author: Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// Generic Linked List Class.
    /// Stack = Push/Pop. Queue = Enqueue/Dequeue.
    /// </summary>
    /// <typeparam name="T">Data type to use.</typeparam>
    class GenericLinkedList<T>
    {
        // Stack push (add) and pop (remove).
        // Queue enqueue (Add) and dequeue (remove).

        #region Variables

        //private GenericNode<T> headNode;      // Pointer for first position in list. Established in paramaters though.
        private GenericNode<T> currentNode;     // Pointer for current position in list.
        private GenericNode<T> lastNode;        // Last position in list. Used for queues.
        private int lengthInt = 0;              // Holds length of queue.

        #endregion


        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public GenericLinkedList()
        {
            HeadNode = null;
        }

        #endregion


        #region Properties

        public GenericNode<T> HeadNode
        {
            set;
            get;
        }

        public int Length
        {
            get { return lengthInt; }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Add method for a Queue. Adds to back.
        /// </summary>
        /// <param name="content">Content to put into queue.</param>
        public void Enqueue(T content)
        {
            GenericNode<T> node = new GenericNode<T>();     // Creates new node to add to Queue.

            node.Data = content;                            // Adds content to "Data" property of new node.

            // Checks to see if queue is populated yet. If not, assign as head. Else, add to end of Queue.
            if (HeadNode == null)
            {
                HeadNode = node;
            }
            else    // lastNode is only ever used here.
            {
                lastNode.Next = node;
            }
            lastNode = node;

            lengthInt++;
        }

        /// <summary>
        /// Delete method for a Queue. Removes from front.
        /// </summary>
        /// <returns>Bool indicating if properly removed.</returns>
        public bool DeQueue()
        {
            try
            {
                currentNode = HeadNode;         // Sets current to head, incase it moved elsewhere.
                HeadNode = currentNode.Next;    // Sets Head pointer to be next node.
                currentNode.Next = null;        // Sets current node's "next" property to point to null.
                currentNode = null;             // Sets entire current node to null. (Does both to ensure garbage collection)
                lengthInt--;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves a specific node from linked list.
        /// </summary>
        /// <param name="Position">Position of node? Like an index?</param>
        /// <returns>Node associated with given position.</returns>
        public GenericNode<T> Retrieve(int Position)
        {
            GenericNode<T> tempNode = HeadNode;     // Initialize tempNode to current Head.
            GenericNode<T> returnNode = null;       // Initialize return node to null.

            int count = 0;
            // While tempNode is not null.
            while (tempNode != null)
            {
                // If count is one less than position.
                if (count == Position - 1)
                {
                    return tempNode;
                }
                count++;
                tempNode = tempNode.Next;           // Not yet found. Assign tempNode to nextNode and repeat.
            }
            return returnNode;                      // Position was not found. Return null node.
        }


        /*public GenericNode<T> Retrieve(T content)
        {
            GenericNode<T> tempNode = HeadNode;     // Initialize tempNode to current Head.
            GenericNode<T> returnNode = null;       // Initialize return node to null.

            int count = 0;
            // While tempNode is not null.
            while (tempNode != null)
            {
                // If Data of node is match of passed in content.
                if (content == tempNode.Data) // Cannot compare two datasets of type T?
                {
                    return tempNode;
                }
                count++;
                tempNode = tempNode.Next;           // Not yet found. Assign tempNode to nextNode and repeat.
            }
            return returnNode;                      // Position was not found. Return null node.
        }*/

        #endregion
    }
}
