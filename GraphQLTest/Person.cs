using System;
using System.Collections.Generic;

namespace GraphQLTest;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int Height { get; set; }

    public string? Gender { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public virtual ICollection<FamilyPerson> FamilyPeople { get; set; } = new List<FamilyPerson>();
}
