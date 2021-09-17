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

namespace CurrencyProjeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlfile = new XmlDocument();
            xmlfile.Load(today);

            string getdollars = xmlfile.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblGetDollars.Text = getdollars.ToString();

            string selldollars = xmlfile.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblSellDolars.Text = selldollars.ToString();

            string geteuro = xmlfile.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblGetEuro.Text = geteuro.ToString();

            string selleuro = xmlfile.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblSellEuro.Text = selleuro.ToString();
        }

        private void BtnGetDollars_Click(object sender, EventArgs e)
        {
            TxtCurrenty.Text = LblGetDollars.Text;
        }

        private void BtnSellDollars_Click(object sender, EventArgs e)
        {
            TxtCurrenty.Text = LblSellDolars.Text;
        }

        private void BtnGetEuro_Click(object sender, EventArgs e)
        {
            TxtCurrenty.Text = LblGetEuro.Text;
        }

        private void BtnSellEuro_Click(object sender, EventArgs e)
        {
            TxtCurrenty.Text = LblSellEuro.Text;
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            double currenty, amount, total;
            currenty = Convert.ToDouble(TxtCurrenty.Text);
            amount = Convert.ToDouble(TxtAmount.Text);
            total = currenty * amount;
            TxtTotal.Text = total.ToString();
        }

        private void TxtCurrenty_TextChanged(object sender, EventArgs e)
        {
            TxtCurrenty.Text = TxtCurrenty.Text.Replace(".", ",");
        }
    }
}
