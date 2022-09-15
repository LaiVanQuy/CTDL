using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    public class NodeQ<T>
    {
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public NodeQ<T> next;
        public NodeQ() { }
        public NodeQ(T data)
        {
            Data = data;
            this.next = null;
        }
    }
}
