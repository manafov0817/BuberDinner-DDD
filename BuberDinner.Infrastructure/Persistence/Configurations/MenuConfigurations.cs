using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenus(builder);
            ConfigureMenuSectionsTable(builder);
        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.HasKey("Id", "MenuId");
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.Property(s => s.Id)
                  .HasColumnName("MenuSectionId")
                  .ValueGeneratedNever()
                  .HasConversion(id => id.Value,
                                 value => MenuSectionId.Create(value));
                sb.Property(m => m.Name).HasMaxLength(100);
                sb.Property(m => m.Description).HasMaxLength(100);
            });
        }

        private void ConfigureMenus(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("Menus");
            builder.Property(m => m.Id)
                   .ValueGeneratedNever()
                   .HasConversion(id => id.Value,
                                  value => MenuId.Create(value));

            builder.Property(m => m.Name).HasMaxLength(100);
            builder.Property(m => m.Description).HasMaxLength(100);
            builder.OwnsOne(m => m.AverageRating);
            builder.Property(m => m.HostId)
                   .HasConversion(id => id.Value,
                                  value => HostId.Create(value));
        }
    }
}
