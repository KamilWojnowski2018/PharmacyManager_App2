using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    class Customer : ActiveRecord
    {
        public string CustomerName { get; set; }
        public string Pesel { get; set; }


        public void AddCustomer()
        {
            Console.WriteLine("Dodaj nazwę klienta: ");
            CustomerName = Console.ReadLine();
            Console.WriteLine("Podaj nr PESEL klienta: ");
            Pesel = Console.ReadLine();
            try
            {
                Open();
                var command = new SqlCommand()
                {
                    CommandText =
                        "INSERT INTO Customer (CustomerName, PESEL)" +
                        "VALUES (@CustomerName, @PESEL)",
                    CommandType = CommandType.Text,
                    Connection = _connection,
                };

                command.Parameters.AddWithValue("@CustomerName", CustomerName);
                command.Parameters.AddWithValue("@PESEL", Pesel);
                command.ExecuteNonQuery();

                Console.WriteLine("Dodałeś nowego klienta do Bazy Danych");

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
        public void UpdateCustomer()
        {
            Console.Write("Podaj nazwę kolumny, w której chcesz dokonać zmiany: ");
            string table = Console.ReadLine();

            Console.WriteLine("Podaj nową wartość komórki: ");
            string cell = Console.ReadLine();
            Console.Write("Podaj wartość parametru IdCustomer dla którego ma zostać dokonana zmiana : ");
            ID = Convert.ToInt32(Console.ReadLine());
            try
            {
                Open();
                var command = new SqlCommand()
                {
                    CommandText =
                        "UPDATE Customer SET @Table = @Cell WHERE IdProduct = @Id",
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
                    Value = ID,
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
                Console.WriteLine(
                    $"Wykonałeś następującą operację: UPDATE Customer SET {table} = {cell} WHERE IdCustomer = {ID}");
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
        public override void Save(int id)
        {

            if (ID == 0)
            {
                AddCustomer();
            }
            else UpdateCustomer();
        }

        public override void Reload(int id)
        {
            try
            {
                Open();
                var command = new SqlCommand()
                {
                    CommandText = "SELECT * " + "FROM Customer " + "WHERE IdCustomer = @Id ",
                    CommandType = CommandType.Text,
                    Connection = _connection,
                };

                SqlParameter ParameterID = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = ID,
                    DbType = DbType.Int32
                };
                command.Parameters.Add(ParameterID);

                Console.WriteLine($"Wykonujesz następującą operację: SELECT * FROM Customer  WHERE IdCustomer = {ID} ");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ID= Convert.ToInt32(reader.GetValue(0));
                            CustomerName = Convert.ToString(reader.GetValue(1));
                            Pesel = Convert.ToString(reader.GetValue(2));

                        }
                    }
                    else
                    {
                        throw new Exception($"Klient o podanym numerze ID nie istnieje");
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
            Console.WriteLine("Podaj numer id Klienta, którego chcesz usunąć: ");
            ID = int.Parse(Console.ReadLine());
            Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeleteCustomer";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = _connection;

            SqlParameter ParameterId = new SqlParameter()
            {
                ParameterName = "@id",
                Value = ID,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
            };
            command.Parameters.Add(ParameterId);
            try
            {
                ID = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine($"Wykonałeś następującą operację: DELETE FROM Customer WHERE IdCustomer = {ID} ");
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
