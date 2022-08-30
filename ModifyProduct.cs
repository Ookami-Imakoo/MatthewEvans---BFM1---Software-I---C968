using MatthewEvans___BFM1___Software_I___C968.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatthewEvans___BFM1___Software_I___C968
{
    public partial class ModifyProduct : Form
    {

        public ModifyProduct()
        {
            InitializeComponent();
        }

        public ModifyProduct(Product product)
        {
            ModifyProduct modifyProduct = new ModifyProduct();

            modifyProduct.idValue.Text = product.ProductID.ToString();
            modifyProduct.nameValue.Text = product.Name.ToString();
            modifyProduct.inventoryValue.Text = product.InStock.ToString();
            modifyProduct.priceCostValue.Text = product.Price.ToString();
            modifyProduct.maxValue.Text = product.Max.ToString();
            modifyProduct.minValue.Text = product.Min.ToString();

            modifyProduct.partsAssociatedDataGridView.DataSource = product.AssociatredParts;
        }
    }
}
