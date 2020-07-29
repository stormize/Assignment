namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Properties", "Device_Id", "dbo.Devices");
            DropIndex("dbo.Properties", new[] { "Device_Id" });
            DropColumn("dbo.Properties", "Device_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Device_Id", c => c.Guid());
            CreateIndex("dbo.Properties", "Device_Id");
            AddForeignKey("dbo.Properties", "Device_Id", "dbo.Devices", "Id");
        }
    }
}
