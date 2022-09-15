using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class HashTable
    {
        public ListWords[] List = new ListWords[26];
        public HashTable()
        {
            for(int i=0;i<26;i++)
            {
                char key = (char)(i + 65);
                List[i] = new ListWords(key);
            }
        }
        public char HashFunc(Word x)
        {
            return x.chu[0];
        }
        public void AddItem(Word x)
        {
            foreach(ListWords A in List)
            {
                if(A.key == this.HashFunc(x))
                {
                    A.AddLast(x);
                }
            }
        }
        public void SearchItem(String str)
        {
            Word x = new Word(str);
            foreach(ListWords A in List)
            {
                if(A.key == this.HashFunc(x))
                {
                    A.SearchWord(x);
                }
            }
        }
        public void PrintHashTable()
        {
            foreach(ListWords A in List)
            {
                A.PrinList();
            }
        }
    }
}
