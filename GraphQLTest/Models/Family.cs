using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLTest.Models
{
    public class Family
    {
        //[Column("Id")]
        public int Id { get; set; }
        //[Column("FamilyName")]
        public string FamilyName { get; set; }
        //[ForeignKey("PersonFK")]
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
