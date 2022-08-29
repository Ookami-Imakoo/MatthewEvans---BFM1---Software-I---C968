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
    public partial class ModifyPart : Form
    {
        public ModifyPart()
        {
            InitializeComponent();
        }

        //constoructor for ModifyParts page if an inhouse object is passed in
        public ModifyPart(Inhouse myInhouse)
        {
            //calls for defualt constructor to initialize components
            ModifyPart modifyPart = new ModifyPart();

            //sets Inhouse Radio Button to true
            modifyPart.inhouseRadioButton.Checked = true;

            //shows Machine ID Label/Value and hides Company Name Label/Value
            modifyPart.machineIDLabel.Show();
            modifyPart.machineIDValue.Show();
            modifyPart.companyNameLabel.Hide();
            modifyPart.companyNameValue.Hide();

            //sets data from the passed in inhouse object
            modifyPart.idValue.Text = myInhouse.PartID.ToString();
            modifyPart.nameValue.Text = myInhouse.Name.ToString();
            modifyPart.inventoryValue.Text = myInhouse.InStock.ToString();
            modifyPart.priceCostValue.Text = myInhouse.Price.ToString();
            modifyPart. maxValue.Text = myInhouse.Max.ToString();
            modifyPart.minValue.Text = myInhouse.Min.ToString();
            modifyPart.machineIDValue.Text = myInhouse.MachineID.ToString();
            
            modifyPart.Show();
        }

        public ModifyPart(Outsourced myOutsourced)
        {
            //call for defualt constructor
            ModifyPart modifyPart = new ModifyPart();

            //sets Outsourced Radio Button to true
            modifyPart.outsourcedRadioButton.Checked = true;

            //shows Company Name Label/Value and hides Machine ID Label/Value
            modifyPart.machineIDLabel.Hide();
            modifyPart.machineIDValue.Hide();
            modifyPart.companyNameLabel.Show();
            modifyPart.companyNameValue.Show();

            //sets data from passed in outsourced object
            modifyPart.idValue.Text = myOutsourced.PartID.ToString();
            modifyPart.nameValue.Text = myOutsourced.Name.ToString();
            modifyPart.inventoryValue.Text = myOutsourced.InStock.ToString();
            modifyPart.priceCostValue.Text = myOutsourced.Price.ToString();
            modifyPart.maxValue.Text = myOutsourced.Max.ToString();
            modifyPart.minValue.Text = myOutsourced.Min.ToString();
            modifyPart.companyNameValue.Text = myOutsourced.CompanyName.ToString();

            modifyPart.Show();
        }
    }
}
