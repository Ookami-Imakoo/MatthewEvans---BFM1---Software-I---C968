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
    public partial class mainScreen : Form
    {
        public mainScreen()
        {
            InitializeComponent();

            //set data source for Parts datagrid
            partsDataGridView.DataSource = Product.AssociatedParts;
            productsDataGridView.DataSource = Inventory.Products;
        }
    }
}
