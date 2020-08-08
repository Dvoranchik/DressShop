using System;
using System.Windows.Forms;
using BisnessLogic.Model;

namespace UserInterface
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = new Product()
            {
                Name = textBox2.Text,
                Price = Convert.ToDecimal(textBox3.Text),
                Count = Convert.ToInt32(textBox4.Text)

            };
            Close();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

    }
}
