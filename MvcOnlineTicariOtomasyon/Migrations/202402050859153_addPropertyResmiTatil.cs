namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropertyResmiTatil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResmiTatils", "Durum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResmiTatils", "Durum");
        }
    }
}
