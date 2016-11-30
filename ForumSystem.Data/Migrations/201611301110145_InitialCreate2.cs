namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        LastModifiedById = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModifiedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LastModifiedBy_Id)
                .Index(t => t.LastModifiedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "LastModifiedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "LastModifiedBy_Id" });
            DropTable("dbo.Categories");
        }
    }
}
