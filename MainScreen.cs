using MatthewEvans___BFM1___Software_I___C968.model;
using System;
using System.Collections;
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

        //Value used to setup data only once
        int setupData = 0;

        public mainScreen()
        {
            InitializeComponent();

            //sets properties for MainScreen datagridviews
            MainScreenSetup();

            //sets up sampel data for debug
            SetupSampelData();
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

        //button used to delete selected product
        private void productsDeleteButton_Click(object sender, EventArgs e)
        {
            if(productsDataGridView.CurrentRow == null || !productsDataGridView.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing Selected!", "Please Make A Selection");
                return;
            }

            Product deleteproduct = productsDataGridView.CurrentRow.DataBoundItem as Product;
            inventory.removeProduct(deleteproduct);

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

        //opens and populates modify products screen
        private void productsModifyButton_Click(object sender, EventArgs e)
        {
            if (productsDataGridView.CurrentRow == null || !productsDataGridView.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing Selected!", "Please Make A Selection");
                return;
            }
            Product selectedProduct = productsDataGridView.CurrentRow.DataBoundItem as Product;
            ModifyProduct modifyProduct = new ModifyProduct(selectedProduct);
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
        
        //Settings for main screen form
        private void MainScreenSetup()
        {
            //set data source for Parts datagrid
            partsDataGridView.DataSource = Inventory.AllParts;
            productsDataGridView.DataSource = Inventory.Products;

            //Remove bottom row from datagrids
            partsDataGridView.AllowUserToAddRows = false;
            productsDataGridView.AllowUserToAddRows = false;
        }

        //Sample Data
        private void SetupSampelData()
        {
            if (setupData < 1)
            {
                //Part Sample Data
                inventory.addPart(new Inhouse(1, "Rear Weight Bracket", 67.41m, 1, 1, 20, 8675309));
                inventory.addPart(new Inhouse(2, "Magnetic Hitch Pin", 18.99m, 5, 1, 10, 8675309));
                inventory.addPart(new Inhouse(3, "Strorage Compartment Cover", 7.46m, 10, 10, 99, 8675309));
                inventory.addPart(new Inhouse(4, "3/4 in. Push-to-Connect Brass Ball Valve", 26.97m, 22, 5, 100, 8675309));
                inventory.addPart(new Inhouse(5, "1/2 in. FIP x MHT Bras Flanged Sillcock Valve", 7.78m, 11, 5, 100, 8675309));


                //Product Sample Data
                inventory.addProduct(new Product { ProductID = 1, Name = "Riding Lawnmower", InStock = 6, Min = 2, Max = 10, Price = 2299.00m });
                inventory.addProduct(new Product { ProductID = 2, Name = "40 Gal. 36,000 BTU Tank Water Heater", InStock = 2, Min = 0, Max = 2, Price = 519.00m });
                inventory.addProduct(new Product { ProductID = 3, Name = "Colorado 5-Light Black Modern Farmhouse Rectangular Chandelier", InStock = 0, Min = 0, Max = 5, Price = 353.00m });


                setupData++;
            }
            
        }
    }
}
