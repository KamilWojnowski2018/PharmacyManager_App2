using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    class Prescription: Customer
    {
        public int Amount { get; set; }
        public int Number { get; set; }

        public override void Save(int id)
        {
            base.Save(id);
        }

        public override void Reload(int id)
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            Console.WriteLine("Podaj numer id Recepty, którą chcesz usunąć: ");
            ID = int.Parse(Console.ReadLine());
            Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DeletePrescription";
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
                Console.WriteLine($"Wykonałeś następującą operację: DELETE FROM prescription WHERE IdPrescription = {ID} ");
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
