namespace TaxCalculator.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using TaxCalculator.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaxCalculator.DAL.CitizenDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaxCalculator.DAL.CitizenDbContext context)
        {

            //var zones = new List<Zone>
            //{
            //    new Zone{ Id = 1, Code="बागमति", Description="बागमति"},
            //    new Zone{ Id = 2, Code="मेची", Description="मेची"},
            //    new Zone{ Id = 3, Code="कोशी", Description="कोशी"},
            //    new Zone{ Id = 4, Code="सगरमाथा", Description="सगरमाथा"},
            //    new Zone{ Id = 5, Code="Mahakali", Description="Mahakali"},
            //    new Zone{ Id = 6, Code="भेरी", Description="भेरी"}
            //};
            //zones.ForEach(z => context.Zones.AddOrUpdate(z));
            //context.SaveChanges();

            //var citizens = new List<Citizen>
            //{
            //    new Citizen{ CitizenId=1, FirstName="कुलमान  ", LastName="श्रेष्ठ", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन",KittaNo = "118", Wardno=10,CitizenshipNo = "8546",ZoneId = 1 },
            //    new Citizen{ CitizenId=2, FirstName="पूर्ण लक्ष्मी", LastName=" शाक्य ", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन",KittaNo = "271", Wardno=10,CitizenshipNo = "4571",ZoneId = 3},
            //    new Citizen{ CitizenId=3, FirstName="रन्जिप ", LastName="महर्जन", District="काठमाडौँ",  Municipality="बुढानिलकण्ठ", StreetName="कपन", KittaNo = "101",Wardno=10, CitizenshipNo = "9988", ZoneId = 4}
            //};


            //citizens.ForEach(c => context.Citizens.AddOrUpdate(c));
            //context.SaveChanges();

            //var lands = new List<CitizenLand>
            //{
            //    new CitizenLand{ Id= 1 , VDC = "Kapan" , WardNo = "3", SheetNo = "552", KittaNo = "118", ValuationArea = 145.90m,CitizenId=1},
            //    new CitizenLand{ Id= 2 , VDC = "Kapan" , WardNo = "4", SheetNo = "44", KittaNo = "271", ValuationArea = 89.43m,CitizenId=2},
            //    new CitizenLand{ Id= 3 , VDC = "Kapan" , WardNo = "7", SheetNo = "34", KittaNo = "101", ValuationArea = 85,CitizenId=3},
            //};

            //lands.ForEach(z => context.CitizenLands.AddOrUpdate(z));
            //context.SaveChanges();

            //var citizenHouse = new List<CitizenHouse>
            //{
            //    new CitizenHouse{ Area=2923.31m, Floor=2.5m,CitizenId=1},
            //    new CitizenHouse{ Area=1285.11m, Floor=5,CitizenId=2},
            //    new CitizenHouse{ Area=1156.12m, Floor=1,CitizenId=3}
            //};

            //citizenHouse.ForEach(h => context.CitizenHouses.AddOrUpdate(h));
            //context.SaveChanges();



            //var houseValuation = new List<HouseValuation>
            //{
            //    new HouseValuation{ Description="भित्र काँचो बाहिर पाको ईट्टामा माटोको जोडाई भएको वा काठै काठबाट बनेको र जस्ता, झिङ्गति, टायल, एसवेसतसको छाना भएको घर",CostPerArea=600,DepreciationRate=3,DepreciationPeriod=25,HouseType="क",FiscalYearId=5},
            //    new HouseValuation{ Description="भित्र बाहिर सिमेन्ट प्लास्टर गरि छाना ढलान वा आर वि सि गरिएको वा जस्ता, टायल, जिङ्गति, एसवेसटसको छाना भएको",CostPerArea=750,DepreciationRate=2,DepreciationPeriod=30,HouseType="ख",FiscalYearId=5},
            //    new HouseValuation{ Description="भित्र बाहिर पाको ईट्टा वा ढुंगामा सिमेन्ट प्लास्टर गरि छाना ढलान (आर सी सी वा आर वि सी ) गरिएको घर",CostPerArea=1750,DepreciationRate=1,DepreciationPeriod=70,HouseType="ग",FiscalYearId=5},
            //    new HouseValuation{ Description="आर सी सी फ्रेम स्तरकचरमा लिफ्ट / एस्कलेटर जडान भएको घर",CostPerArea=1800,DepreciationRate=0.75m,DepreciationPeriod=100,HouseType="घ",FiscalYearId=5},
            //    new HouseValuation{ Description="स्टील फ्रेम स्तरकचर, फ्रविङत्रास, फाईवर वा यस्तै संग्रचना ",CostPerArea=1800,DepreciationRate=0.75m,DepreciationPeriod=100,HouseType="ङ",FiscalYearId=5}            
            //};

            //houseValuation.ForEach(h => context.HouseValuations.AddOrUpdate(h));
            //context.SaveChanges();

            //var landValuation = new List<LandValuation>
            //{
            //    //new LandValuation{ Description="गोरेटो बाटो भएको प्रति आना",LandType="अ",CostPerAnna=100000,FiscalYearId=4},
            //    //new LandValuation{ Description="कच्ची / ग्राभेल सडक प्रति आना",LandType= "आ",CostPerAnna=300000,FiscalYearId=4},
            //    //new LandValuation{ Description="भित्रि सहायक पिच सडक प्रति आना",LandType= "इ",CostPerAnna=400000,FiscalYearId=4},
            //    //new LandValuation{ Description="मूल पिच सडक प्रति आना",LandType="ई",CostPerAnna=800000,FiscalYearId=4},

            //    new LandValuation{ Description="गोरेटो बाटो भएको प्रति आना",LandType="अ",CostPerAnna=100000,FiscalYearId=5},
            //    new LandValuation{ Description="कच्ची / ग्राभेल सडक प्रति आना",LandType= "आ",CostPerAnna=300000,FiscalYearId=5},
            //    new LandValuation{ Description="भित्रि सहायक पिच सडक प्रति आना",LandType= "इ",CostPerAnna=400000,FiscalYearId=5},
            //    new LandValuation{ Description="मूल पिच सडक प्रति आना",LandType="ई",CostPerAnna=800000,FiscalYearId=5},
                
            //};

            //landValuation.ForEach(l => context.LandValuations.AddOrUpdate(l));
            //context.SaveChanges();

            //var houseLandTaxSlabs = new List<HouseLandTaxSlab>
            //{
            //    new HouseLandTaxSlab{ Sequence=1,LowerLimit=0,UpperLimit=3000000,Range=3000000,TaxAmount=500,TaxPercent=0,FirstSlab=true,StartDate=DateTime.Today,EndDate=DateTime.Today.AddDays(365),FiscalYear="74/75"},
            //    new HouseLandTaxSlab{ Sequence=2,LowerLimit=3000001,UpperLimit=5000000,Range=2000000,TaxAmount=0,TaxPercent=0.08m,FirstSlab=false,StartDate=DateTime.Today,EndDate=DateTime.Today.AddDays(365),FiscalYear="74/75"},
            //    new HouseLandTaxSlab{ Sequence=3,LowerLimit=5000001,UpperLimit=10000000,Range=5000000,TaxAmount=500,TaxPercent=0.15m,FirstSlab=false,StartDate=DateTime.Today,EndDate=DateTime.Today.AddDays(365),FiscalYear="74/75"},
            //    new HouseLandTaxSlab{ Sequence=4,LowerLimit=10000001,UpperLimit=20000000,Range=10000000,TaxAmount=500,TaxPercent=0.25m,FirstSlab=false,StartDate=DateTime.Today,EndDate=DateTime.Today.AddDays(365),FiscalYear="74/75"},
            //    new HouseLandTaxSlab{ Sequence=5,LowerLimit=20000000,UpperLimit=0,Range=0,TaxAmount=500,TaxPercent=0.35m,FirstSlab=false,StartDate=DateTime.Today,EndDate=DateTime.Today.AddDays(365),FiscalYear="74/75"},

            //};

            //houseLandTaxSlabs.ForEach(l => context.HouseLandTaxSlabs.AddOrUpdate(l));
            //context.SaveChanges();

            //var fiscalYears = new List<FiscalYear>
            //{
            //    new FiscalYear{ Id=1, FY="70/71",Sequence = 1},
            //    new FiscalYear{ Id=2, FY="71/72",Sequence = 2 },
            //    new FiscalYear{ Id=3, FY="72/73",Sequence = 3 },
            //    new FiscalYear{ Id=4, FY="73/74",Sequence = 4 },
            //    new FiscalYear{ Id=5, FY="74/75",Sequence = 5 },
            //    new FiscalYear{ Id=6, FY="75/76",Sequence = 6 },
            //    new FiscalYear{ Id=7, FY="76/77",Sequence = 7 }, 
            //    new FiscalYear{ Id=8, FY="77/78",Sequence = 8 },
            //    new FiscalYear{ Id=9, FY="78/79",Sequence = 9 },
            //    new FiscalYear{ Id=10, FY="79/80",Sequence = 10 },


            //};

            //fiscalYears.ForEach(f => context.FiscalYears.AddOrUpdate(f));
            //context.SaveChanges();






        }
    }
}
