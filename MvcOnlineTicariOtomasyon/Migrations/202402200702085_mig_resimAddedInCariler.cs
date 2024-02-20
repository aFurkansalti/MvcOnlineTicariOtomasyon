namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_resimAddedInCariler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carilers", "MusteriResmi", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carilers", "MusteriResmi");
        }
    }
}
