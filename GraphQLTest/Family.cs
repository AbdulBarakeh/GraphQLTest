using System;
using System.Collections.Generic;

namespace GraphQLTest;

public partial class Family
{
    public int Id { get; set; }

    public string FamilyName { get; set; } = null!;

    public virtual ICollection<FamilyPerson> FamilyPeople { get; set; } = new List<FamilyPerson>();
}
