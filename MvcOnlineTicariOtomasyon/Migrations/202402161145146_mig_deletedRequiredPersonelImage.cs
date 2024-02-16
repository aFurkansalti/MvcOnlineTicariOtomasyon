namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_deletedRequiredPersonelImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personels", "PersonelGorsel", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personels", "PersonelGorsel", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
    }
}
