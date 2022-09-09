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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            //int testResult = test();

            if (inhouseRadioButton.Checked == true /*&& testResult == 1*/) 
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
                else if (inventoryLogic(inhouse) == 4)
                {
                    MessageBox.Show("Check Price");
                }
                else if (inventoryLogic(inhouse) == 99)
                {
                    MessageBox.Show("Fields Blank");
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            else if (outsourcedRadioButton.Checked == true && nameValue.Text != "")
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
            //else
            //{
            //    MessageBox.Show("Please check that all fields are filled out correctly before submitting");
            //}
            
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
            else if (decimal.TryParse(priceCostValue.Text, out decimal parsedValue)){
                return 4;
            }
            else if (nameValue.Text == null)
            {
                return 99;
            }
            else
            {
                return 0;
            }
        }

        //private int test()
        //{
        //    decimal parsedDecimal;

        //    if (nameValue.Text == "")
        //    {
        //        MessageBox.Show("Please input a valid NAME");
        //        return 0;
        //    }
        //    if (priceCostValue.Text == "")
        //    {
        //        MessageBox.Show("Please input a valid Cost (format -- x.xx)");
        //        return 0;
        //    }
        //    else return 1;

        //}


        //restrics input to numbers, "." and allows for the backspace key to still work
        private void inventoryValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar; //veriable for storeing the key pressed

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46) //checks to see if the ch is a digit a backspace(key inumeration: 8)
            {                                            //or a delete (key inumeration: 46)
                e.Handled = true;
            }
        }
    }
    }
