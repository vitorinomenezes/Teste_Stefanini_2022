using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}