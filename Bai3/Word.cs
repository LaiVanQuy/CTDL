using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class Word
    {
 
        public string chu { get; set; }
        public string loai { get; set; }
        public string nghia { get; set; }

        public Word(string chu, string loai, string nghia)
        {
            this.chu = chu;
            this.loai = loai;
            this.nghia = nghia;
        }
        public Word(string chu)
        {
            this.chu = chu;
        }
        public Word()
        {

        }

        public override string ToString()
        {
            return chu + " (" + loai + ") " + nghia;
        }

    }
}
