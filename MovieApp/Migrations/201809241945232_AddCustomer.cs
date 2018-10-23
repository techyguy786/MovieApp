namespace MovieApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                    Birthdate = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
