namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resmiTatil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResmiTatils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GunIsim = c.String(maxLength: 8000, unicode: false),
                        Sure = c.Int(nullable: false),
                        Gun = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResmiTatils");
        }
    }
}
