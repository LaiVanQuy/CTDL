using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    public class NodeS<T>
    {
        private T data;
        public NodeS<T> next;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public NodeS()
        {

        }
        public NodeS(T data)
        {
            Data = data;
            this.next = null;
        }
    }
}
