using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    public class Stack<T>
    {
        public NodeS<T> top;
        public bool IsEmpty()
        {
            if (this.top == null)
                return true;
            else return false;
        }
        public Stack()
        {
            this.top = null;
        }
        public void Push(T A)
        {
            NodeS<T> p = new NodeS<T>(A);
            if (this.IsEmpty())
                this.top = p;
            else
            {
                p.next = this.top;
                this.top = p;
            }
        }
        public T Top()
        {
     
            return this.top.Data;
        }
        public T Pop()
        {
            T data = this.top.Data;
            this.top = this.top.next;

            return data;
        }
        public int Count()
        {
            NodeS<T> p = this.top;
            int i = 0;
            while (p != null)
            {
                i++;
                p = p.next;
            }
            return i;
            
        }
       
    }
}
