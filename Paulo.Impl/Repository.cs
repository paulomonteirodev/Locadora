using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Paulo.Core;
using Paulo.Data.Context;
using Paulo.Data.Entities;

namespace Paulo.Impl
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected AppDbContext db = new AppDbContext();

        public virtual void Add(TEntity obj)
        {
            obj.DataDeCadastro = DateTime.Now;
            db.Set<TEntity>().Add(obj);

            db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().Where(x => !x.Deleted);
        }

        public IEnumerable<TEntity> GetAllByIds(List<int> ids)
        {
            return db.Set<TEntity>().Where(x => ids.Contains(x.Id));
        }

        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().FirstOrDefault(x => x.Id == id && !x.Deleted);
        }

        public void Remove(int id)
        {
            var obj = db.Set<TEntity>().Find(id);
            obj.Deleted = true;
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveMany(List<int> ids)
        {
            var allToRemove = db.Set<TEntity>().Where(x => ids.Contains(x.Id));

            foreach (var item in allToRemove)
            {
                item.Deleted = true;
            }

            db.SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            obj.DataDeAtualizacao = DateTime.Now;
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
