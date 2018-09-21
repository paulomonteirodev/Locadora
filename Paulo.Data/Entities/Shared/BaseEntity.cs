using System;
using System.ComponentModel.DataAnnotations;

namespace Paulo.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataDeAtualizacao { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
