using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLTest.Models
{
    public class Person
    {
        //[Column("Id")]
        public int Id { get; set; }
        //[Column("Name")]
        public string Name { get; set; }
        //[Column("Age")]
        public int Age { get; set; }
        //[Column("Gender")]
        public string? Gender { get; set; }
        //[Column("Height")]
        public int Height { get; set; }
        //[Column("CreateTime")]
        public DateTime CreateTime { get; set; }
        //[Column("UpdateTime")]
        public DateTime? UpdateTime { get; set; }

        public int FamilyId { get; set; }
        public Family Family { get; set; }
    }
}
