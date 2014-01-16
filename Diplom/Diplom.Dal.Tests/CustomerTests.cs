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
            

        
            var dal = new CustomerDal();
            //var birthDate = new DateTime(1980, 2, 1);           
            dal.CreateCustomer(new Customer {Name = "aaa", BirthDate = "11"});
            Customer[] results = dal.FindCustomer("aaa", "11").ToArray();
            Assert.AreEqual(1, results.Length);
            Assert.AreEqual("aaa", results[0].Name);
            
        }
    }
         
}