using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.DataStructures
{
    public class Queue<T>
    {
        private const int DEFAULT = 1000;

        private T[] queue;
        private int head;   //head marks the first item in the queue
        private int tail;   //tail marks the last item in the queue
        private bool hasItems;
        private readonly int size;

        public int Size { get => size; }

        /// <summary>
        /// Default queue constructor
        /// </summary>
        public Queue()
        {
            queue = new T[DEFAULT];
            head = 0;
            tail = 0;
            hasItems = false;
            size = DEFAULT;
        }

        /// <summary>
        /// Construct a queue of a particular buffer size
        /// </summary>
        /// <param name="size"></param>
        public Queue(int size)
        {
            queue = new T[size];
            head = 0;
            tail = 0;
            hasItems = false;
            if (size > 0)
            {
                this.size = size;
            } else
            {
                throw new ArgumentOutOfRangeException("Size must be positive");
            }

        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new OverflowException("The queue is full");
            }

            hasItems = true;
            queue[tail++] = item;
            tail %= size;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T item = queue[head];
            queue[head++] = default;
            head %= size;

            if (head == tail)
            {
                hasItems = false;
            }
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return queue[head];
        }

        public bool IsFull()
        {
            return hasItems && head == tail;
        }

        public bool IsEmpty()
        {
            return !hasItems;
        }
    }
}
