
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.Models;

namespace TechBlog.Core.Configs
{
    public class PostTagMapConfig : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.ToTable("PostTagMap");

            builder.HasKey(x => new { x.PostId, x.TagId });

            builder.HasOne(x => x.Post)
                .WithMany(p => p.PostTagMaps)
                .HasForeignKey(ptm => ptm.PostId);

            builder.HasOne(ptm => ptm.Tag)
                .WithMany(t => t.PostTagMaps)
                .HasForeignKey(ptm => ptm.TagId);
        }
    }
}
