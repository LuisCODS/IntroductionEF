namespace IntroductionEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cours",
                c => new
                    {
                        PKCoursID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 20),
                        FKProfID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PKCoursID)
                .ForeignKey("dbo.Profs", t => t.FKProfID, cascadeDelete: true)
                .Index(t => t.FKProfID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cours", "FKProfID", "dbo.Profs");
            DropIndex("dbo.Cours", new[] { "FKProfID" });
            DropTable("dbo.Cours");
        }
    }
}
