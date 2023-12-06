namespace MotoApp.Data.Repositories;

using MotoApp.Data.Entities;

public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();

    T? GetById(int id);
}
