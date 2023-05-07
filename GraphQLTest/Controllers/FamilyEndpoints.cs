using Microsoft.EntityFrameworkCore;
using GraphQLTest;
using GraphQLTest.Models;
namespace GraphQLTest.Controllers;

public static class FamilyEndpoints
{
    public static void MapFamilyEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Family", async (Context db) =>
        {
            return await db.Families.ToListAsync();
        })
        .WithName("GetAllFamilys")
        .Produces<List<Family>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Family/{id}", async (int Id, Context db) =>
        {
            return await db.Families.FindAsync(Id)
                is Family model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetFamilyById")
        .Produces<Family>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Family/{id}", async (int Id, Family family, Context db) =>
        {
            var foundModel = await db.Families.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(family);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateFamily")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Family/", async (Family family, Context db) =>
        {
            db.Families.Add(family);
            await db.SaveChangesAsync();
            return Results.Created($"/Familys/{family.Id}", family);
        })
        .WithName("CreateFamily")
        .Produces<Family>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Family/{id}", async (int Id, Context db) =>
        {
            if (await db.Families.FindAsync(Id) is Family family)
            {
                db.Families.Remove(family);
                await db.SaveChangesAsync();
                return Results.Ok(family);
            }

            return Results.NotFound();
        })
        .WithName("DeleteFamily")
        .Produces<Family>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
