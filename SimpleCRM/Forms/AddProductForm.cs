using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCRM.Forms
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Product prodToEnter = createProduct();

            IGetCustomerInfo customerUtility = DependencyInjectorUtility.GetCustomerInfo();

            try
            {
                customerUtility.AddProduct(prodToEnter);
            }
            catch (Exception ex)
            {
                throw;
            }

            this.Close();
        }

        private Product createProduct()
        {
            //Handle conversions for non-null values
            decimal newListPrice;
            if (!decimal.TryParse(txtListPrice.Text, out newListPrice))
            {
                MessageBox.Show("Must enter a valid decimal value for List Price");
                
            }
            decimal newStandardCost;
            if (!decimal.TryParse(txtStandardCost.Text, out newStandardCost))
            {
                MessageBox.Show("Must enter valid decimal value for Standard Cost");
            }
            DateTime newSellStartDate;
            if (!DateTime.TryParse(txtSellStartDate.Text, out newSellStartDate))
            {
                MessageBox.Show("Must enter valid Sell Start Date - MM/DD/YYYY");
            }

            //Create product
            //Set non-null Product properties
            Product prodToEnter = new Product
            {
                ProductName = txtProductName.Text,
                ProductNumber = txtProductNumber.Text,
                StandardCost = newStandardCost,
                ListPrice = newListPrice,
                SellStartDate = newSellStartDate
            };

            //Handles null text boxes, data conversions, and product properties
            if (!(string.IsNullOrWhiteSpace(txtColor.Text)))
            {
                prodToEnter.Color = txtColor.Text;
            }
            else { prodToEnter.Color = null; } //hanle null color

            if (!(string.IsNullOrWhiteSpace(txtSize.Text)))
            {
                prodToEnter.Size = txtSize.Text;
            }
            else { prodToEnter.Size = null; } //handle null size

            //check if not-null
            if (!(string.IsNullOrWhiteSpace(txtWeight.Text)))
            {
                //create a new decimal value to contain the weight
                decimal newWeight;
                //check if the text entered can be converted into a decimal and preform conversion if true
                if (!decimal.TryParse(txtWeight.Text, out newWeight))
                {
                    //prompt for a valid entry if false
                    MessageBox.Show("Must enter valid Weight value");
                }
                //set product property to new value
                prodToEnter.Weight = newWeight;
            }
            else { prodToEnter.Weight = null; } //handle no weight value

            if (!(string.IsNullOrWhiteSpace(txtSellEndDate.Text)))
            {
                DateTime newSellEndDate;
                if (!DateTime.TryParse(txtSellEndDate.Text, out newSellEndDate))
                {
                    MessageBox.Show("Must enter valid Sell End Date - MM/DD/YYYY");
                }
                prodToEnter.SellEndDate = newSellEndDate;
            }
            else { prodToEnter.SellEndDate = null; } //handle null end date

            if (!(string.IsNullOrWhiteSpace(txtDiscontinuedDate.Text)))
            {
                DateTime newDiscontinuedDate;
                if (!DateTime.TryParse(txtDiscontinuedDate.Text, out newDiscontinuedDate))
                {
                    MessageBox.Show("Must enter valid Discontinued Date - MM/DD/YYYY");
                }
                prodToEnter.DiscontinuedDate = newDiscontinuedDate;
            }
            else { prodToEnter.DiscontinuedDate = null; } //handle null discontinued date

            if (!(string.IsNullOrWhiteSpace(txtProductCategoryID.Text)))
            {
                int newProductCategoryID;
                if (!int.TryParse(txtProductCategoryID.Text, out newProductCategoryID))
                {
                    MessageBox.Show("Must enter valid Product Category ID (integer)");
                }
                prodToEnter.ProductCategoryID = newProductCategoryID;
            }
            else { prodToEnter.ProductCategoryID = null; } //handle a null Category ID

            if (!(string.IsNullOrWhiteSpace(txtProductModelID.Text)))
            {
                int newProductModelID;
                if (!int.TryParse(txtProductModelID.Text, out newProductModelID))
                {
                    MessageBox.Show("Must enter valid Product Model ID (integer)");
                }
                prodToEnter.ProductModelID = newProductModelID;
            }
            else { prodToEnter.ProductModelID = null; } //handle a null Model ID

            //Upload Image information
            if (cbUploadImage.Checked)
            {
                ThumbNailImage newImage = getImage();
                prodToEnter.ThumbNailFileName = newImage.imageFileName;
                prodToEnter.ThumbNailPhoto = newImage.ImageFile; 
            } else
            {
                prodToEnter.ThumbNailPhoto = null;
                prodToEnter.ThumbNailFileName = null;
            }

            return prodToEnter;
        }

        //method created to get the image and file path for an uploaded image - found the easiest method of getting both these values in one method was to just create a model for a ThumbNailImage and create
        //two properties for the filePath string and the byte[] Image
        public ThumbNailImage getImage()
        {
            // Show dialog
            openImageDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            openImageDialog.CheckFileExists = true;
            var dialogResult = openImageDialog.ShowDialog();

            //verify and capture file
            string filePath = string.Empty;
            if (dialogResult == DialogResult.OK)
            {

                filePath = openImageDialog.FileName;
            }
            else
            {
                MessageBox.Show("No File Selected");
            }

            //Read stream and place data into buffer
            byte[] buffer;
            using (FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fStream.Length];
                fStream.Read(buffer, 0, buffer.Length);
            }

            ShowPicture(buffer);

            ThumbNailImage newImage = new ThumbNailImage
            {
                ImageFile = buffer,
                imageFileName = filePath
            };
           

            return newImage;
        }

        private void ShowPicture(byte[] pictureBuffer)
        {
            Stream picStream = new MemoryStream(pictureBuffer);
            picBoxProduct.Image = new Bitmap(picStream);
        }
    }
}
