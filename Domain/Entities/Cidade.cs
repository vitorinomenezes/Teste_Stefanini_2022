using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cidade :Base
    {
        [Required(ErrorMessage = "Digite o nome da cidade.")]
        [MaxLength(10, ErrorMessage = "O nome da cidade deve ter 10 caracteres"), MinLength(5)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Digite a uf da cidade.")]
        [MaxLength(2, ErrorMessage = "A uf só deverá ter 2 caracteres"), MinLength(2)]
        public string Uf { get; set; }
    }
}
