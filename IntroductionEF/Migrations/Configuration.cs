namespace IntroductionEF.Migrations
{
    using IntroductionEF.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IntroductionEF.Models.Cegep>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Introduction.Models.Cegep";
        }


        //INITIALISE DES DONNES DANS LA BD
        protected override void Seed(IntroductionEF.Models.Cegep context)
        {           
            context.Profs.AddOrUpdate(new Prof { nom = "Luis Santos" });
            context.Profs.AddOrUpdate(new Prof { nom = "Michel" });
            context.Profs.AddOrUpdate(new Prof { nom = "Luis " });
            context.Profs.AddOrUpdate(new Prof { nom = "Ben" });
        }
    }
}
