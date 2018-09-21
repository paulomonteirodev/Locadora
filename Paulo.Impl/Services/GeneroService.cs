using System.Collections.Generic;
using Paulo.Core;
using Paulo.Core.Repositories;
using Paulo.Core.Services;
using Paulo.Data.Entities;

namespace Paulo.Impl.Services
{
    public class GeneroService : Service<Genero>, IGeneroService
    {
        private readonly IGeneroRepository generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
            : base(generoRepository)
        {
            this.generoRepository = generoRepository;
        }
    }
}
