using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    class Product : ActiveRecord
    {
        private int IdProduct;
        public string ProductName { get; set; }
        public string ProductManufacturer { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int StockAmount { get; set; }
        public bool WithPrescription { get; set; }

        public Product()
        {
        }

        public Product(string productName, string productManufacturer, decimal price, string category, int stockAmount, bool withPrescription)
        {
            IdProduct=ID;
            ProductName = productName;
            ProductManufacturer = productManufacturer;
            Price = price;
            Category = category;
            StockAmount = stockAmount;
            WithPrescription = withPrescription;
        }

        public void AddProduct()
        {
            Console.WriteLine("Dodaj nazwę produktu: ");
            ProductName = Console.ReadLine();
            Console.WriteLine("Podaj prod ucenta: ");
            ProductManufacturer = Console.ReadLine();
            Console.WriteLine("Podaj cenę: ");
            Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Podaj kategorię produktu: ");
            Category = Console.ReadLine();
            Console.WriteLine("Podaj ilość dostawy: ");
            StockAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Czy produkt wymaga recepty? [yes/no]");
            if (Console.ReadLine().ToLower() == "yes")
            {
                WithPrescription = true;
            }
            else
            {
                WithPrescription = false;
            }
            try
            {
                Open();
                var command = new SqlCommand()
                {
                    CommandText =
                        "INSERT INTO Product(ProductName, ProductManufacturer, Price, Category, StockAmount, WithPrescription)" +
                        "VALUES (@ProductName, @ProductManufacturer, @Price, @Category, @StockAmount, @WithPrescription)",
                    CommandType = CommandType.Text,
                    Connection = _connection,
                };
                command.Parameters.AddWithValue("@ProductName", ProductName);
                command.Parameters.AddWithValue("@ProductManufacturer", ProductManufacturer);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@Category", Category);
                command.Parameters.AddWithValue("@StockAmount", StockAmount);
                command.Parameters.AddWithValue("@WithPrescription", WithPrescription);
                command.ExecuteNonQuery();

                Console.WriteLine("Dodałeś nowy produkt do magazynu");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        public void Update()
        {
            Console.Write("Podaj nazwę kolumny, w której chcesz dokonać zmiany: ");
            string table = Console.ReadLine();


            if (table == "ProductName" || table == "ProductManufacturer" || table == "Category")
            {
                Console.WriteLine("Podaj nową wartość komórki: ");
                string cell = Console.ReadLine();
                Console.Write("Podaj wartość parametru IdProduct dla którego ma zostać dokonana zmiana : ");
                IdProduct = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Open();
                    var command = new SqlCommand()
                    {
                        CommandText =
                            "UPDATE Product SET @Table = @Cell WHERE IdProduct = @Id",
                        Connection = _connection,
                    };

                    SqlParameter ParameterTable = new SqlParameter()
                    {
                        ParameterName = "@Table",
                        Value = table,
                        DbType = DbType.String
                    };
                    SqlParameter ParameterId = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = IdProduct,
                        DbType = DbType.Int32
                    };
                    SqlParameter ParameterCell = new SqlParameter()
                    {
                        ParameterName = "@Cell",
                        Value = cell,
                        DbType = DbType.String
                    };
                    command.Parameters.Add(ParameterId);
                    command.Parameters.Add(ParameterTable);
                    command.Parameters.Add(ParameterCell);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Wykonałeś następującą operację: UPDATE Product SET {table} = {cell} WHERE IdProduct = {IdProduct}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Close();
                }
            }
            else if (table == "Price")
            {
                Console.WriteLine("Podaj nową wartość komórki: ");
                Price = decimal.Parse(Console.ReadLine());
                Console.Write("Podaj wartość parametru IdProduct dla którego ma zostać dokonana zmiana : ");
                IdProduct = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Open();
                    var command = new SqlCommand()
                    {
                        CommandText =
                            "UPDATE Product SET @Table = @Cell WHERE IdProduct = @Id",
                        Connection = _connection,
                    };

                    SqlParameter ParameterTable = new SqlParameter()
                    {
                        ParameterName = "@Table",
                        Value = table,
                        DbType = DbType.String
                    };
                    SqlParameter ParameterId = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = IdProduct,
                        DbType = DbType.Int32
                    };
                    SqlParameter ParameterPrice = new SqlParameter()
                    {
                        ParameterName = "@Cell",
                        Value = Price,
                        DbType = DbType.Decimal
                    };
                    command.Parameters.Add(ParameterId);
                    command.Parameters.Add(ParameterTable);
                    command.Parameters.Add(ParameterPrice);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Wykonałeś następującą operację: UPDATE Product SET {table} = {Price} WHERE IdProduct = {IdProduct}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Close();
                }
            }
            else if (table == "StockAmount")
            {
                Console.WriteLine("Podaj nową wartość komórki: ");
                StockAmount = int.Parse(Console.ReadLine());
                Console.Write("Podaj wartość parametru IdProduct dla którego ma zostać dokonana zmiana : ");
                IdProduct = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Open();
                    var command = new SqlCommand()
                    {
                        CommandText =
                            "UPDATE Product SET @Table = @Cell WHERE IdProduct = @Id",
                        Connection = _connection,
                    };

                    SqlParameter ParameterTable = new SqlParameter()
                    {
                        ParameterName = "@Table",
                        Value = table,
                        DbType = DbType.String
                    };
                    SqlParameter ParameterId = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = IdProduct,
                        DbType = DbType.Int32
                    };
                    SqlParameter ParameterStockAmount = new SqlParameter()
                    {
                        ParameterName = "@Cell",
                        Value = StockAmount,
                        DbType = DbType.Int32
                    };
                    command.Parameters.Add(ParameterId);
                    command.Parameters.Add(ParameterTable);
                    command.Parameters.Add(ParameterStockAmount);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Wykonałeś następującą operację: UPDATE Product SET {table} = {StockAmount} WHERE IdProduct = {IdProduct}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Close();
                }
            }
            else if (table == "WithPrescription")
            {
                Console.WriteLine("Czy produkt wymaga recepty? [yes/no]");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    WithPrescription = true;
                }
                else
                {
                    WithPrescription = false;
                }
                Console.Write("Podaj wartość parametru IdProduct dla którego ma zostać dokonana zmiana : ");
                IdProduct = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Open();
                    var command = new SqlCommand()
                    {
                        CommandText =
                            "UPDATE Product SET @Table = @Cell WHERE IdProduct = @Id",
                        Connection = _connection,
                    };

                    SqlParameter ParameterTable = new SqlParameter()
                    {
                        ParameterName = "@Table",
                        Value = table,
                        DbType = DbType.String
                    };
                    SqlParameter ParameterId = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = IdProduct,
                        DbType = DbType.Int32
                    };
                    SqlParameter ParameterWithPrescription = new SqlParameter()
                    {
                        ParameterName = "@Cell",
                        Value = WithPrescription,
                        DbType = DbType.Boolean
                    };
                    command.Parameters.Add(ParameterId);
                    command.Parameters.Add(ParameterTable);
                    command.Parameters.Add(ParameterWithPrescription);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Wykonałeś następującą operację: UPDATE Product SET {table} = {WithPrescription} WHERE IdProduct = {IdProduct}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Close();
                }
            }
        }

        public override void Save(int ID)
        {
            if (ID==1)
            {
                AddProduct();
            }       
            else Update();
        }

        public override void Reload(int id)
        {
            try
            {
                Open();
                var command = new SqlCommand()
                {
                    CommandText = "SELECT * " + "FROM Product " + "WHERE IdProduct = @Id ",
                    CommandType = CommandType.Text,
                    Connection = _connection,
                };

                SqlParameter ParameterID = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id,
                    DbType = DbType.Int32
                };
                command.Parameters.Add(ParameterID);

                Console.WriteLine($"Wykonujesz następującą operację: SELECT * FROM Product WHERE IdProduct = {id} ");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            IdProduct = Convert.ToInt32(reader.GetValue(0));
                            ProductName = Convert.ToString(reader.GetValue(1));
                            ProductManufacturer = Convert.ToString(reader.GetValue(2));
                            Price = Convert.ToDecimal(reader.GetValue(3));
                            Category = Convert.ToString(reader.GetValue(4));
                            StockAmount = Convert.ToInt32(reader.GetValue(5));
                            WithPrescription = Convert.ToBoolean(reader.GetValue(6));
                        }
                    }
                    else
                    {
                        throw new Exception($"Produkt o podanym numerze ID nie istnieje");
                    }
                }

                Console.WriteLine("Operację zakończono pomyślnie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        public override void Remove()
        {
            Console.WriteLine("Podaj numer id produktu, który chcesz usunąć: ");
            IdProduct = int.Parse(Console.ReadLine());
            Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeleteProduct";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = _connection;

            SqlParameter ParameterId = new SqlParameter()
            {
                ParameterName = "@id",
                Value = IdProduct,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
            };
            command.Parameters.Add(ParameterId);
            try
            {
                ID = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine($"Wykonałeś następującą operację: DELETE FROM product WHERE IdProduct = {IdProduct} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
