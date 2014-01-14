using System;

namespace Diplom.Dal
{
    public class Customer
    {
        public virtual Guid RecId { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; set; }
    }
}