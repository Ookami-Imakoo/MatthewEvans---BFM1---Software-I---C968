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
    public partial class addPartScreen : Form
    {
        public addPartScreen()
        {
            InitializeComponent();
        }

        private void inhouseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            machineIDLabel.Show();
            machineIDValue.Show();

            companyNameLabel.Hide();
            companyNameValue.Hide();
        }

        private void outsourcedRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            //Hides Machine Lable and Value
            machineIDLabel.Hide();
            machineIDValue.Hide();

            companyNameLabel.Show();
            companyNameValue.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            int PartID;
            string Name;
            decimal Price;
            int InStock;
            int Min;
            int Max;

            int MachineID;
            string CompanyName;


            PartID = Int32.Parse(idValue.Text);
            Name = nameValue.Text;
            Price = Decimal.Parse(priceCostValue.Text);
            InStock = Int32.Parse(inventoryValue.Text);
            Min = Int32.Parse(minValue.Text);
            Max = Int32.Parse(maxValue.Text);
            MachineID = Int32.Parse(machineIDValue.Text);
            CompanyName = companyNameValue.Text;

            Inventory.addPart(PartID, Name, Price, InStock, Min, Max);

            this.Close();
        }
        
    }
    }
