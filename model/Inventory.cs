using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatthewEvans___BFM1___Software_I___C968.model
{
    public class Inventory
    {
        //Initialization of Product
        //Product product = new Product();

        public static BindingList<Product> Products = new BindingList<Product>(); //Binding list for storeing Product objects
        public static BindingList<Part> AllParts = new BindingList<Part>(); //Binding list for storeing Part objects
        
        /// <summary>
        /// Method for adding products to Products BindingList.
        /// </summary>
        /// <param name="Product">Product to be added to BindingList</param>
        public void addProduct(Product product)
        {
            Products.Add(product);
        }

        /// <summary>
        /// Function for removing products.
        /// </summary>
        /// <param name="x"> Represents the product id to be deleted. </param>
        /// <returns> Returns true if the suplied product id is found, else returns false. </returns>
        public bool removeProduct(Product product)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (product == Products[i])
                {
                    Products.Remove(product);
                }
            }
            return false;
        }

        /// <summary>
        /// Represents a function that looks up a product useing the product ID.
        /// </summary>
        /// <param name="x"> Represents the Product ID to be searched. </param>
        /// <returns> Returns the product with the corisponding Product ID. </returns>
        //public Product lookupProduct(int x)
        //{
        //    for (int i = 0; i < Products.Count; i++)
        //    {
        //        if (x == product.ProductID)
        //        {
        //            return Products[x];
        //        }
        //    }
        //    return null;
        //}

        /*
         * Still unsure what to do with this function, hopeing that it will be more clear as I put the application together.
         * 
        public void updateProduct(int x, Product myProduct)
        {
            for (int i = 0 ; i < Products.Count ; i++)
            {
                if (x == myProduct.ProductID)
                {
                    Products.Remove[i];
                }
            }
        }
        */

        /// <summary>
        /// Represents a function that adds a Part to the All Parts list.
        /// </summary>
        /// <param name=""> Represents a part to be addded to the All Parts list. </param>
        public void addPart(Part myPart)
        {
            AllParts.Add(myPart);
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
            foreach (var part in AllParts)
            {
                if (part != myPart)
                {
                    continue;
                }
                AllParts.Remove(part);
                return true;
            }
            return false;

            /*
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
            */
        }

        /// <summary>
        /// Refers to the function that will look up a part based on an integer (PartID) input
        /// </summary>
        /// <param name="x"> Refers to the Part ID to be looked up </param>
        /// <returns> Returns the part if found and null if not found </returns>
        public Part lookupPart(int x)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (x == AllParts[i].PartID)
                {
                    return AllParts[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Refers to the function that will update a part, by first ittering though the binding list 
        /// and deleteing the part if found, and replaceing it with the Part provided. </summary>
        /// <param name="x"> Represents the part number wished to be replaced. </param>
        /// <param name="myPart"> Represents the part to be placed in the list after the removal of the old data. </param>
        public void updatePart(int x, Part myPart)
        {
            for (int i = 0; i < AllParts.Count; i++)
            {
                if (x == myPart.PartID)
                {
                    AllParts.RemoveAt(x);
                    AllParts.Add(myPart);
                }
            }
        }

        //private void addPartNumber(int i)
        //{
        //    PartNumbers.Add(AllParts[i].PartID);
        //}

        /// <summary>
        /// Function for generating and setting unique partID's
        /// </summary>
        /// <returns> Unique Part Number </returns>
        public int partIDGenerator()
        {
            int i = 0;
            int missingEntry = 0;

            do
            {
                if (AllParts.Count == 0)
                {
                    return 1;
                }
                else if (AllParts[0].PartID > 1)
                {
                    missingEntry = 1;
                    break;
                }
                else if ((i + 1) == AllParts[i].PartID)
                {
                    i++;
                    continue;
                }
                else
                {
                    missingEntry = (AllParts[i].PartID - 1);
                    break;
                }
            }
            while (i != AllParts.Count);

            do
            {
                if (i == AllParts.Count) 
                {
                    return (AllParts.Count + 1);
                }
                else if (missingEntry != AllParts[i].PartID)
                {
                    i++;
                    continue;
                }
                else if (missingEntry == AllParts[i].PartID)
                {
                    return (AllParts.Count + 1);
                }
            }
            while (i != AllParts.Count);    
            return missingEntry;
        }

        public int productIDGenerator()
        {
            return Products.Count + 00001;
        }

        public Part dataSetup(int x)
        {
            Part part = AllParts[x];
            return part;
        }
    }
}