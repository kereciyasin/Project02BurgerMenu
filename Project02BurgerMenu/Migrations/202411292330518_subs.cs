namespace Project02BurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        SubscribeId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SubscribeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribes");
        }
    }
}
