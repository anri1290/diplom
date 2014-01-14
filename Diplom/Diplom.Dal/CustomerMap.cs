using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Diplom.Dal
{
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.RecId, m => m.Generator(new GuidGeneratorDef()));
            Property(
                x => x.Name,
                x =>
                    {
                        x.NotNullable(false);
                        //x.Index("LogRecord_OriginalId");
                    });
            Property(
               x => x.BirthDate,
               x =>
               {
                   x.NotNullable(false);
                   //x.Index("LogRecord_OriginalId");
               });
        }
    }
}