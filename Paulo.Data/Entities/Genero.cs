using System.Collections.Generic;

namespace Paulo.Data.Entities
{
    public class Genero : BaseEntity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
