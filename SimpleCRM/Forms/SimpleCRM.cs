using AdventureWorks.Business.Models;
using SimpleCRM.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCRM
{
    public partial class SimpleCRM : Form
    {
        public SimpleCRM()
        {
            InitializeComponent();
        }

        //Load each respective form depending on which menu item is clicked
        private void findCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindCustomerForm findCustomerForm = new FindCustomerForm();
            DialogResult dr = findCustomerForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindProductsForm findProductsForm = new FindProductsForm();
            DialogResult dr = findProductsForm.ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            DialogResult dr = addProductForm.ShowDialog();
        }

        private void findSalesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindSalesOrderForm findSalesOrderForm = new FindSalesOrderForm();
            DialogResult dr = findSalesOrderForm.ShowDialog();
        }

        private void newSalesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSalesOrderForm addSalesOrderForm = new AddSalesOrderForm();
            DialogResult dr = addSalesOrderForm.ShowDialog();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            DialogResult dr = addCustomerForm.ShowDialog();
        }
    }
}
