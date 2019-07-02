namespace ArchiveNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArchiveNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        User_ID = c.Int(nullable: false, identity: true),
                        Role_ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Family = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
