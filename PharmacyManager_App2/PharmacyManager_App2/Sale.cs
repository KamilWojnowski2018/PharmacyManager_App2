using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    class Sale: ActiveRecord
    {
        public int Amount { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public Sale( int id, int amount, string date)
        {
            Date = DateTime.Parse(date);
            Amount = amount;
            ID = ID;
        }

        public override void Save(int id)
        {
            throw new NotImplementedException();
        }

        public override void Reload(int id)
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
