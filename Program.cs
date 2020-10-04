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
        public bool isEmpty()//Returns true if stack is full and false for empty
        {
            if (this.m_count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public T Peek()
        {
            if (!this.isEmpty())
            {
                return this.m_array[this.m_count-1];
            }
            else
            {
                return default(T);
            }
        }
    }
     class Queue<T>
    {
        //Members
        protected T[] m_array;
        protected int m_length;
        protected int m_rear;
        protected int m_front;
        protected bool m_isFull;
        protected bool m_isEmpty;
        //Constructor
        public Queue(int length = 100)
        {
            this.m_array = new T[length + 1];
            this.m_length = length;
            this.m_rear = 0;
            this.m_front = 0;
            this.m_isFull = false;
            this.m_isEmpty = true;
        }
        //Methods
        public bool isFull()
        {
            if(this.CurrentLength()==this.m_length)
            {
                this.m_isFull = true;
                return true;
            }
            else
            {
                this.m_isFull = false;
                return false;
            }
        }
        public bool isEmpty()
        {
            if(this.CurrentLength()==0)
            {
                this.m_isEmpty = true;
                return true;
            }
            else
            {
                this.m_isEmpty = false;
                return false;
            }
        }
        public int MaxLength()
        {
            return this.m_length;
        }
        public void IncreasePointers()
        {
            this.m_front = (this.m_front + 1) % this.m_length;
            if (this.isFull())
            {
                this.m_rear = (this.m_rear + 1) % this.m_length;
            }
        }
        public void Push(T element)
        {
            if (this.isEmpty())
            {
                this.m_isEmpty = false;
            }
            int exFront = this.m_front;
            this.m_array[this.m_front] = element;
            this.IncreasePointers();
            if (this.m_rear == this.m_front)
            {
                Console.WriteLine("Queue is full");
                this.m_isFull = true;
            }
        }
        public T Pop()
        {
            if (this.isEmpty())
            {
                return default(T);
            }
            else
            {
                T toReturn;
                toReturn = this.m_array[this.m_rear];
                this.m_rear = (this.m_rear + 1) % this.m_length;
                if (this.isFull())
                {
                    this.m_isFull = false;
                }
                if (this.m_rear == this.m_front && !this.m_isFull)
                {
                    this.m_isEmpty = true;
                }
                return toReturn;
            }
        }
        public void ShowCurrentLength()
        {
             Console.WriteLine("The current length is:");
             int toShow = CurrentLength;
             Console.WriteLine(toShow);
        }
        public int CurrentLength()
        {
            if (this.m_rear > this.m_front)
            {
                return this.m_length - this.m_front;
            }
            if (this.m_front > this.m_rear)
            {
                return this.m_front - this.m_rear;
            }
            if (this.m_front == this.m_rear && this.m_isFull)
            {
                return this.m_length;
            }
            else
            {
                return 0;
            }
        }
        public T Peek()
        {
            return this.m_array[this.m_rear];
        }
        public void Show(int counter = -1)
        {
            if (this.m_isEmpty)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            else
            {
                if (counter == (this.m_front-1)%this.m_length)
                {
                    T toShow = this.m_array[counter];
                    Console.WriteLine(toShow);
                    return;
                }
                if (counter == -1)
                {
                    counter = this.m_rear;
                    T toShow = this.m_array[counter];
                    Console.WriteLine(toShow);
                    counter = (counter + 1) % this.m_length;
                    this.Show(counter);
                }
                else
                {
                    T toShow = this.m_array[counter];
                    Console.WriteLine(toShow);
                    counter = (counter + 1) % this.m_length;
                    this.Show(counter);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int b;
            Queue<int> a = new Queue<int>(4);
            a.Push(1);
            a.Push(2);
            b = a.Pop();//1
            Console.WriteLine(b);
            b = a.Pop();//2
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            a.Push(3);
            a.Push(4);
            a.ShowLength();//2
            a.Push(5);
            a.Push(6);
            a.Show();//3 4 5 6
            a.Push(7);
            a.Push(8);
            a.Push(9);
            b = a.Pop();//6
            Console.WriteLine(b);
            a.Push(10);
            a.Push(5);
            a.Push(2);
            a.Push(19);
            a.Push(666);
            a.Push(665);
            a.Push(664);
            a.Push(333);
            a.Push(222);
            b = a.Pop();//665
            Console.WriteLine(b);
           // b = a.Peak();//664
            Console.WriteLine(b);
            b = a.Pop();//664
            Console.WriteLine(b);
            b = a.Pop();//333
            Console.WriteLine(b);
            b = a.Pop();//222
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            a.Push(1);
            a.Push(2);
            a.Push(3);
            a.Push(4);
            a.Push(5);
            b = a.Pop();//2
            Console.WriteLine(b);
            b = a.Pop();//3
            Console.WriteLine(b);
            b = a.Pop();//4
            Console.WriteLine(b);
            b = a.Pop();//5
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
            b = a.Pop();//0
            Console.WriteLine(b);
        }
    }
}
