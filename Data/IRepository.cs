using System.Collections.Generic;
using System.Threading.Tasks;
public interface IRepository<T>
{
  Task<IEnumerable<T>> GetAll();

  void Delete(long id);

  Task<T> Insert(T t);
  Task<T> Update(T t);

}