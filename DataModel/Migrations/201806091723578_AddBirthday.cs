namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "DateOfBirth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "DateOfBirth");
        }
    }
}
