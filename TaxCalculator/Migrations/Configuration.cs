﻿namespace TaxCalculator.Migrations
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
                new Citizen{ CitizenId=1, FirstName="Ranjeep", LastName="Maharjan", District="Lalitpur",  Municipality="Lalitpur", StreetName="Kumaripati", Wardno=8 },
                new Citizen{ CitizenId=2, FirstName="Pitambar", LastName="Jha", District="Sarlahi",  Municipality="Sarlahi", StreetName="Malangwa", Wardno=8 },
                new Citizen{ CitizenId=3, FirstName="रन्जिप ", LastName="महर्जन", District="Dharke",  Municipality="Dhding", StreetName="ke ho ke ho", Wardno=8 }
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

            var zones = new List<Zone>
            {
                new Zone{ Id = 1, Code="बागमति", Description="बागमति"},
                new Zone{ Id = 2, Code="मेची", Description="मेची"},
                new Zone{ Id = 3, Code="कोशी", Description="कोशी"},
                new Zone{ Id = 4, Code="सगरमाथा", Description="सगरमाथा"},
                new Zone{ Id = 5, Code="Mahakali", Description="Mahakali"},
                new Zone{ Id = 6, Code="भेरी", Description="भेरी"}




            };
            zones.ForEach(z => context.Zones.Add(z));
            context.SaveChanges();

        }
    }
}
