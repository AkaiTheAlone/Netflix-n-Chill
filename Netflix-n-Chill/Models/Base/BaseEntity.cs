
using System.ComponentModel.DataAnnotations;

namespace Netflix_n_Chill.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
