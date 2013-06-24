using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Infrastructure.MusicLibrary.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Song",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Title = c.String(nullable: false, maxLength: 100),
                    Album = c.String(nullable: false, maxLength: 100),
                    Author = c.String(nullable: false, maxLength: 100),
                    Genre = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
        }

        public override void Down()
        {
            DropIndex("Song", new[] { "Id" });
            DropTable("Song");
           
        }
    }
}
