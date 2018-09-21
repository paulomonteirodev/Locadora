using System.Collections.Generic;
using Dapper;
using Paulo.Core.Repositories;
using Paulo.Data.Entities;

namespace Paulo.Impl.Repositories
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public override IEnumerable<Genero> GetAll()
        {
            var cn = db.Database.Connection;

            var sql = @"SELECT * FROM GENERO WHERE DELETED = 0";

            return cn.Query<Genero>(sql);
        }
    }
}
