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
    public partial class AddProduct : Form
    {
        //initialization of Inventory
        Inventory inventory = new Inventory();
        Product myProduct = new Product();

        public AddProduct()
        {
            InitializeComponent();
            
            //sets up screen
            addProductSetup();


        }

        //created a product adding it to the 
        private void productSaveButton_Click(object sender, EventArgs e)
        {
            Product myProduct = new Product
            {
                ProductID = int.Parse(idValue.Text), Name = nameValue.Text, 
                InStock = int.Parse(inventoryValue.Text), Price = decimal.Parse(priceCostValue.Text), 
                Max = int.Parse(maxValue.Text), Min = int.Parse(minValue.Text), AssociatredParts = Product.AssociatedParts
            };

            inventory.addProduct(myProduct);

            this.Close();
        }

        //adds Part to AssociatedParts list
        private void allCandidateAddButton_Click(object sender, EventArgs e)
        {
            Part part = allCandidateDataGridView.CurrentRow.DataBoundItem as Part; //uses selection to create part object 
            Product.AssociatedParts.Add(part); //adds part object to Associated Parts List
        }

        //Form settings
        private void addProductSetup()
        {
            allCandidateDataGridView.DataSource = Inventory.AllParts; //sets data for All Candidate Parts DataGrid
            partsAssociatedDataGridView.DataSource = Product.AssociatedParts; //sets data for Parts Associated DataGrid

            
        }

        //removes parts form the Associated Parts list, but not form the all Candidate list
        private void partsAssociatedDeleteButton_Click(object sender, EventArgs e)
        {
            Part part = allCandidateDataGridView.CurrentRow.DataBoundItem as Part;
            int i = part.PartID;
            myProduct.removeAssoicatedPart(i);

        }

        //clears inital selection on allCadidateDataGridView
        private void allCandidateDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            allCandidateDataGridView.ClearSelection();
        }

        //clears inital selection on partsAssociatedDataGridView
        private void partsAssociatedDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            partsAssociatedDataGridView.ClearSelection();
        }

        //closes add product screen
        private void productCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
