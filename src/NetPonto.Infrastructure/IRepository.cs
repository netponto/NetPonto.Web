using System;

namespace NetPonto.Infrastructure
{
    public interface IRepository<T> where T: IEntity
    {
        T Get(int id);
        void SaveOrUpdate(T t);
    }
}