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
            if (inhouseRadioButton.Checked == true) 
            {

                Inhouse inhouse = new Inhouse(int.Parse(idValue.Text), nameValue.Text, decimal.Parse(priceCostValue.Text), Int32.Parse(inventoryValue.Text), Int32.Parse(minValue.Text), Int32.Parse(maxValue.Text), Int32.Parse(machineIDValue.Text));

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
                Outsourced outsourced = new Outsourced(int.Parse(idValue.Text), nameValue.Text, decimal.Parse(priceCostValue.Text), Int32.Parse(inventoryValue.Text), Int32.Parse(minValue.Text), Int32.Parse(maxValue.Text), Int32.Parse(companyNameValue.Text));

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

        //function for restricting key presses to digits and backspace
        private void keyPress_DigitBackspace(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar; //variable "ch" for storing keypress

            if (!Char.IsDigit(ch) && ch != 8) //first checks if "ch" is a digit, then checks that key press
            {                                //is equal to backspace enumeration
                e.Handled = true;
            }
        }

        //restrics input to numbers and backspace
        private void inventoryValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress_DigitBackspace(sender, e);
        }

        //restrics input to numbers and backspace
        private void machineIDValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress_DigitBackspace(sender, e);
        }

        //restrics input to numbers and backspace
        private void maxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress_DigitBackspace(sender, e);
        }

        //restrics input to numbers and backspace
        private void minValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress_DigitBackspace(sender, e);
        }

        //restrics input to numbers, "." and backspace
        private void priceCostValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar; //variable "ch" for storing keypress
            int i = 1;

            if (!Char.IsDigit(ch) && ch != 8) //first checks if "ch" is a digit, then checks to see ifthe 
            {                                //key press was the symbol '.' and finally it checks to see if
                e.Handled = true;           //the key pressed was equal to backspace's enumeration
            }
            
            while (i == 1)
            {
                if (Char.IsSymbol(ch))
                {
                    e.Handled = true;
                    i--;
                }
            }


        }
    }
    }
