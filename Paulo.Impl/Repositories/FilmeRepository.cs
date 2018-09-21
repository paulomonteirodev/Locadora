using System.Collections.Generic;
using System.Linq;
using Paulo.Core.Repositories;
using Paulo.Data.Entities;

namespace Paulo.Impl.Repositories
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public override IEnumerable<Filme> GetAll()
        {
            return db.Filme.Where(x => !x.Deleted && !x.Genero.Deleted);
        }

        public IEnumerable<Filme> GetAllToSelect()
        {
            return db.Filme.Where(x => x.Genero.Ativo && 
                                  x.Ativo && !x.Deleted && 
                                  !x.Genero.Deleted && 
                                  (x.LocacaoId == null || x.Locacao.Deleted));
        }
    }
}
