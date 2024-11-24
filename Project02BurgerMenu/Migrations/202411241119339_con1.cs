namespace Project02BurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class con1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "About1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "About1", c => c.String());
        }
    }
}
