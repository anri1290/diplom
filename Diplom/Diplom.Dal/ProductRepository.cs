using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Diplom.Dal
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(typeof (Customer));
                transaction.Commit();
            }
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(Guid customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetBirthDate(string birthDate)
        {
            throw new NotImplementedException();
        }
      
    }

}