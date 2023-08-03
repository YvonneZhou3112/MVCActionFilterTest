namespace MVC_Test.Migrations
{
    using MVC_Test.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Test.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVC_Test.Models.MovieDBContext";
        }

        protected override void Seed(MVC_Test.Models.MovieDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Movies.AddOrUpdate(i=>i.Title,
                new Movie {Title="When Harry Met Sally" ,
                ReleaseDate=DateTime.Parse("1989-1-11"),
                Genre="Romatic Comedy",
                Rating="PG",
                price=7.99M});
        }
    }
}
