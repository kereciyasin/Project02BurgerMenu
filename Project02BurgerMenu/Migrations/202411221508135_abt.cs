namespace Project02BurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "About1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "About1");
        }
    }
}
