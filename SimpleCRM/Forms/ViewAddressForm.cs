using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace SimpleCRM.Forms
{
    public partial class ViewAddressForm : Form
    {
        public int customerID;
        public ViewAddressForm(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        private void ViewAddressForm_Load(object sender, EventArgs e)
        {
            string BingMapsKey = "AoHjuGjJkUkm9bvqbkDhsywUm1R1X-6W2g-s6z1wqqEJGHDBaxN75lIB9VWuV3QX"; //bing maps API key

            IGetCustomerInfo customerInfoUtil = DependencyInjectorUtility.GetCustomerInfo(); //create instance of customer utility

            Address address = customerInfoUtil.GetAddress(customerID); //retrieve Address object for the customer selected in the previous form
            Address fixedAddress = FixAddress(address);
            string wholeAddress = "";
            if (!(String.IsNullOrWhiteSpace(fixedAddress.AddressLine2))) //create a string called wholeAddress for use in query - if AddressLine2 is not null/empty, set wholeAddress = line1 + line2
            {
                wholeAddress = fixedAddress.AddressLine1 + " " + fixedAddress.AddressLine2;
            } else
            {
                wholeAddress = fixedAddress.AddressLine1;
            }

            string locationString = "http://dev.virtualearth.net/REST/v1/Locations?postalCode=" + fixedAddress.PostalCode + "&addressLine=" + wholeAddress + "&o=xml&key=" + BingMapsKey; //create the geocode request using address info

            XmlDocument doc = Execute(locationString);
            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");

            var lat = XmlExtensions.GetTag(doc, nsmgr, "Latitude"); //get latitude and longitude values
            var lon = XmlExtensions.GetTag(doc, nsmgr, "Longitude");

            string mapString = " http://dev.virtualearth.net/REST/v1/Imagery/Map/Road/"+ lat +"," + lon + "/15?mapSize=610,287&pp=" + lat + "," + lon + ";&key=" + BingMapsKey; //create the static map request using the lat and lon values retreived above
            wbMapView.Navigate(mapString);

        }

        public Address FixAddress(Address address) //used to replace white space for formatting the geocoding URL
        {
            Address fixedAddress = new Address();

            fixedAddress.AddressLine1 = address.AddressLine1.Replace(" ","%");
            fixedAddress.CountryRegion = address.CountryRegion.Replace(" ", "%");
            fixedAddress.PostalCode = address.PostalCode.Replace(" ", "%");

            if (!(String.IsNullOrWhiteSpace(address.AddressLine2)))
            {
                fixedAddress.AddressLine2 = address.AddressLine2.Replace(" ", "%");
            }

            return fixedAddress;
        }

        public XmlDocument Execute(string url) //handle the execution of the Bing API url as an httmp web request and stored in a response. Take the response and load it into a new XmlDoc 
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());

            return (xmlDoc);

        }
        
    }
    public static class XmlExtensions //created to retrieve the latitude and longitude values from the XML Bing-API response
    {
        public static string GetTag(this XmlDocument doc,
                                    XmlNamespaceManager nsmgr, string tag)
        {
            string path = string.Format(".//rest:{0}", tag);
            var entry = doc.SelectSingleNode(path, nsmgr);
            return entry != null ? entry.InnerText : null;
        }

        public static string GetTag(this XmlNode node,
                                    XmlNamespaceManager nsmgr, string tag)
        {
            string path = string.Format(".//rest:{0}", tag);
            var entry = node.SelectSingleNode(path, nsmgr);
            return entry != null ? entry.InnerText : null;
        }
    }
}


    
