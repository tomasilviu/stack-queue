using System;
namespace BasicTools//Stack and Queue
{
     class Stack<T>
    {
        //Members
        protected T[] m_array;
        protected int m_count;
        protected int m_estimatedLength;
        //Constructor
        public Stack(int length = 100)//length parameter is an estimation. If you are not sure you can just leave it blank
        {
            this.m_count = 0;
            this.m_array = new T[length];
            this.m_estimatedLength = length;
        }
        //Methods
        public void Push(T element)
        {
            if (this.m_count == this.m_estimatedLength)
            {
                Array.Resize(ref this.m_array, this.m_estimatedLength * 2);
                this.m_estimatedLength = this.m_estimatedLength * 2;
            }
            this.m_array[this.m_count] = element;
            this.m_count++;
        }
        public T Pop()
        {
            if (this.m_count > 0)
            {//delete element by moving the counter
                this.m_count--;
                if (this.m_count < this.m_estimatedLength / 2)
                {
                    Array.Resize(ref this.m_array, this.m_estimatedLength / 2);
                    this.m_estimatedLength = this.m_estimatedLength / 2;
                }
                return this.m_array[this.m_count];
            }
            else
            {
                return default(T);
            }
        }
        public bool isEmpty()
        {
           if(this.m_count==0)
            {
                return true;
            }
           else
            {
                return false;
            }
        }
        public bool isFull()
        {
            if (this.m_count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public T Peak()
        {
            if (this.isFull())
            {
                return this.m_array[0];
            }
            else
            {
                return default(T);
            }
        }
    }
    public Queue(int length = 100)
        {
            this.m_length = length;
            this.m_front = 0;
            this.m_rear = 0;
            this.m_array = new T[length+1];
            this.m_isEmpty = true;
            this.m_isFull = false;
            this.m_count = 0;
        }
        //Methods
        public bool isFull()//returns true if the ring buffer is full and false otherwise
        {
            return this.m_isFull;
        }
        public bool isEmpty()//returns true if the ring buffer is empty and false otherwise
        {
            return this.m_isEmpty;
        }
        public void Push(T element)
        {
            this.m_array[this.m_front] = element;
            this.m_front = (this.m_front + 1) % this.m_length;
            this.m_isEmpty = false;
            if (this.m_rear == this.m_front)
            {
                this.m_isFull = true;
                this.m_front++;
            }
            else
            {
                this.m_isFull = false;
            }
        }
        public T Pop()
        {
            if (!this.m_isEmpty)
            {
                T toReturn = this.m_array[this.m_rear];
                this.m_rear = (this.m_rear + this.m_length + 1) % this.m_length;
                if (this.m_isFull)
                {
                    this.m_isFull = false;
                }
                return toReturn;
            }
            else
            {
                return default(T);
            }
        }
        public T Peak()
        {
            return this.m_array[this.m_rear];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> a = new Queue<int>();
            a.Push(4);
            a.Push(5);
            a.Push(2);
            a.Push(19);
            a.Pop();
            a.Pop();
            a.Pop();
            a.Pop();
            a.Push(35);
            a.Push(22);
            a.Push(21);
            a.Push(665);
            var b = a.Pop();
            Console.WriteLine(b);
            b = a.Pop();
            Console.WriteLine(b);
            b = a.Pop();
            Console.WriteLine(b);
            b = a.Pop();
            b = a.Pop();
            b = a.Pop();
            Console.WriteLine(b);
            a.Push(100);
            b = a.Pop();
            Console.WriteLine(b);
        }
    }
}
