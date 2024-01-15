namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_added_satis : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SatisHarekets", "Cariler_CariId", "dbo.Carilers");
            DropForeignKey("dbo.SatisHarekets", "Personel_PersonelId", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "Urun_UrunId", "dbo.Uruns");
            DropIndex("dbo.SatisHarekets", new[] { "Cariler_CariId" });
            DropIndex("dbo.SatisHarekets", new[] { "Personel_PersonelId" });
            DropIndex("dbo.SatisHarekets", new[] { "Urun_UrunId" });
            RenameColumn(table: "dbo.SatisHarekets", name: "Cariler_CariId", newName: "CariId");
            RenameColumn(table: "dbo.SatisHarekets", name: "Personel_PersonelId", newName: "PersonelId");
            RenameColumn(table: "dbo.SatisHarekets", name: "Urun_UrunId", newName: "UrunId");
            AlterColumn("dbo.SatisHarekets", "CariId", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarekets", "PersonelId", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarekets", "UrunId", c => c.Int(nullable: false));
            CreateIndex("dbo.SatisHarekets", "UrunId");
            CreateIndex("dbo.SatisHarekets", "CariId");
            CreateIndex("dbo.SatisHarekets", "PersonelId");
            AddForeignKey("dbo.SatisHarekets", "CariId", "dbo.Carilers", "CariId", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarekets", "PersonelId", "dbo.Personels", "PersonelId", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarekets", "UrunId", "dbo.Uruns", "UrunId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SatisHarekets", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.SatisHarekets", "PersonelId", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "CariId", "dbo.Carilers");
            DropIndex("dbo.SatisHarekets", new[] { "PersonelId" });
            DropIndex("dbo.SatisHarekets", new[] { "CariId" });
            DropIndex("dbo.SatisHarekets", new[] { "UrunId" });
            AlterColumn("dbo.SatisHarekets", "UrunId", c => c.Int());
            AlterColumn("dbo.SatisHarekets", "PersonelId", c => c.Int());
            AlterColumn("dbo.SatisHarekets", "CariId", c => c.Int());
            RenameColumn(table: "dbo.SatisHarekets", name: "UrunId", newName: "Urun_UrunId");
            RenameColumn(table: "dbo.SatisHarekets", name: "PersonelId", newName: "Personel_PersonelId");
            RenameColumn(table: "dbo.SatisHarekets", name: "CariId", newName: "Cariler_CariId");
            CreateIndex("dbo.SatisHarekets", "Urun_UrunId");
            CreateIndex("dbo.SatisHarekets", "Personel_PersonelId");
            CreateIndex("dbo.SatisHarekets", "Cariler_CariId");
            AddForeignKey("dbo.SatisHarekets", "Urun_UrunId", "dbo.Uruns", "UrunId");
            AddForeignKey("dbo.SatisHarekets", "Personel_PersonelId", "dbo.Personels", "PersonelId");
            AddForeignKey("dbo.SatisHarekets", "Cariler_CariId", "dbo.Carilers", "CariId");
        }
    }
}
