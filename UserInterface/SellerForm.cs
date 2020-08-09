using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BisnessLogic.Model;

namespace UserInterface
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }

        public SellerForm(Seller seller):this()
        {
            Seller = seller;
        }
        public SellerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = Seller ?? new Seller();
            s.Name = textBox1.Text;
            Close();
        }
    }
}
