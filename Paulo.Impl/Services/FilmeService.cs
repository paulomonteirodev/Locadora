using System.Collections.Generic;
using System.Linq;
using Paulo.Core.Repositories;
using Paulo.Core.Services;
using Paulo.Data.Entities;

namespace Paulo.Impl.Services
{
    public class FilmeService : Service<Filme>, IFilmeService
    {
        private readonly IFilmeRepository filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
            : base(filmeRepository)
        {
            this.filmeRepository = filmeRepository;
        }

        public List<Filme> GetAllToSelect()
        {
            return filmeRepository.GetAllToSelect().OrderBy(o => o.Nome).ToList();
        }
    }
}
