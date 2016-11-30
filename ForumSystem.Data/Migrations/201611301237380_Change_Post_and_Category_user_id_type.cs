namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Post_and_Category_user_id_type : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "LastModifiedBy_Id" });
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropColumn("dbo.Categories", "LastModifiedById");
            DropColumn("dbo.Posts", "AuthorId");
            RenameColumn(table: "dbo.Categories", name: "LastModifiedBy_Id", newName: "LastModifiedById");
            RenameColumn(table: "dbo.Posts", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.Categories", "LastModifiedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "LastModifiedById");
            CreateIndex("dbo.Posts", "AuthorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Categories", new[] { "LastModifiedById" });
            AlterColumn("dbo.Posts", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "LastModifiedById", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Posts", name: "AuthorId", newName: "Author_Id");
            RenameColumn(table: "dbo.Categories", name: "LastModifiedById", newName: "LastModifiedBy_Id");
            AddColumn("dbo.Posts", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "LastModifiedById", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Author_Id");
            CreateIndex("dbo.Categories", "LastModifiedBy_Id");
        }
    }
}
