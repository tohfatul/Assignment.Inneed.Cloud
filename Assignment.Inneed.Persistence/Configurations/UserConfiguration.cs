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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();
            builder.HasData(
                new User
                {
                    Id = 1,
                    FullName = "Admin User",
                    Email="admin@admin.com",
                    RoleId = 1,
                    PasswordHash= hmac.ComputeHash(Encoding.UTF8.GetBytes("123456")),
                    PasswordSalt= hmac.Key,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    FullName = "Standard User",
                    Email = "standard@standard.com",
                    RoleId = 2,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456")),
                    PasswordSalt = hmac.Key,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );

            builder.Property(q => q.FullName)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
