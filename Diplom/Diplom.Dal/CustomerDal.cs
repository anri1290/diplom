using System;
using System.Collections.Generic;
using NHibernate;

namespace Diplom.Dal
{
    public class CustomerDal : BaseDal
    {
        public void CreateCustomer(Customer customer)
        {
            using (ISession session = OpenSession())
            {
                using (var t = session.BeginTransaction())
                {
                    session.Save(customer);
                    t.Commit();
                }
            }
        }

        public IEnumerable<Customer> FindCustomer(string name, DateTime birthDate)
        {
            using (ISession session = OpenSession())
            {
                return session.QueryOver<Customer>().Where(x => x.Name == name && x.BirthDate == birthDate).List();
            }
        }
    }
}