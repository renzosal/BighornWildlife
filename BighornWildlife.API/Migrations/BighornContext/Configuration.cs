namespace BighornWildlife.API.Migrations.BighornContext
{
    using BighornWildlife.API.Entities;
    using BighornWildlife.API.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BighornWildlife.API.BighornContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\BighornContext";
        }

        protected override void Seed(BighornWildlife.API.BighornContext context)
        {
            var Species = new List<Specie> {
                new Specie { Name = "Mule Deer", WildlifeType = WildlifeTypes.Mammal, Image = "mule-deer-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "White-tail Deer", WildlifeType = WildlifeTypes.Mammal, Image = "white-tail-deer-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Elk", WildlifeType = WildlifeTypes.Mammal, Image = "elk-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Moose", WildlifeType = WildlifeTypes.Mammal, Image = "moose-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Pronghorn Antelope", WildlifeType = WildlifeTypes.Mammal, Image = "pronghorn-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Bighorn Sheep", WildlifeType = WildlifeTypes.Mammal, Image = "bighorn-sheep-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Black Bear", WildlifeType = WildlifeTypes.Mammal, Image = "black-bear-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Mountain Lion", WildlifeType = WildlifeTypes.Mammal, Image = "mountain-lion-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Coyote", WildlifeType = WildlifeTypes.Mammal, Image = "coyote-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },

                new Specie { Name = "Wild Turkey", WildlifeType = WildlifeTypes.Bird, Image = "wild-turkey-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Golden Eagle", WildlifeType = WildlifeTypes.Bird, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Bald Eagle", WildlifeType = WildlifeTypes.Bird, Image = "bald-eagle-m.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Sage Grouse", WildlifeType = WildlifeTypes.Bird, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Ruffed Grouse", WildlifeType = WildlifeTypes.Bird, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Ring-Necked Pheasant", WildlifeType = WildlifeTypes.Bird, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },

                new Specie { Name = "Golden Trout", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Splake", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Grayling", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Mountain Whitefish", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Cutthroat Trout", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Brown Trout", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Rainbow Trout", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Brook Trout", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Lake Trout", WildlifeType = WildlifeTypes.Fish, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },

                new Specie { Name = "Sego Lily", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Silvery Lupine", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Indian Paintbrush", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Forget-me-not", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Shootingstar", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Prairie Smoke", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Arrowleaf Balsamroot", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Yarrow", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "American Bistort", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "False Dandelion", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Sticky Geranium", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" },
                new Specie { Name = "Larkspur", WildlifeType = WildlifeTypes.Plant, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud" }

            };

            context.Species.AddOrUpdate(
                s => s.Name, Species.ToArray()
             );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
