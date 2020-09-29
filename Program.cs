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
    class Queue<T> : Stack<T>//implements public T Pop()
    {
        private T[] Skip(T[] arr,int position)
        {
            bool foo = false;
            T foo2;
            for (int i = 0; i<=this.m_count; i++)
            {
                if (i==position)
                {
                    foo = true;
                    foo2 = this.m_array[i];
                }
                if (foo==true && i > position)
                {
                    this.m_array[i - 1] = this.m_array[i];
                }
            }
            return this.m_array;
        }
        public T Pop()
        {
            if (this.m_count > 0)
            {
                this.m_count--;
                var temp = this.m_array[0];
                this.m_array = this.Skip(this.m_array,0);
                return temp;
            }
            else
            {
                this.m_count = 0;
                return this.m_array[this.m_count];
            }  
        }
        //Destructor
        ~Queue()
        { }
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
