namespace Uni_Practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseStudentEnroll", "EnrollDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseStudentEnroll", "EnrollDate", c => c.DateTime(nullable: false));
        }
    }
}
