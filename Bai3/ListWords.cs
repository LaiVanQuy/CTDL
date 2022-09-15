using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class ListWords
    {
        public Node nodeHead { get; set; }
        public Node nodeTail { get; set; }

        public char key;

        public ListWords(char x)
        {
            this.key = x;
            this.nodeHead = this.nodeTail = null;
        }

        public ListWords()
        {

        }

        public void AddLast(Word x)
        {
            Node A = new Node(x);
            if(this.nodeHead == null)
            {
                this.nodeHead = this.nodeTail = A;
            }
            else
            {
                this.nodeTail.nodeNext = A;
                this.nodeTail = this.nodeTail.nodeNext;
            }
        }
        
        public void SearchWord(Word x)
        {
            Node p = nodeHead;
            while(p!=null)
            {
                if (p.data.chu == x.chu)
                {
                    Console.Write(" => ");
                    Console.WriteLine(p.data);
                    return;
                }
                    p = p.nodeNext;
            }
            Console.WriteLine(" Không tồn tại, bạn có thể thêm từ này vào từ điển và chúng tôi sẽ nhớ chúng");
        }
        public void PrinList()
        {
            
            Node p = nodeHead;
            while(p != null)
            {
                Console.Write("- ");
                Console.WriteLine(p.data);
                p = p.nodeNext;
            }
        }
    }
}
