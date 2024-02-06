namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStringLengthToResmiTatil : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResmiTatils", "GunIsim", c => c.String(maxLength: 25, unicode: false));
            AlterColumn("dbo.ResmiTatils", "Gun", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResmiTatils", "Gun", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.ResmiTatils", "GunIsim", c => c.String(maxLength: 8000, unicode: false));
        }
    }
}
