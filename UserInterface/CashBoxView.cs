using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BisnessLogic.Model;

namespace UserInterface
{
    class CashBoxView
    {
        private CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public ProgressBar Price { get; set; } 
        public NumericUpDown QueueLenght { get; set; }
        public Label Leave { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            CashDeskName = new Label();
            QueueLenght = new NumericUpDown();
            Price   = new ProgressBar();
            Leave = new Label();


            this.cashDesk = cashDesk;
            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new System.Drawing.Size(35,13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();

            QueueLenght.Location = new System.Drawing.Point(x+95, y);
            QueueLenght.Name = "numericUpDown1";
            QueueLenght.Size = new System.Drawing.Size(120, 22);
            QueueLenght.TabIndex = 2;
            QueueLenght.Maximum = 100000000000000000;



            Price.Location = new System.Drawing.Point(x+250, y);
            Price.Maximum = cashDesk.MaxQueueLenght;
            Price.Name = "progressBar" + number;
            Price.Size = new System.Drawing.Size(100, 23);
            Price.TabIndex = number;
            Price.Value = 0;


            Leave.AutoSize = true;
            Leave.Location = new System.Drawing.Point(x+400, y);
            Leave.Name = "label2." + number;
            Leave.Size = new System.Drawing.Size(35, 13);
            Leave.TabIndex = number;
            Leave.Text = cashDesk.ToString();


            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }


        private void CashDesk_CheckClosed(object sender, Check e)
        {
            QueueLenght.Invoke((Action) delegate
            {
                QueueLenght.Value += e.Price;
                Price.Value = cashDesk.Count;
                Leave.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
