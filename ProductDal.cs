using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    // VERİ ÇEKME , EKLEME ,SİLME İŞLEMLERİ YAPACAĞIZ
    public class ProductDal
    {
  
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=Etrade; integrated security=true");


        public List<Product> GetAll()
        {
            ConnectionControl();
            // SQL BAĞLANMA
            SqlCommand command = new SqlCommand("SELECT * FROM PRODUCTS", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    

                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])

                };
                // KAYITLI OLAN KULLANICILARI GETİRECEK
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            return products;

        }
        // BAĞLANTI KONTROLÜNÜ METOD HALİNE GETİRDİM
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("INSERT INTO PRODUCTS VALUES(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Update Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "Delete from Products where Id=@id", _connection);

            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();

            _connection.Close();

        }



    }
}