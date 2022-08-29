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
    public partial class addPartScreen : Form
    {
        Inventory inventory = new Inventory();
        public addPartScreen()
        {
            InitializeComponent();

            idValue.Text = inventory.partIDGenerator().ToString();
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (inhouseRadioButton.Checked == true)
            {
                Inhouse inhouse = new Inhouse
                {
                    PartID = int.Parse(idValue.Text),
                    Name = nameValue.Text,
                    Price = decimal.Parse(priceCostValue.Text),
                    InStock = Int32.Parse(inventoryValue.Text),
                    Min = Int32.Parse(minValue.Text),
                    Max = Int32.Parse(maxValue.Text),
                    MachineID = Int32.Parse(machineIDValue.Text)
                };

                inventory.addPart(inhouse);
                
            }
            else
            {
                Outsourced outsourced = new Outsourced
                {
                    PartID = int.Parse(idValue.Text),
                    Name = nameValue.Text,
                    Price = decimal.Parse(priceCostValue.Text),
                    InStock = Int32.Parse(inventoryValue.Text),
                    Min = Int32.Parse(minValue.Text),
                    Max = Int32.Parse(maxValue.Text),
                    CompanyName = companyNameValue.Text
                };

                inventory.addPart(outsourced);                
            }   
            this.Close();
        }

        //closes Add Part screen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
