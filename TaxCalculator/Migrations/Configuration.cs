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
                new Citizen{ CitizenId=1, FirstName="कुलमान  ", LastName="श्रेष्ठ", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन",KittaNo = "118", Wardno=10,CitizenshipNo = "8546" },
                new Citizen{ CitizenId=2, FirstName="पूर्ण लक्ष्मी", LastName=" शाक्य ", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन",KittaNo = "271", Wardno=10,CitizenshipNo = "4571" },
                new Citizen{ CitizenId=3, FirstName="रन्जिप ", LastName="महर्जन", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन", KittaNo = "101",Wardno=10, CitizenshipNo = "9988" }
            };


            citizens.ForEach(c => context.Citizens.Add(c));
            context.SaveChanges();

            var lands = new List<CitizenLand>
            {
                new CitizenLand{ Id= 1 , VDC = "Kapan" , WardNo = "3", SheetNo = "552", KittaNo = "118", ValuationArea = 145.90m, CitizenId = 1},
                new CitizenLand{ Id= 2 , VDC = "Kapan" , WardNo = "4", SheetNo = "44", KittaNo = "271", ValuationArea = 89.43m, CitizenId = 2},
                new CitizenLand{ Id= 3 , VDC = "Kapan" , WardNo = "7", SheetNo = "34", KittaNo = "101", ValuationArea = 85, CitizenId = 3},
            };

            lands.ForEach(z => context.CitizenLands.Add(z));
            context.SaveChanges();

            var citizenHouse = new List<CitizenHouse>
            {
                new CitizenHouse{ CitizenId=1, Area=2923.31m, Floor=2.5m},
                new CitizenHouse{ CitizenId=2, Area=1285.11m, Floor=5},
                new CitizenHouse{ CitizenId=3, Area=1156.12m, Floor=1}
            };

            citizenHouse.ForEach(h => context.CitizenHouses.Add(h));
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

            //var propertyType = new List<PropertyType>
            //{
            //    new PropertyType{Id=1, FiscalYear="73/74", Type="House", DepriciationRate=2.25m, PropertyCost = 1285.11m},
            //    new PropertyType{Id=2, FiscalYear="73/74", Type="Land", DepriciationRate=2.25m, PropertyCost=28310.78m},
            //    new PropertyType{Id=3, FiscalYear="74/75", Type="House", DepriciationRate=3.25m, PropertyCost=28310.78m},
            //    new PropertyType{Id=4, FiscalYear="74/75", Type="Land", DepriciationRate=3.25m, PropertyCost=28310.78m}
            //};

            //propertyType.ForEach(d => context.PropertyType.Add(d));
            //context.SaveChanges();

           
         



        }
    }
}
