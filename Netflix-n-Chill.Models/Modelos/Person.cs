using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace Netflix_n_Chill.Models.Modelos
{

    //uncomment code below for linux usage
    //[Table("person")]
    public class Person
    {
        //[Column("id")]
        public long Id { get; set; }
        //[Column("first_name")]
        public string? FirstName { get; set; }
        //[Column("last_name")]
        public string? LastName { get; set; }
        //[Column("adress")]
        public string? Adress { get; set; }
        //[Column("gender")]
        public string? Gender { get; set; }
    }
}
