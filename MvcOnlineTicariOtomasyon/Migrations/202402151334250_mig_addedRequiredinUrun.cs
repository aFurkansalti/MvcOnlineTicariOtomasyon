namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addedRequiredinUrun : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Uruns", "UrunAd", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Uruns", "Marka", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uruns", "Marka", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Uruns", "UrunAd", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
