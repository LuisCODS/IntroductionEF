namespace IntroductionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomRequis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profs",
                c => new
                    {
                        PKProfID = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.PKProfID)
                .Index(t => t.nom, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Profs", new[] { "nom" });
            DropTable("dbo.Profs");
        }
    }
}
