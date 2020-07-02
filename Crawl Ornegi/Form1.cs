using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Döviz_Kurlarını_Çekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string bugün = "https://www.tcmb.gov.tr/kurlar/today.xml";  // Adresimizi belirttik.
            var xmldoc = new XmlDocument();                             // Yeni bir Xml nesnesi oluşturduk.
            xmldoc.Load(bugün);                                         // Dökümanımıza bugünü yüklüyoruz.
            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value); //Xml sayfamızdan tarihi çekiyoruz.
            label20.Text = string.Format("Tarih {0}", tarih.ToShortDateString());

            string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml;   // İstediğimiz para birimini kod içerisinde filtreliyerek, çekmek istediğimiz yere kadar gidiyoruz ve string tipinde değişkene atıyoruz..
            string banknoteBuyingUsd = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteBuying").InnerText;// İstediğimiz para birimini kod içerisinde filtreliyerek, çekmek istediğimiz yere kadar gidiyoruz ve string tipinde değişkene atıyoruz..
            string ForexSellingUsd = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/ForexSelling").InnerText;   // İstediğimiz para birimini kod içerisinde filtreliyerek, çekmek istediğimiz yere kadar gidiyoruz ve string tipinde değişkene atıyoruz..
            string ForexBuyingUsd = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/ForexBuying").InnerText;// İstediğimiz para birimini kod içerisinde filtreliyerek, çekmek istediğimiz yere kadar gidiyoruz ve string tipinde değişkene atıyoruz..
            label13.Text = ForexBuyingUsd; //Verilerimizi label'a yazdırıyoruz.
            label16.Text = ForexSellingUsd;//Verilerimizi label'a yazdırıyoruz.
            label19.Text = banknoteBuyingUsd;//Verilerimizi label'a yazdırıyoruz.
            label1.Text = USD; //Verilerimizi label'a yazdırıyoruz.

            string Euro = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteSelling").InnerXml;
            string banknoteBuyingEuro = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteBuying").InnerText;
            string ForexSellingEuro = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/ForexSelling").InnerText;
            string ForexBuyingEuro = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/ForexBuying").InnerText;
            label18.Text = banknoteBuyingEuro;
            label15.Text = ForexSellingEuro;
            label12.Text = ForexBuyingEuro;
            label2.Text = Euro;

            string Pound = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/BanknoteSelling").InnerXml;
            string banknoteBuyingGBP = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/BanknoteBuying").InnerText;
            string ForexSellingGBP = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/ForexSelling").InnerText;
            string ForexBuyingGBP = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/ForexBuying").InnerText;
            label11.Text = ForexBuyingGBP;
            label14.Text = ForexSellingGBP;
            label17.Text = banknoteBuyingGBP;
            label3.Text = Pound;
        }
    }
}
