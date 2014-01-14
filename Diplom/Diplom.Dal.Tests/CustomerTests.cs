using System;
using System.Linq;
using NUnit.Framework;

namespace Diplom.Dal.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Create()
        {
            var dal = new CustomerDal();
            var birthDate = new DateTime(1980, 2, 1);
            dal.CreateCustomer(new Customer {Name = "aaa", BirthDate = birthDate});
            Customer[] results = dal.FindCustomer("aaa", birthDate).ToArray();
            Assert.AreEqual(1, results.Length);
            Assert.AreEqual("aaa", results[0].Name);
        }
    }
}