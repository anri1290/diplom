using System;
using System.Collections.Generic;
using Diplom.Dal;

namespace Diplom.Dal
{
    public interface IProductRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        Customer GetByRecId(Guid customerrecid);
        Customer GetByName(string name);
        ICollection<Customer> GetBirthDate(string birthDate);
    }
}



    
    
