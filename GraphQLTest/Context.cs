using GraphQLTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GraphQLTest
{
    public class Context : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Family> Families { get; set; }
        public Context(DbContextOptions<Context> options): base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("Person");
            //.HasOne<Family>(x => x.Family)
            //.WithMany(x => x.Persons)
            //.HasForeignKey(x => x.Id)
            //.IsRequired();
            modelBuilder.Entity<Family>()
                .ToTable("Family")
                .HasMany<Person>(x => x.Persons)
                .WithOne(x => x.Family)
                .HasForeignKey(x => x.FamilyId);
            //TODO:Fix Relationship
        }
    }
}
