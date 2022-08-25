using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pessoa : Base
    {
        [Required()]
        [MaxLength(10, ErrorMessage = "O nome não deve ter menos de 10 caracteres"), MinLength(5)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "O CPF deve ter 11 caracteres"), MinLength(11)]
        public string Cpf { get; set; }
        public int IdCidade { get; set; }
        public int Idade { get; set; }
    }
}
