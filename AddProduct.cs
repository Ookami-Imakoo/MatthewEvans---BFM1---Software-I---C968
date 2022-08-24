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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        //closes add product screen
        private void productCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
