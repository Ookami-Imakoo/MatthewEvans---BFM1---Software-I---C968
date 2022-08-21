using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewEvans___BFM1___Software_I___C968
{
    public class Product : Part
    {
        BindingList<Part> AssociatedParts = new BindingList<Part>();

        public int ProductID { get; set; }
        private string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        private void addAssociatedPart(Part  Part)
        {
            AssociatedParts.AddNew();

        }

        private bool removeAssoicatedPart(int x)
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

        private Part lookupAssoicatedPart(int x)
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
