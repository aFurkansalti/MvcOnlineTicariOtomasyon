namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_saatAddedInMesajlar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mesajlars", "Saat", c => c.String(maxLength: 5, fixedLength: true, unicode: false));
            AlterColumn("dbo.Mesajlars", "Tarih", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mesajlars", "Tarih", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            DropColumn("dbo.Mesajlars", "Saat");
        }
    }
}
