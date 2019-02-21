using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.DAL
{
    public class CitizenInitializer : DropCreateDatabaseIfModelChanges<CitizenDbContext>
    {
        protected override void Seed(CitizenDbContext context)
        {
            base.Seed(context);

            var citizens = new List<Citizen>
            {
                new Citizen{ CitizenId=1, FirstName="Ranjeep", LastName="Maharjan", District="Lalitpur", Municipality="Lalitpur", StreetName="Kumaripati", Wardno=8 },
                new Citizen{ CitizenId=1, FirstName="Pitambar", LastName="Jha", District="Sarlahi", Municipality="Sarlahi", StreetName="Malangwa", Wardno=8 }
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