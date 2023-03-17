using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class PolishWord
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Word+" "+Description;
        }
    }
}
