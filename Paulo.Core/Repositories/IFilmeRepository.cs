using Paulo.Data.Entities;
using System.Collections.Generic;

namespace Paulo.Core.Repositories
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        /// <summary>
        /// Busca todos os filmes quem podem ser selecionados
        /// </summary>
        /// <returns></returns>
        IEnumerable<Filme> GetAllToSelect();
    }
}
