using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Bai2
{
    public class Queue<T>
    {
        public NodeQ<T> front;
        public NodeQ<T> rear;
        public Queue() 
        {
            this.front = this.rear = null;
        }
        public bool IsEmpty()
        {
            if (this.front == null)
                return true;
            else return false;
        }
        public void EnQueue(T A)
        {
            NodeQ<T> p = new NodeQ<T>(A);
            if (IsEmpty())
                this.rear = this.front = p;
            else
            {
                this.rear.next = p;
                this.rear = p;
            }
        }
        public void DeQueue()
        {
            if (IsEmpty())
                return;
            else
            {
                this.front = this.front.next;
            }
        }
        public T Peek()
        {
            return this.front.Data;
        }
        public void Print()
        {
            NodeQ<T> p = new NodeQ<T>();
            p = this.front;
            while (p != null)
            {
                Console.Write(p.Data + " ");
                p = p.next;
            }
            Console.WriteLine();
        }
    }
   
}
