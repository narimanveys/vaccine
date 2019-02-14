namespace PattientVaccinationApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        SNILS = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vaccinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vaccine = c.Int(nullable: false),
                        IsVaccinationAllowed = c.Boolean(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccinations", "PatientId", "dbo.Patients");
            DropIndex("dbo.Vaccinations", new[] { "PatientId" });
            DropTable("dbo.Vaccinations");
            DropTable("dbo.Patients");
        }
    }
}
