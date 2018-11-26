using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    class Manager : ActiveRecord
    {
        public override void Reload(int id)
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void Save(int id)
        {
            throw new NotImplementedException();
        }

        public void ShowAll()

        {
            Open();
            SqlCommand command = new SqlCommand()
            {
                CommandText = "SELECT * FROM Product",
                CommandType = CommandType.Text,
                Connection = _connection
            };

            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("|--IdProduct--|---ProductName---|--ProductManufacturer--|--Price--|--Category--|--StockAmount--|--WithPrescription--|");
                        Console.WriteLine("|-------------|-----------------|-----------------------|---------|------------|---------------|--------------------|");
                        while (reader.Read())
                        {
                            Console.WriteLine
                            (                           
                                "|" + $"{reader.GetValue(0)}".PadRight(13) +
                                "|" + $"{reader.GetValue(1)}".PadRight(17) +
                                "|" + $"{reader.GetValue(2)}".PadRight(23) +
                                "|" + $"{reader.GetValue(3)}".PadRight(9) +
                                "|" + $"{reader.GetValue(4)}".PadRight(12) +
                                "|" + $"{reader.GetValue(5)}".PadRight(15) +
                                "|" + $"{reader.GetValue(6)}".PadRight(20) + "|"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Brak leków w bazie");
                    }
                }
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

        public void ShowAllOrders()
        {

            Open();
            SqlCommand command = new SqlCommand()
            {
                CommandText = "SELECT * FROM ShowAllOrders",
                CommandType = CommandType.Text,
                Connection = _connection
            };

            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("|-IdProduct-|-ProductName-|-ProductManufaturer-|-Price-|-Category-|-StockAmount-|-WithPrescription-|-IdCustomer-|-CustomerName-|-IdPrescription-|-PESEL-|");
                        Console.WriteLine("|-----------|-------------|--------------------|-------|----------|-------------|------------------|------------|--------------|----------------|-------|");
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                    "|" + $"{reader.GetValue(0)}".PadRight(11) +
                                    "|" + $"{reader.GetValue(1)}".PadRight(13) +
                                    "|" + $"{reader.GetValue(2)}".PadRight(20) +
                                    "|" + $"{reader.GetValue(3)}".PadRight(7) +
                                    "|" + $"{reader.GetValue(4)}".PadRight(10) +
                                    "|" + $"{reader.GetValue(5)}".PadRight(14) +
                                    "|" + $"{reader.GetValue(6)}".PadRight(17) +
                                    "|" + $"{reader.GetValue(7)}".PadRight(12) +
                                    "|" + $"{reader.GetValue(8)}".PadRight(14) +
                                    "|" + $"{reader.GetValue(9)}".PadRight(16) +
                                    "|" + $"{reader.GetValue(10)}".PadRight(7)                    
                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Brak zamówień");
                    }
                }
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
