using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.DataStructures

{
    public class Stack<T>
    {
        private const int DEFAULT = 1000;

        private T[] stack;
        private int idx;
        private readonly int size;

        public int Size { get => size; }
        /// <summary>
        /// Default Stack Constructor
        /// </summary>
        public Stack(){
            stack = new T[DEFAULT];
            idx = -1;
            size = DEFAULT;
        }

        /// <summary>
        /// Construct a Stack with certain buffer size
        /// </summary>
        /// <param name="size">The internal capacity of the stack</param>
        public Stack(int size)
        {
            stack = new T[size];
            idx = 0;
            this.size = size;
        }


        /// <summary>
        /// Push an item
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (idx < size)
                stack[++idx] = item;
            else
                throw new OverflowException();
        }

        /// <summary>
        /// Pop an item
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (idx == -1)
                throw new InvalidOperationException("The stack is empty");
            T item = stack[idx];
            stack[idx--] = default(T);
            return item;
        }

        /// <summary>
        /// Peeks off top of stack
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (idx == -1)
                throw new InvalidOperationException("The stack is empty");
            return stack[idx];
        }

        /// <summary>
        /// True if stack contains item
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            return idx > -1;
        }
    }
}
