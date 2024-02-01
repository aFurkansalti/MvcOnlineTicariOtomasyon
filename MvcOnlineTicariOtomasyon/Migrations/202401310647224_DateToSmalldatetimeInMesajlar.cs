namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateToSmalldatetimeInMesajlar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mesajlars", "Tarih", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mesajlars", "Tarih", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
