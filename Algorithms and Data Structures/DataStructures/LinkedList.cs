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
        private Node current;

        public LinkedList()
        {

        }

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
            return tail;
        }
    }
}
