﻿using AdventureWorks.Business.Data;
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
    public partial class FindCustomerForm : Form
    {

        public FindCustomerForm()
        {
            InitializeComponent();
        }

        private void FindCustomerForm_Load(object sender, EventArgs e)
        {
            IGetCustomerInfo getCustomerInfo = DependencyInjectorUtility.GetCustomerInfo();
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            //Check if there is already a list of customers
            
        }
    }
}