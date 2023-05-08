using GraphQLTest.Controllers;

namespace GraphQLTest
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Person> GetPeople([Service] AabdtestContext context) =>
            context.People;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Family> GetFamily([Service] AabdtestContext context) =>
            context.Families;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FamilyPerson> GetFamilyPeople([Service] AabdtestContext context) =>
            context.FamilyPeople;
    }
}
