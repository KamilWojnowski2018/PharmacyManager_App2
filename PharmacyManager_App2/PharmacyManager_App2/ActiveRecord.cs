using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    abstract class ActiveRecord
    {
        internal SqlConnection _connection;

        public int ID { get; set; }

        public abstract void Save(int id);
        public abstract void Reload(int id);
        public abstract void Remove();

        protected void Open()
        {
            try
            {
               _connection = new SqlConnection
                {
                    ConnectionString = "Integrated Security=SSPI;" +
                                       "Data Source=.\\SQLEXPRESS01;" +
                                       "Initial Catalog=PharmacyDB;"
                };
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        protected void Close()
        {
            _connection.Close();
        }
    }
}
