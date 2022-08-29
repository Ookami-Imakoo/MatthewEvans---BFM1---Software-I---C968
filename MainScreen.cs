using MatthewEvans___BFM1___Software_I___C968.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatthewEvans___BFM1___Software_I___C968
{
    public partial class mainScreen : Form
    {
        //Initialize Inventory
        Inventory inventory = new Inventory();

        public mainScreen()
        {
            InitializeComponent();

            //sets properties for MainScreen datagridviews
            MainScreenSetup();

            //sets up sampel data for debug
            //SetupSampelData();
        }

        //clears the autoselection of rows
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

        //button used to delete selected part
        public void partsDeleteButton_Click(object sender, EventArgs e)
        {
            if (partsDataGridView.CurrentRow == null || !partsDataGridView.CurrentRow.Selected) //checks if the current row is empty or if there is no selection
            {
                MessageBox.Show("Nothing Selected!", "Please Make A Slection");
                return;
            }

            Part deletepart = partsDataGridView.CurrentRow.DataBoundItem as Part; //storeing selection in Part veriable
            inventory.deletePart(deletepart); //deleteing selecting from bindinglist
        }

        //opens and populates modify parts screen
        private void partsModifyButton_Click(object sender, EventArgs e)
        {
           if(partsDataGridView.CurrentRow.DataBoundItem is Inhouse)
           {
               Inhouse selectedInhouse = partsDataGridView.CurrentRow.DataBoundItem as Inhouse; //stores selection in Inhouse object
               ModifyPart modifyPart = new ModifyPart(selectedInhouse);
           }
           else
           {
               Outsourced selectedInhouse = partsDataGridView.CurrentRow.DataBoundItem as Outsourced; //stores selection in Outsourced object
               ModifyPart modifyPart = new ModifyPart(selectedInhouse);
           } 

            

        }

        //takes input from search text box and returns a message if found or not
        private void partsSearchButton_Click(object sender, EventArgs e)
        {
            if (inventory.lookupPart(Int32.Parse(partsSearchValue.Text)) == null)
            {
                MessageBox.Show($"PartID: {Int32.Parse(partsSearchValue.Text)} was not found.");
                return;
            }
            Part partlookup = inventory.lookupPart(Int32.Parse(partsSearchValue.Text));
            MessageBox.Show($"Part { partlookup.Name } with PartID: { partlookup.PartID } was found.");
        }
        
        private void MainScreenSetup()
        {
            //set data source for Parts datagrid
            partsDataGridView.DataSource = Inventory.AllParts;
            productsDataGridView.DataSource = Inventory.Products;

            //Remove bottom row from datagrids
            partsDataGridView.AllowUserToAddRows = false;
            productsDataGridView.AllowUserToAddRows = false;
        }

        private void SetupSampelData()
        {
            inventory.addPart(new Inhouse { PartID = 1, Name = "Georgie", Price = 1.00m, InStock = 1, Min = 1, Max = 1, MachineID = 8675309 });
            inventory.addPart(new Inhouse { PartID = 2, Name = "Sean", Price = 10.00m, InStock = 5, Min = 0, Max = 10, MachineID = 8675309 });
            inventory.addPart(new Inhouse { PartID = 3, Name = "Justin", Price = 0.50m, InStock = 100, Min = 100, Max = 99, MachineID = 8675309 });
            inventory.addPart(new Inhouse { PartID = 4, Name = "Ookami", Price = 1000.00m, InStock = 0, Min = 1, Max = 9999, MachineID = 8675309 });
        }
    }
}
