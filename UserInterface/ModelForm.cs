using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BisnessLogic.Model;

namespace UserInterface
{
    public partial class ModelForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();
        public ModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cashBoxes = new List<CashBoxView>();


            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashBoxView(model.CashDesks[i], i, 10, 26 * i);
                cashBoxes.Add(box);
                Controls.Add(box.Price);
                Controls.Add(box.Leave);
                Controls.Add(box.CashDeskName);
                Controls.Add(box.QueueLenght);
            }

            model.Start();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = model.CashDeskSpeed;
            numericUpDown2.Value = model.CustomerSpeed;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeed = (int)numericUpDown1.Value;
            model.CashDeskSpeed = (int)numericUpDown2.Value;
        }
    }
}
