namespace Uni_Practice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseStudentEnroll", "ObtainedNumber", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseStudentEnroll", "ObtainedNumber", c => c.Double(nullable: false));
        }
    }
}
