using MusicManager.Infrastructure.MusicLibrary.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Infrastructure.MusicLibrary.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MainMLUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MainMLUnitOfWork context)
        {
            

        }
    }
}
