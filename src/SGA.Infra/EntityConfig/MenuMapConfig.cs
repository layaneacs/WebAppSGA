using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Infra.EntityConfig
{
    public class MenuMapConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder
                .HasMany(m => m.SubMenu) // tem muitos submenus
                .WithOne()// e o sub menu tem apenas um Menu
                .HasForeignKey(m => m.MenuId);
        }
    }
}
