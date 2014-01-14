using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
namespace Diplom.Dal
{
    public class CustomerDal : BaseDal
    {
        public void CreateCustomer(Customer customer)
        {
            using (var session = OpenSession())
            {
                session.Save(customer);
            }
        }
        public IEnumerable<Customer> FindCustomer(string name, DateTime birthDate)
        {
            using (var session = OpenSession())
            {
                return session.QueryOver<Customer>().Where(x => x.Name==name && x.BirthDate == birthDate).List();
            }
        }
    }
    public class BaseDal
    {
        public ISession OpenSession()
        {
            throw new NotImplementedException();
        }
    }

    public class Customer
    {
        public virtual Guid RecId {get;set;}
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; set; }
    }
}
