using System;
using System.Collections.Generic;

namespace GraphQLTest;

public partial class FamilyPerson
{
    public int Id { get; set; }

    public int FamilyFk { get; set; }

    public int PersonFk { get; set; }

    public virtual Family FamilyFkNavigation { get; set; } = null!;

    public virtual Person PersonFkNavigation { get; set; } = null!;
}
