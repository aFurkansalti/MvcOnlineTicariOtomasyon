namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_SatisFiyat_Uruns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uruns", "SatisFiyat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uruns", "SatisFiyat");
        }
    }
}
