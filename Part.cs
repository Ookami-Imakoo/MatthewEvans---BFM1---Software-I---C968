using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewEvans___BFM1___Software_I___C968
{
    public abstract class Part
    {
        private int PartID { get; set; }
        private string Name { get; set; }
        private decimal Price { get; set; }
        private int InStock { get; set; }
        private int Min { get; set; }
        private int Max { get; set; }
    }
}
