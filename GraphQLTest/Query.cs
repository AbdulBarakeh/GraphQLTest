using GraphQLTest.Controllers;
using GraphQLTest.Models;

namespace GraphQLTest
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Person> GetPeople([Service] Context context) =>
            context.People;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Family> GetFamily([Service] Context context) =>
            context.Families;
    }
}
