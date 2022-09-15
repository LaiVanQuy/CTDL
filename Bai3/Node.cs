using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bai3
{
    public class Node
    {
        public Word data { get; set; }
        public Node nodeNext { get; set; }

        public Node(Word x)
        {
            this.data = x;
            this.nodeNext = null;   
        }
        public Node(Node x)
        {
            this.data = x.data;
            this.nodeNext = x.nodeNext;
        }
    }
}
