using AdventureWorks.Business.Models;
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

        private void findCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindCustomerForm findCustomerForm = new FindCustomerForm();
            DialogResult dr = findCustomerForm.ShowDialog();
        }
    }
}
