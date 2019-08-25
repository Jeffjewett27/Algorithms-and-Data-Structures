using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.DataStructures
{
    public class Queue<T>
    {
        private const int DEFAULT = 1000;

        private T[] queue;
        private int head;
        private int tail;
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
            size = default;
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
            this.size = size;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new OverflowException("The queue is full");
            }

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
            queue[head++] = default(T);
            head %= size;
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
            return (tail + 1) % size == head;
        }

        public bool IsEmpty()
        {
            return head == tail;
        }
    }
}
