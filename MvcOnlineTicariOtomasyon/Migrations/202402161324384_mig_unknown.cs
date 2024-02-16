namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_unknown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departmen", "DepartmanAd", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departmen", "DepartmanAd", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
