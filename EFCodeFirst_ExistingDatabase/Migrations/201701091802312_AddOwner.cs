namespace EFCodeFirst_ExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Owner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Owner");
        }
    }
}
