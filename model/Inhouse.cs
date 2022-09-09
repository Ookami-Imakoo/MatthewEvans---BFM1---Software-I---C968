using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatthewEvans___BFM1___Software_I___C968.model
{
    public class Inhouse : Part
    {
        public int MachineID { get; set; }

        public Inhouse(int PartID, String Name, decimal Price, int InStock, int Min, int Max, int MachineID)
        {
            Inhouse inhouse = new Inhouse(PartID, Name, Price, InStock, Min, Max, MachineID);
        }
    }
}
