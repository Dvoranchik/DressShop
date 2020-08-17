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

        public ProductForm(Product product): this()
        {
            Product = Product ?? new Product();
            textBox2.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            Product.Name = textBox2.Text;
            Product.Price = numericUpDown1.Value;
            Product.Count = Convert.ToInt32(numericUpDown2.Value);

            Close();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

    }
}
