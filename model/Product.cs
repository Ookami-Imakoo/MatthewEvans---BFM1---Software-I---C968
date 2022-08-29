using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewEvans___BFM1___Software_I___C968.model
{
    public class Product
    {

        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public static BindingList<Part> AssociatedParts = new BindingList<Part>();

        public void addAssociatedPart(int ProductID, string Name, decimal Price, int InStock, int Min, int Max)
        {
            AssociatedParts.AddNew();

        }

        public bool removeAssoicatedPart(int x)
        {
           for(int i = 0; i < AssociatedParts.Count; i++)
            {
                if (x == ProductID)
                {
                    AssociatedParts.RemoveAt(i);
                return true;
                }
            }
            return false;
        
        }

        public Part lookupAssoicatedPart(int x)
        {
            for (int i = 0; i < AssociatedParts.Count; i++)
            {
                if (x == ProductID)
                {
                    return AssociatedParts[i];
                }
                continue;
            }
            return null;
        }
    }
}
