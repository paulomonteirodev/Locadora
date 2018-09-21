using System.Collections.Generic;
using Dapper;
using Paulo.Core.Repositories;
using Paulo.Data.Context;
using Paulo.Data.Entities;

namespace Paulo.Impl.Repositories
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(AppDbContext db)
            : base(db)
        {

        }

        public override IEnumerable<Genero> GetAll()
        {
            var cn = db.Database.Connection;

            cn.Open();

            var sql = @"SELECT * FROM GENERO WHERE DELETED = 0";
            var result = cn.Query<Genero>(sql);

            cn.Close();

            return result;
        }
    }
}
