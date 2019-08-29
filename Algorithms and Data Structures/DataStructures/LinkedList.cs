using System;
using System.Text;

namespace Algorithms_and_Data_Structures.DataStructures
{
    /// <summary>
    /// Implementation of a doubly linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        public class Node
        {
            private Node next;
            private Node previous;
            private T value;
            private LinkedList<T> list;

            public Node Next { get => next; set => next = value; }
            public Node Previous { get => previous; set => previous = value; }
            public T Value { get => value; set => this.value = value; }
            public LinkedList<T> List { get => list; set => list = value; }

            public Node(T value)
            {
                this.value = value;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public int Count { get => count; set => count = value; }

        /// <summary>
        /// Adds a node to the LinkedList after the specified node
        /// </summary>
        /// <param name="node">A node in this LinkedList</param>
        /// <param name="newNode">A node not contained in any list</param>
        public void AddAfter(Node node, Node newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node must not be null");
            }
            if (newNode == null)
            {
                throw new ArgumentNullException("newNode must not be null");
            }
            if (node.List != this)
            {
                throw new InvalidOperationException("node must be contained in LinkedList");
            }
            if (newNode.List != null)
            {
                throw new InvalidOperationException("newNode must not be contained in a LinkedList");
            }

            Node temp = node.Next;
            node.Next = newNode;
            newNode.Previous = node;
            newNode.Next = temp;
            Count++;
        }

        /// <summary>
        /// Creates a new node from a value and adds it after the specified node
        /// </summary>
        /// <param name="node">A node in this LinkedList</param>
        /// <param name="value">A value to be stored in a node</param>
        /// <returns></returns>
        public Node AddAfter(Node node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node must not be null");
            }
            if (node.List != this)
            {
                throw new InvalidOperationException("node must be contained in LinkedList");
            }
            Node newNode = new Node(value);
            Node temp = node.Next;
            node.Next = newNode;
            newNode.Previous = node;
            newNode.Next = temp;
            Count++;

            return newNode;
        }

        /// <summary>
        /// Adds a node to the LinkedList before the specified node
        /// </summary>
        /// <param name="node">A node in this LinkedList</param>
        /// <param name="newNode">A node not contained in any list</param>
        public void AddBefore(Node node, Node newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node must not be null");
            }
            if (newNode == null)
            {
                throw new ArgumentNullException("newNode must not be null");
            }
            if (node.List != this)
            {
                throw new InvalidOperationException("node must be contained in LinkedList");
            }
            if (newNode.List != null)
            {
                throw new InvalidOperationException("newNode must not be contained in a LinkedList");
            }

            Node temp = node.Previous;
            node.Previous = newNode;
            newNode.Next = node;
            newNode.Previous = temp;
            Count++;
        }

        /// <summary>
        /// Creates a new node from a value and adds it before the specified node
        /// </summary>
        /// <param name="node">A node in this LinkedList</param>
        /// <param name="value">A value to be stored in a node</param>
        /// <returns></returns>
        public Node AddBefore(Node node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node must not be null");
            }
            if (node.List != this)
            {
                throw new InvalidOperationException("node must be contained in LinkedList");
            }
            Node newNode = new Node(value);
            Node temp = node.Previous;
            node.Previous = newNode;
            newNode.Next = node;
            newNode.Previous = temp;
            Count++;

            return newNode;
        }

        /// <summary>
        /// Adds a new node to the beginning of the LinkedList
        /// </summary>
        /// <param name="newNode">A new node not contained in this LinkedList</param>
        public void AddFirst(Node newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException("newNode must not be null");
            }
            if (newNode.List != null)
            {
                throw new InvalidOperationException("newNode must not be contained in a LinkedList");
            }
            Node temp = head;
            head = newNode;
            newNode.Next = temp;
            Count++;
        }

        /// <summary>
        /// Creates a node from a value to the beginning of the LinkedList
        /// </summary>
        /// <param name="value">The value of the created node</param>
        /// <returns></returns>
        public Node AddFirst(T value)
        {
            Node temp = head;
            head = new Node(value)
            {
                Next = temp
            };
            Count++;
            return head;
        }

        /// <summary>
        /// Adds a new node to the end of the LinkedList
        /// </summary>
        /// <param name="newNode">A new node not contained in this LinkedList</param>
        public void AddLast(Node newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException("newNode must not be null");
            }
            if (newNode.List != null)
            {
                throw new InvalidOperationException("newNode must not be contained in a LinkedList");
            }
            tail.Next = newNode;
            tail = newNode;
            Count++;
        }

        /// <summary>
        /// Creates a node from a value to the end of the LinkedList
        /// </summary>
        /// <param name="value">The value of the created node</param>
        /// <returns></returns>
        public Node AddLast(T value)
        {
            tail.Next = new Node(value);
            tail = tail.Next;
            Count++;
            return tail;
        }

        /// <summary>
        /// Clears the LinkedList and frees all nodes
        /// </summary>
        public void Clear()
        {
            Node node = head;
            while (node.Next != null)
            {
                node.Previous = null;
                node.List = null;
                Node nextNode = node.Next;
                node.Next = null;
                node = nextNode;
            }
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Finds a value in the LinkedList
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        /// <summary>
        /// Copies values of LinkedList, beginning from the start, to a portion of an array
        /// </summary>
        /// <param name="array">The array to copy values to</param>
        /// <param name="index">The index at which to start the array</param>
        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array cannot be null");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index cannot be negative");
            }
            if (array.Length - index - 1 < Count)
            {
                throw new ArgumentException("LinkedList contains more values than slots in array");
            }   
            Node node = head;
            for (int i = index; i < array.Length; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }
        }

        /// <summary>
        /// Finds the first node containing a value
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns></returns>
        public Node Find(T value)
        {
            Node node = head;
            while (node.Next != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
                node = node.Next;
            }

            return null;
        }

        /// <summary>
        /// Finds the first node containing a value
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns></returns>
        public Node FindLast(T value)
        {
            Node node = tail;
            while (node.Previous != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
                node = node.Previous;
            }

            return null;
        }

        /// <summary>
        /// Removes a specified node from LinkedList
        /// </summary>
        /// <param name="node">The node to remove</param>
        public void Remove(Node node)
        {
            node.List = null;
            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
                node.Previous = null;
            } else
            {
                head = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Previous = node.Previous;
                node.Next = null;
            } else
            {
                tail = node.Previous;
            }
            Count--;
        }

        /// <summary>
        /// Removes the first instance of a value from LinkedList
        /// </summary>
        /// <param name="value">The value to remove</param>
        /// <returns></returns>
        public Node Remove(T value)
        {
            Node node = Find(value);
            Remove(node);
            return node;
        }

        /// <summary>
        /// Removes the first node of the LinkedList
        /// </summary>
        /// <returns></returns>
        public Node RemoveFirst()
        {
            Node first = head;
            Remove(first);
            return first;
        }

        /// <summary>
        /// Removes the last node of the LinkedList
        /// </summary>
        /// <returns></returns>
        public Node RemoveLast()
        {
            Node last = tail;
            Remove(last);
            return last;
        }
    }
}
