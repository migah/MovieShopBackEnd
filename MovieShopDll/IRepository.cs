using System.Collections.Generic;

namespace MovieShopDll
{
    public interface IRepository <T>
    {
        T Create(T t);
        T Read(int id);
        List<T> Read();
        void Delete(int id);
        T Update(T t);
    }
}
