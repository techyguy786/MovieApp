namespace MovieApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    DateAdded = c.DateTime(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    NumberInStock = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
