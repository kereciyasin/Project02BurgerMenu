namespace Project02BurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class about : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutTitle = c.String(),
                        Title = c.String(),
                        AboutDescription = c.String(),
                        ImgUrl = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        MapLocation = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abouts");
        }
    }
}
