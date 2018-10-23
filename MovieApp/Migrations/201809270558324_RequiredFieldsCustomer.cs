namespace MovieApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RequiredFieldsCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }
    }
}
