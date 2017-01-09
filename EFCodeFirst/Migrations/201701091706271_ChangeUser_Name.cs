namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUser_Name : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Name", newName: "Personal_Name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Users", name: "Personal_Name", newName: "Name");
        }
    }
}
