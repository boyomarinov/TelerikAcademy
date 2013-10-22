namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Username_Index : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Users", "Username", true, "IX_UQ_Users_Username");
        }
        
        public override void Down()
        {
            DropIndex("Users", "IX_UQ_Users_Username");
        }
    }
}
