﻿using System;
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
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }

        public CustomerForm(Customer customer):this()
        {
            Customer = customer;
        }
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = Customer ?? new Customer();
            c.Name = textBox1.Text;
            Close();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
