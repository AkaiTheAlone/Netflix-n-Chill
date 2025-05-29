using Netflix_n_Chill.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace Netflix_n_Chill.Models
{
    public class Person : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
    }
}
