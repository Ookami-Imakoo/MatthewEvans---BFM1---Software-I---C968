using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewEvans___BFM1___Software_I___C968
{
    public class Inventory : Part
    {
        BindingList<Product> Products = new BindingList<Product>();
        BindingList<Part> AllParts = new BindingList<Part>();

        Product myProduct = new Product();

       // Part mypart = new Part();

        /// <summary>
        /// Function for createing new products.
        /// </summary>
        /// <param name="Product"></param>
        public void addProduct(Product Product)
        {
            Products.AddNew();
        }

        /// <summary>
        /// Function for removing products.
        /// </summary>
        /// <param name="x"> Represents the product id to be deleted. </param>
        /// <returns> Returns true if the suplied product id is found, else returns false. </returns>
        public bool removeProduct(int x)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (x == myProduct.ProductID)
                {
                    Products.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Represents a function that looks up a product useing the product ID.
        /// </summary>
        /// <param name="x"> Represents the Product ID to be searched. </param>
        /// <returns> Returns the product with the corisponding Product ID. </returns>
        public Product lookupProduct(int x)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (x == myProduct.ProductID)
                {
                    return Products[x];
                }
            }
            return null;
        }

        public void updateProduct(int x, Product myProduct)
        {
            for (int i = 0 ; i < Products.Count ; i++)
            {
                if (x == myProduct.ProductID)
                {
                    /// Not sure what to do now XD, going to need to figure out what needs to be done in this function.
                }
            }
        }

        /// <summary>
        /// Represents a function that adds a Part to the All Parts list.
        /// </summary>
        /// <param name=""> Represents a part to be addded to the All Parts list. </param>
        public void addPart(Part myPart)
        {
            AllParts.AddNew();
        }

        /// <summary>
        /// Refers to the function that will iterate though the All Parts list and checks to make sure that
        /// the part entered as a parameter is not the same as the refrence form the list and if it dose match
        /// it will remove it.
        /// </summary>
        /// <param name=""> Represents the Part to be deleted</param>
        /// <returns> Returns true if part is deleted, else returns false. </returns>
        public bool deletePart(Part myPart)
        {
            for (int i = 0 ; i < AllParts.Count ; i++)
            {
                if (myPart != AllParts[i])
                {
                    continue;
                }
                AllParts.RemoveAt(i);
                return true;

            }
            return false;
        }

        public Part lookupPart(int x)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (x == PartID)
                {
                    return AllParts[x];
                }
            }
            return null;
        }
    }
}
