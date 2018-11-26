using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManager_App2
{
    class Orders: ActiveRecord
    {
        public int IdOrder { get; }
        public int IdCustomer { get; }
        public int IdProduct { get; }
        public int IdSale { get; }
        public int? IdPrescription { get; }
        
        public Orders(Prescription prescription, Product product, Customer customer, Sale sale)
        {
            IdCustomer = customer.ID;
            IdProduct = product.ID;

            if (product.WithPrescription == true)
            {
                IdPrescription = prescription.ID;
            }
            else IdPrescription = null;

            IdSale = sale.ID;
            IdOrder=ID;
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
