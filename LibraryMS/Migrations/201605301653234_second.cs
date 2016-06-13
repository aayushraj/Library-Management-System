namespace LibraryMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookInfoes", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookInfoes", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
