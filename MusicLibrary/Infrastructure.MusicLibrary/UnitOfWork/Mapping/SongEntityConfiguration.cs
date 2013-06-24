using MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Infrastructure.MusicLibrary.UnitOfWork.Mapping
{
    public class SongEntityConfiguration : EntityTypeConfiguration<Song>
    {
        public SongEntityConfiguration() {
            
            this.HasKey(c => c.Id);

            this.Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.Author)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.Album)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.Genre)
                .HasMaxLength(100)
                .IsRequired();
        
        }

    }
}
