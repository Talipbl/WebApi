using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfaUi.Models;
using WfaUi.Models.ApiProcessors;

namespace WfaUi
{
    public partial class Form1 : Form
    {
        ProductProcessor _productPrecessor = new ProductProcessor();
        CategoryProcessor _categoryProcessor = new CategoryProcessor();
        int _id;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await GetList();
            List<Category> categories = await _categoryProcessor.GetCategories();

            cmbCategories.DataSource = categories.ToList();
            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "CategoryID";

            cmbUpdateCategories.DataSource = categories.ToList();
            cmbUpdateCategories.DisplayMember = "CategoryName";
            cmbUpdateCategories.ValueMember = "CategoryID";
        }

        private async Task GetList()
        {
            List<Product> products = await _productPrecessor.GetProducts();
            dataGridView1.DataSource = products.ToList();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                ProductName = txtProductName.Text,
                CategoryId = (int)cmbCategories.SelectedValue,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = short.Parse(txtUnitsInStock.Text)
            };

            bool result = await _productPrecessor.AddProduct(product);
            await GetList();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                ProductID = _id,
                ProductName = txtUpdateProduct.Text,
                CategoryId = (int)cmbUpdateCategories.SelectedValue,
                UnitPrice = decimal.Parse(txtUpdateUnitPrice.Text),
                UnitsInStock = short.Parse(txtUpdateUnitsInStock.Text)
            };

            bool result = await _productPrecessor.UpdateProduct(product);
            await GetList();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = await _productPrecessor.DeleteProduct(_id);
            await GetList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            txtUpdateProduct.Text = dataGridView1.CurrentRow.Cells[2].Value as string;
            cmbUpdateCategories.Text = dataGridView1.CurrentRow.Cells[3].Value as string;
            txtUpdateUnitPrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtUpdateUnitsInStock.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
