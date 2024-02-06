namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resmiTatilGunSure : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResmiTatils", "Sure", c => c.Double(nullable: false));
            AlterColumn("dbo.ResmiTatils", "Gun", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResmiTatils", "Gun", c => c.Int(nullable: false));
            AlterColumn("dbo.ResmiTatils", "Sure", c => c.Int(nullable: false));
        }
    }
}
