namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_changeToKargo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KargoTakips", "TakipKodu", c => c.String(nullable: false, maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KargoTakips", "TakipKodu", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
