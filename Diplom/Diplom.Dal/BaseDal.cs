using System.Data.SqlServerCe;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Diplom.Dal
{
    public class BaseDal
    {
        public BaseDal()
        {
            this.connectionString = string.Format("Data Source={0}; max database size = 512;", uri);
        }
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        private ISessionFactory CreateSessionFactory()
        {
            _configuration = new Configuration();
            _configuration.DataBaseIntegration(Configure);
            //_configuration.Configure();
            //_configuration.AddAssembly(typeof(Product).Assembly);

            var mapper = new ModelMapper();
            mapper.AddMapping<CustomerMap>();

            mapper.BeforeMapClass += (mi, t, map) => map.Table(t.Name.ToLowerInvariant());
            mapper.BeforeMapJoinedSubclass += (mi, t, map) => map.Table(t.Name.ToLowerInvariant());
            mapper.BeforeMapUnionSubclass += (mi, t, map) => map.Table(t.Name.ToLowerInvariant());

            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            _configuration.AddMapping(domainMapping);

            new SchemaExport(_configuration).Execute(false, true, false);

            using (var engine = new SqlCeEngine(connectionString))
            {
                if (!File.Exists(uri))
                    engine.CreateDatabase();
                //else
                // engine.Compact(connectionString);
            }

            ISessionFactory buildSessionFactory = _configuration.BuildSessionFactory();
            return buildSessionFactory;
        }
        string uri = "database.sdf";
        private string connectionString;

        public void Configure(IDbIntegrationConfigurationProperties c)
        {
          
           

            c.Dialect<MsSqlCe40Dialect>();
            c.ConnectionString = connectionString;
            
            c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            c.SchemaAction = SchemaAutoAction.Update;
            c.Driver<SqlServerCeDriver>();


          
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}