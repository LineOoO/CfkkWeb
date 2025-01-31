using NHibernate;
using NHibernate.Cfg;
using System.Web;
using System;
using ISession = NHibernate.ISession;
using CfkkWeb.Mappings;

namespace CfkkWeb.Helpers
{
    public class NhibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly("CfkkWeb");
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
