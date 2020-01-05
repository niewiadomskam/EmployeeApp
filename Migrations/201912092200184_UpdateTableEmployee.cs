namespace EmployeeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableEmployee : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeId");
        }
    }
}
