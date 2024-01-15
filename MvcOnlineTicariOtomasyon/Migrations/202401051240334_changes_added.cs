namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personels", "Departman_DepartmanId", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "Departman_DepartmanId" });
            RenameColumn(table: "dbo.Personels", name: "Departman_DepartmanId", newName: "DepartmanId");
            AlterColumn("dbo.Personels", "DepartmanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personels", "DepartmanId");
            AddForeignKey("dbo.Personels", "DepartmanId", "dbo.Departmen", "DepartmanId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personels", "DepartmanId", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "DepartmanId" });
            AlterColumn("dbo.Personels", "DepartmanId", c => c.Int());
            RenameColumn(table: "dbo.Personels", name: "DepartmanId", newName: "Departman_DepartmanId");
            CreateIndex("dbo.Personels", "Departman_DepartmanId");
            AddForeignKey("dbo.Personels", "Departman_DepartmanId", "dbo.Departmen", "DepartmanId");
        }
    }
}
