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

        public ModifyPart(Inhouse myInhouse)
        {
            InitializeComponent();

            ModifyPart modifyPart = new ModifyPart();


            modifyPart.idValue.Text = myInhouse.PartID.ToString();
            modifyPart.nameValue.Text = myInhouse.Name.ToString();
            modifyPart.inventoryValue.Text = myInhouse.InStock.ToString();
            modifyPart.priceCostValue.Text = myInhouse.Price.ToString();
            modifyPart. maxValue.Text = myInhouse.Max.ToString();
            modifyPart.minValue.Text = myInhouse.Min.ToString();
            
            modifyPart.Show();
        }
    }
}
