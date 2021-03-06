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

            var citizens = new List<Citizen>
            {
                new Citizen{ CitizenId=1, FirstName="कुलमान  ", LastName="श्रेष्ठ", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन",KittaNo = "118", Wardno=10,CitizenshipNo = "8546",ZoneId = 1 },
                new Citizen{ CitizenId=2, FirstName="पूर्ण लक्ष्मी", LastName=" शाक्य ", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन",KittaNo = "271", Wardno=10,CitizenshipNo = "4571",ZoneId = 3},
                new Citizen{ CitizenId=3, FirstName="रन्जिप ", LastName="महर्जन", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन", KittaNo = "101",Wardno=10, CitizenshipNo = "9988", ZoneId = 4}
            };


            citizens.ForEach(c => context.Citizens.Add(c));
            context.SaveChanges();

            var lands = new List<CitizenLand>
            {
                new CitizenLand{ Id= 1 , VDC = "Kapan" , WardNo = "3", SheetNo = "552", KittaNo = "118", ValuationArea = 145.90m},
                new CitizenLand{ Id= 2 , VDC = "Kapan" , WardNo = "4", SheetNo = "44", KittaNo = "271", ValuationArea = 89.43m},
                new CitizenLand{ Id= 3 , VDC = "Kapan" , WardNo = "7", SheetNo = "34", KittaNo = "101", ValuationArea = 85},
            };

            lands.ForEach(z => context.CitizenLands.Add(z));
            context.SaveChanges();

            var citizenHouse = new List<CitizenHouse>
            {
                new CitizenHouse{ Area=2923.31m, Floor=2.5m},
                new CitizenHouse{ Area=1285.11m, Floor=5},
                new CitizenHouse{ Area=1156.12m, Floor=1}
            };

            citizenHouse.ForEach(h => context.CitizenHouses.Add(h));
            context.SaveChanges();



            var houseValuation = new List<HouseValuation>
            {
                new HouseValuation{ Description="भित्र काँचो बाहिर पाको ईट्टामा माटोको जोडाई भएको वा काठै काठबाट बनेको र जस्ता, झिङ्गति, टायल, एसवेसतसको छाना भएको घर",CostPerArea=600,DepreciationRate=3,DepreciationPeriod=25,HouseType="क"},
                new HouseValuation{ Description="भित्र बाहिर सिमेन्ट प्लास्टर गरि छाना ढलान वा आर वि सि गरिएको वा जस्ता, टायल, जिङ्गति, एसवेसटसको छाना भएको",CostPerArea=750,DepreciationRate=2,DepreciationPeriod=30,HouseType="ख"},
                new HouseValuation{ Description="भित्र बाहिर पाको ईट्टा वा ढुंगामा सिमेन्ट प्लास्टर गरि छाना ढलान (आर सी सी वा आर वि सी ) गरिएको घर",CostPerArea=1750,DepreciationRate=1,DepreciationPeriod=70,HouseType="ग"},
                new HouseValuation{ Description="आर सी सी फ्रेम स्तरकचरमा लिफ्ट / एस्कलेटर जडान भएको घर",CostPerArea=1800,DepreciationRate=0.75m,DepreciationPeriod=100,HouseType="घ"},
                new HouseValuation{ Description="स्टील फ्रेम स्तरकचर, फ्रविङत्रास, फाईवर वा यस्तै संग्रचना ",CostPerArea=1800,DepreciationRate=0.75m,DepreciationPeriod=100,HouseType="ङ"}
            };

            houseValuation.ForEach(h => context.HouseValuations.Add(h));
            context.SaveChanges();




        }
    }
}
