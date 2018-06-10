namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthday1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ninjas", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ninjas", "DateOfBirth", c => c.Int(nullable: false));
        }
    }
}
