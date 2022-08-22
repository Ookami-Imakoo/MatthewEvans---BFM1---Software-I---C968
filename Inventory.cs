using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewEvans___BFM1___Software_I___C968
{
    public class Inventory : Product
    {
        BindingList<Product> Products = new BindingList<Product>();
        BindingList<Part> AllParts = new BindingList<Part>();

        public void addProduct(Product Product)
        {
            Products.AddNew();
        }

        public bool removeProduct(int x)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (x == ProductID)
                {
                    Products.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
