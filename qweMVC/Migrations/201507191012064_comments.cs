namespace qweMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Text = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Text);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
