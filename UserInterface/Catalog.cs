
using System.Data.Entity;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class Catalog<T> : Form where T : class
    {

        public Catalog(DbSet<T> set)
        {
            InitializeComponent();
            dataGridView1.DataSource  = set.Local.ToBindingList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
