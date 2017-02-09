namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.Movies ( Name , Genre , ReleaseDate, DateAdded, NumberInStock ) VALUES  ('Hangover' ,'Comedy', '20091106', '20170209', 5)");
            Sql("INSERT INTO dbo.Movies ( Name , Genre , ReleaseDate, DateAdded, NumberInStock ) VALUES  ('Die Hard' ,'Action', '19900126', '20170209', 3)");
            Sql("INSERT INTO dbo.Movies ( Name , Genre , ReleaseDate, DateAdded, NumberInStock ) VALUES  ('The Terminator' ,' Action', '19880101', '20170209', 2)");
            Sql("INSERT INTO dbo.Movies ( Name , Genre , ReleaseDate, DateAdded, NumberInStock ) VALUES  ('Toy Story' ,'Family', '19960419', '20170209', 7)");
            Sql("INSERT INTO dbo.Movies ( Name , Genre , ReleaseDate, DateAdded, NumberInStock ) VALUES  ('Titanic' ,'Romance', '19980220', '20170209', 9)");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
