namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirtdateToCustomer : DbMigration
    {
        public override void Up()
        {
//            Sql("UPDATE dbo.Customers SET Birtdate='19800101' WHERE Id=1 ");
            //Sql("UPDATE dbo.Customers SET Birtdate='19800101' WHERE Id=2 ");
        }
        
        public override void Down()
        {
        }
    }
}
