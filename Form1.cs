﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductd();
        }

        private void LoadProductd()
        // KAYITLARI EKRANA YANSITIR
        {
            ProductDal productDal = new ProductDal();
            dgwProducts.DataSource = productDal.GetAll();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        ProductDal _productDal = new ProductDal();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)

            });
            // KAYIT YAPTIKTAN SONRA GÜNCELLEME OLSUN DİYE ÇAĞIRDIM
            LoadProductd();
            MessageBox.Show("Product Added !");




        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // TBX UPDATE BİLGİLER GELDİ
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
                
            };
            _productDal.Update(product);
            // KAYIT YAPTIKTAN SONRA GÜNCELLEME OLSUN DİYE ÇAĞIRDIM
            LoadProductd();
            MessageBox.Show("UPDATE !");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(Id);
            LoadProductd();
            


        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
