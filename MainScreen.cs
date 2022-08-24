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
            partsDataGridView.DataSource = Inventory.AllParts;
            productsDataGridView.DataSource = Inventory.Products;
        }

       //opens the add parts screen
        private void partsAddButton_Click(object sender, EventArgs e)
        {
            addPartScreen addPartScreen = new addPartScreen();
            addPartScreen.Show();
        }

        //opens add product screen
        private void productsAddButton_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        //closes application
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
