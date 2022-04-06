namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appoinments", "Appoinment_date", c => c.DateTime());
            AlterColumn("dbo.facilityappoinments", "Appoinment_date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.facilityappoinments", "Appoinment_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appoinments", "Appoinment_date", c => c.DateTime(nullable: false));
        }
    }
}
