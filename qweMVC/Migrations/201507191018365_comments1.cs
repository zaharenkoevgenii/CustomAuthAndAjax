namespace qweMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Comments", "Id");
            AddPrimaryKey("dbo.Comments", "Text");
        }
    }
}
