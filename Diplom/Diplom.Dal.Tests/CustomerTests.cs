using System;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Diplom.Dal.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        private object _sessionFactory;
        

        [Test]
        public void Create()
        {
            var birthDate = new DateTime(1980, 2, 1);
            var customer = new Customer { Name = "aaa", BirthDate = birthDate };
            IProductRepository repository = new ProductRepository();
            repository.Add(customer);

           // var birthDate = new DateTime(1980, 2, 1);
           // var customer = new Customer { Name = "aaa", BirthDate = birthDate };
           // IProductRepository repository = new ProductRepository();
           // repository.Add(customer);

            // use session to try to load the product
           // using (ISession session = _sessionFactory.OpenSession())
           // {
             //   var fromDb = session.Get<Customer>(customer.RecId);
                // Test that the product was successfully inserted
             //   Assert.IsNotNull(fromDb);
              //  Assert.AreNotSame(customer, fromDb);
              //  Assert.AreEqual(customer.Name, fromDb.Name);
               // Assert.AreEqual(customer.BirthDate, fromDb.BirthDate);
          //  }
            //var dal = new CustomerDal();
            //var birthDate = new DateTime(1980, 2, 1);           
            //dal.CreateCustomer(new Customer {Name = "aaa", BirthDate = birthDate});
           // Customer[] results = dal.FindCustomer("aaa", birthDate).ToArray();
            //Assert.AreEqual(1, results.Length);
           //Assert.AreEqual("aaa", results[0].Name);
            
        }
    }
         
}