using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    public class StringStringObject
    {
        public string String1 { get; set; }
        public string String2 { get; set; }
           
        public StringStringObject()
        {

        }

        public StringStringObject(string string1, string string2)
        {
            this.String1 = string1;
            this.String2 = string2;
        }
    }
}
