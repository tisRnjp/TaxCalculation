namespace TaxCalculator.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaxCalculator.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaxCalculator.DAL.CitizenDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaxCalculator.DAL.CitizenDbContext context)
        {

            var citizens = new List<Citizen>
            {
                new Citizen{ CitizenId=1, FirstName="Ranjeep", LastName="Maharjan", District="Lalitpur", Zone="Bagmati", Municipality="Lalitpur", StreetName="Kumaripati", Wardno=8 },
                new Citizen{ CitizenId=1, FirstName="Pitambar", LastName="Jha", District="Sarlahi", Zone="Janakpur", Municipality="Sarlahi", StreetName="Malangwa", Wardno=8 },
                new Citizen{ CitizenId=1, FirstName="रन्जिप ", LastName="महर्जन", District="Dharke", Zone="Dhading", Municipality="Dhding", StreetName="ke ho ke ho", Wardno=8 }
            };

            citizens.ForEach(c => context.Citizens.Add(c));
            context.SaveChanges();

            var properties = new List<CitizenProperty>
            {
                new CitizenProperty{ CitizenId=1, PropertyType="land", PropertyArea=250 },
                new CitizenProperty{ CitizenId=1, PropertyType="house", PropertyArea=500 },
                new CitizenProperty{ CitizenId=2, PropertyType="land", PropertyArea=500 },
                new CitizenProperty{ CitizenId=2, PropertyType="house", PropertyArea=1000 }
            };

            properties.ForEach(p => context.CitizenProperties.Add(p));
            context.SaveChanges();
        }
    }
}
