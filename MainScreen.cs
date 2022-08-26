using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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

            //Remove bottom row from datagrids
            partsDataGridView.AllowUserToAddRows = false;
            productsDataGridView.AllowUserToAddRows = false;

            //Test Data Below
            Inventory inventory = new Inventory();
            inventory.addPart(1, "Georgie", 1.00m, 15, 1, 20);
            inventory.addPart(2, "Sean", 2.99m, 50, 7, 50);
            inventory.addPart(3, "Justin", 100.00m, 100, 1, 100);
            inventory.addPart(4, "Eric", 0.00m, 1, 1, 1);
            inventory.addPart(5, "Hindrix", 10.00m, 150, 1, 100);
            inventory.addPart(6, "Rox", 11.50m, 1, 1, 1);

        }

        private void partsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           partsDataGridView.ClearSelection();
        }

        //opens the add parts screen
        private void partsAddButton_Click(object sender, EventArgs e)
        {
            addPartScreen addPartScreen = new addPartScreen();
            addPartScreen.ShowDialog();
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

        //first checks if something is selected, if nothing slected a message box will appear prompting the user
        //if a row is selected then the selection will be deleted.
        public void partsDeleteButton_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();

            if (!partsDataGridView.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing Selected!", "Please Make A Slection");
                return;
            }

            Part deletepart = partsDataGridView.CurrentRow.DataBoundItem as Part;
            inventory.deletePart(deletepart);
        }

        private void partsModifyButton_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            int x;
            Part newPart = new Part();

            Part oldPart = partsDataGridView.CurrentRow.DataBoundItem as Part;

            x = oldPart.PartID;

            addPartScreen addPartScreen = new addPartScreen();
            addPartScreen.ShowDialog();            
            
            int PartID = oldPart.PartID;
            string Name = oldPart.Name;
            decimal Price = oldPart.Price;
            int InStock = oldPart.InStock;
            int Min = oldPart.Min;
            int Max = oldPart.Max;

            /*
            int MachineID = oldPart.;
            string CompanyName;

            
            PartID = Int32.Parse(idValue.Text);
            Name = nameValue.Text;
            Price = Decimal.Parse(priceCostValue.Text);
            InStock = Int32.Parse(inventoryValue.Text);
            Min = Int32.Parse(minValue.Text);
            Max = Int32.Parse(maxValue.Text);
            MachineID = Int32.Parse(machineIDValue.Text);
            CompanyName = companyNameValue.Text;

            inventory.addPart(PartID, Name, Price, InStock, Min, Max);

            inventory.updatePart(x, newPart);
            */
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();

            Part partlookup = inventory.lookupPart(Int32.Parse(partsSearchValue.Text));
            MessageBox.Show("Part " + partlookup.Name + " with PartID: " + partlookup.PartID + " was found.");
        }
    }
}
