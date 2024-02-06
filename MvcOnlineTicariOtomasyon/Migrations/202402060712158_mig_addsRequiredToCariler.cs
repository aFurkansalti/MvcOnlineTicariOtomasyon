namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addsRequiredToCariler : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carilers", "CariSehir", c => c.String(nullable: false, maxLength: 13, unicode: false));
            AlterColumn("dbo.Carilers", "CariMail", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Carilers", "CariSifre", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carilers", "CariSifre", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Carilers", "CariMail", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Carilers", "CariSehir", c => c.String(maxLength: 13, unicode: false));
        }
    }
}
