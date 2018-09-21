using System.Collections.Generic;
using System.Linq;
using Paulo.Core;
using Paulo.Data.Entities;

namespace Paulo.Impl
{
    public class Service<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> repository;

        public Service(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public List<TEntity> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public List<TEntity> GetAllByIds(List<int> ids)
        {
            return repository.GetAllByIds(ids).ToList();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void RemoveMany(List<int> ids)
        {
            repository.RemoveMany(ids);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }
    }
}
