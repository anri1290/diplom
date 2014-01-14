using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Diplom.Dal.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Create()
        {
            var dal = new CustomerDal();
            dal.CreateCustomer(new Customer() { Name = "aaa", BirthDate = new DateTime(1980,2,1) });
            var results = dal.FindCustomer("aaa", new DateTime(1980, 2, 1)).ToArray();
            Assert.AreEqual(1, results.Length);
            Assert.AreEqual("aaa", results[0].Name);
        }
    }
}
