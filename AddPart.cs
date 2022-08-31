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

                //invetoryLogicSwitch(inhouse);

                if (inventoryLogic(inhouse) == 1)
                {
                    inventory.addPart(inhouse);
                    this.Close();
                }
                else if (inventoryLogic(inhouse) == 2)
                {
                    MessageBox.Show("Inventory Below Min Values");
                }
                else if (inventoryLogic(inhouse) == 3)
                {
                    MessageBox.Show("Inventory Above Max Values");
                }
                else
                {
                    MessageBox.Show("Error");
                }

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

                //invetoryLogicSwitch(outsourced);

                if (inventoryLogic(outsourced) == 1)
                {
                    inventory.addPart(outsourced);
                    this.Close();
                }
                else if (inventoryLogic(outsourced) == 2)
                {
                    MessageBox.Show("Inventory Below Min Values");
                }
                else if (inventoryLogic(outsourced) == 3)
                {
                    MessageBox.Show("Inventory Above Max Values");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }   
            this.Close();
        }

        //closes Add Part screen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int inventoryLogic(Part part)
        {
            if (part.InStock <= part.Max && part.InStock >= part.Min)
            {
                return 1;
            }
            else if (part.InStock < part.Min)
            {
                return 2;
            }
            else if (part.InStock > part.Max)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
    }
