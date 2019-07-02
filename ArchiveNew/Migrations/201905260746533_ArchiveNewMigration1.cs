namespace ArchiveNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArchiveNewMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "ACTIVE", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "ACTIVE");
        }
    }
}
