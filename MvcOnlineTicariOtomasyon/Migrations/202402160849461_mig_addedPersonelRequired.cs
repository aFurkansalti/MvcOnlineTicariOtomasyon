namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addedPersonelRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personels", "PersonelAd", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Personels", "PersonelSoyad", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Personels", "PersonelGorsel", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personels", "PersonelGorsel", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Personels", "PersonelSoyad", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Personels", "PersonelAd", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
