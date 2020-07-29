namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "AcquisitionDate", c => c.String());
            AlterColumn("dbo.Devices", "Memo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "Memo", c => c.Int(nullable: false));
            AlterColumn("dbo.Devices", "AcquisitionDate", c => c.DateTime(nullable: false));
        }
    }
}
