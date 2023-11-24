using Assignment.Inneed.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = 1,
                    RoleName = "Administrator",             
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Standard",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );

            builder.Property(q => q.RoleName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
