using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;

namespace Diplom.Dal
{
    public class ProductRepository : IProductRepository
    {
        private readonly Customer[] _customer = new[]
                 {
                     new Customer {Name = "Melon", BirthDate = "2012"},
                     new Customer {Name = "Pear", BirthDate = "2013"},
                     new Customer {Name = "Milk", BirthDate = "2014"},
                     new Customer {Name = "Coca Cola", BirthDate = "2017"},
                     new Customer {Name = "Pepsi Cola", BirthDate = "2212"},
                 };

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
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(customer);
                transaction.Commit();
            }
        }

        public void Remove(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(customer);
                transaction.Commit();
            }
        }

        public Customer GetByRecId(Guid customerrecid)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Customer>(customerrecid);
        }

        public Customer GetByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Customer customer = session
                    .CreateCriteria(typeof(Customer))
                    .Add(Restrictions.Eq("Name", name))
                    .UniqueResult<Customer>();
                return customer;
            }
        }

        public ICollection<Customer> GetBirthDate(string birthDate)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var customer = session
                    .CreateCriteria(typeof(Customer))
                    .Add(Restrictions.Eq("BirthDate", birthDate))
                    .List<Customer>();
                return customer;
            }
        }
        
      

      
    }

}