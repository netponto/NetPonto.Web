using NHibernate;

namespace NetPonto.Infrastructure
{
    public class NHibernateRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        public T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public void SaveOrUpdate(T t)
        {
            _session.SaveOrUpdate(t);
        }
    }
}