namespace Hospital_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hospital_management : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        MobileNumber = c.Long(nullable: false),
                        Gender = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        Dateofbirth = c.DateTime(nullable: false),
                        Qualification = c.String(nullable: false),
                        Speciality = c.String(nullable: false),
                        Experience = c.Double(nullable: false),
                        Day_available = c.String(nullable: false),
                        time_available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.HospitalAdmins",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        MobileNumber = c.Long(nullable: false),
                        Gender = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        Dateofbirth = c.DateTime(nullable: false),
                        Hospital_Name = c.String(nullable: false),
                        Hospital_Address = c.String(nullable: false),
                        Hospital_website = c.String(nullable: false),
                        Hospital_contactNumber = c.Long(nullable: false),
                        Hospital_Faxnumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        MobileNumber = c.Long(nullable: false),
                        Gender = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        Dateofbirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
            DropTable("dbo.HospitalAdmins");
            DropTable("dbo.Doctors");
        }
    }
}
