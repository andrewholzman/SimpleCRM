using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
using SimpleCRM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCRM.Forms
{
    public partial class AddSalesOrderForm : Form
    {

        List<SalesOrderProductViewModel> productList = new List<SalesOrderProductViewModel>(); //create persistant list of ViewModel objects to display in the DGV
        public AddSalesOrderForm()
        {
            InitializeComponent();
        }

        public void AddSalesOrderForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //create Model class objects and instances of Utility classes
            SalesOrderHeader soHeader = new SalesOrderHeader();
            SalesOrderDetail soDetail = new SalesOrderDetail();
            Product soProduct = new Product();
            Address soAddress = new Address();
            //ProductViewModel soProductViewModel = null;

            IGetCustomerInfo customerInfo = DependencyInjectorUtility.GetCustomerInfo();
            IGetProductInfo productInfo = DependencyInjectorUtility.GetProductInfo();
            IGetSalesOrderInfo salesOrderInfo = DependencyInjectorUtility.GetSalesInfo();

            //set properties of the SalesOrderHeader object from their respective fields
            int customerIDAsInt;

            if (Int32.TryParse(txtCustomerID.Text, out customerIDAsInt)) { soHeader.CustomerID = customerIDAsInt; }
            else { MessageBox.Show("Please enter a valid customer ID"); }
            if (chkOrderOnlineFlag.Checked) { soHeader.OrderOnlineFlag = true; }
            else { soHeader.OrderOnlineFlag = false; }

            byte revisionNumber;
            if (!byte.TryParse(txtRevisionNumber.Text, out revisionNumber)) { }
            soHeader.RevisionNumber = revisionNumber;
            soHeader.Status = (byte)numStatus.Value;
            
            if(!(String.IsNullOrWhiteSpace(txtAccountNumber.Text))) { soHeader.AccountNumber = txtAccountNumber.Text; }
            else { soHeader.AccountNumber = null;  }
            if (!(String.IsNullOrWhiteSpace(txtPurchaseOrderNumber.Text))) { soHeader.PurchaseOrderNumber = txtPurchaseOrderNumber.Text; }
            else { soHeader.PurchaseOrderNumber = null; }
            if (!(String.IsNullOrWhiteSpace(txtCreditCardApprovalCode.Text))) { soHeader.CreditCardApprovalCode = txtCreditCardApprovalCode.Text; }
            else { soHeader.CreditCardApprovalCode = null; }

            soHeader.OrderDate = dtpOrderDate.Value;
            soHeader.DueDate = dtpDueDate.Value;
            if (dtpShipDate.Checked) { soHeader.ShipDate = dtpShipDate.Value; }
            else { soHeader.ShipDate = null;  }
            
            if (!(String.IsNullOrWhiteSpace(txtComment.Text))) { soHeader.Comment = txtComment.Text;  }
            else { soHeader.Comment = null;  }

            soAddress = customerInfo.GetAddress(customerIDAsInt);
            if (!(soAddress == null)) //check if the address returned by the GetAddress() function is not null and set the Bill/Ship id values
            {
                soHeader.BillToAddressID = soAddress.AddressID;
                soHeader.ShipToAddressID = soAddress.AddressID;
            }
            else
            {
                soHeader.BillToAddressID = null;
                soHeader.ShipToAddressID = null;
            }
            soHeader.ShipMethod = cbShipMethod.Text;

            //Do work to calculate SubTotal, TaxAmt, TotalDue based upon entries in the dgvProductList

            //set soHeader decimal values

            //Preform DB inserts for SalesOrderHeader and SalesOrderDetail
            

        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            Product soProduct = new Product();
            SalesOrderDetail soDetailToAdd = new SalesOrderDetail();
            SalesOrderProductViewModel soProductVM = null;


            IGetProductInfo productInfo = DependencyInjectorUtility.GetProductInfo();

            //retrieve the product info fr the entered product ID
            int productIDAsInt;
            if (Int32.TryParse(txtProductID.Text, out productIDAsInt))
            {
                soProduct = productInfo.GetProduct(productIDAsInt);
                if (!(soProduct == null)) //ensure the entered product number is valid (actually tied to a product)
                {
                    
                    soDetailToAdd.ProductID = productIDAsInt;

                } else
                {
                    MessageBox.Show("Please enter a valid product ID");
                }
            }
            else { MessageBox.Show("Please enter a valid product ID"); }

            soDetailToAdd.ProductID = soProduct.ProductID;
            soDetailToAdd.UnitPrice = soProduct.ListPrice;
            soDetailToAdd.SalesOrderID = 00000;
            soDetailToAdd.SalesOrderDetailID = 00000;

            decimal discountAmount;
            if (!decimal.TryParse(txtDiscount.Text, out discountAmount))
            {
                MessageBox.Show("Must enter a valid decimal value for Discount Amount");

            }
            soDetailToAdd.UnitPriceDiscount = discountAmount;

            soDetailToAdd.OrderQty = (short)numQuantity.Value;

            //UnitPrice * (1 - UnitPriceDiscount) * OrderQty - DB Calculation for LineTotal
            soDetailToAdd.LineTotal = (soDetailToAdd.UnitPrice * (1 - soDetailToAdd.UnitPriceDiscount) * soDetailToAdd.OrderQty);

            //soProductVM = new SalesOrderProductViewModel(soDetailToAdd);

            
           soProductVM = new SalesOrderProductViewModel(soDetailToAdd);
           productList.Add(soProductVM);
                
            
            dgvProductList.DataSource = null;
            dgvProductList.DataSource = productList;


        }


        private void btnLookUp_Click(object sender, EventArgs e)
        {
            FindProductsForm findProductsForm = new FindProductsForm();
            DialogResult dr = findProductsForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
