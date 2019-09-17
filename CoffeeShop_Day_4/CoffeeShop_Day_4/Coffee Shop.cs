using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop_Day_4
{
    public partial class CoffeeShop : Form
    {
        private struct AllInfo
        {
            public string name, contactNo, address, order, quantity;
        }

        // global 
        List<AllInfo> listOfAllInfo = new List<AllInfo>();
        string allSavedData, lastSavedData;
        AllInfo allInfo;

        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            GetAllData();
            if (CanBeAdded())
            {
                AddData();
                ClearAllTextBox();
                ShowData(lastSavedData);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowData(allSavedData);
        }

        private void GetAllData()
        {
            allInfo.name = customerNameTextBox.Text;
            allInfo.contactNo = contactNoTextBox.Text;
            allInfo.address = addressTextBox.Text;
            allInfo.order = orderComboBox.Text;
            allInfo.quantity = quantityTextBox.Text;
        }

        private bool CanBeAdded()
        {
            if( String.IsNullOrEmpty(allInfo.order) )
            {
                MessageBox.Show("Order can't be empty!");
                return false;
            }
            if (String.IsNullOrEmpty(allInfo.quantity))
            {
                MessageBox.Show("Quantity can't be empty!");
                return false;
            }
            if (String.IsNullOrEmpty(allInfo.contactNo))
            {
                MessageBox.Show("Contact No. can't be empty!");
                return false;
            }
            if( !IsUniqueContactNo(allInfo.contactNo))
            {
                MessageBox.Show("Contact No. you provide is used before!\nProvide a new one!");
                return false;
            }
            return true;
        }

        private bool IsUniqueContactNo(string testNo)
        {
            foreach(AllInfo current in listOfAllInfo)
            {
                if (current.contactNo == testNo) return false;
            }
            return true;
        }

        private void AddData()
        {
            lastSavedData = "Customer Name : " + allInfo.name + "\nContact Number : " + allInfo.contactNo + "\nAddress : " + allInfo.address + "\n\nOrder : " + allInfo.order + "\nQuantity : " + allInfo.quantity;

            allSavedData += "\n\n"+ lastSavedData;

            listOfAllInfo.Add(allInfo);
        }

        private void ClearAllTextBox()
        {
            customerNameTextBox.Text = "";
            contactNoTextBox.Text = "";
            addressTextBox.Text = "";
            orderComboBox.Text = "";
            quantityTextBox.Text = "";
        }


        private void ShowData(string data)
        {
            showDataRichTextBox.Text = data;
        }

        private void fau()
        {
            int qq;
            try
            {
                qq = Convert.ToInt32(allInfo.quantity);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
