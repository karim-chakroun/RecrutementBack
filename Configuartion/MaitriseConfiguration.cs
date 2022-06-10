using AppRecrutement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppRecrutement.MaitriseConfiguartion
{
    public class MaitriseConfiguration : IEntityTypeConfiguration<NiveauMaitrise>
    {
        public void Configure(EntityTypeBuilder<NiveauMaitrise> builder)
        {
            builder.HasKey(f => new
            {

                f.UserFk,
                f.LangageFk            
            });

            builder.HasOne(f => f.User)
            .WithMany(c => c.NiveauMaitrises)
            .HasForeignKey(f => f.UserFk);

            builder.HasOne(f => f.Language)
           .WithMany(p => p.NiveauMaitrises)
           .HasForeignKey(f => f.LangageFk);
        }
    }
}
