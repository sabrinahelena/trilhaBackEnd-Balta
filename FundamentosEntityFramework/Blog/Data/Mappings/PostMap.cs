using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()"); //Valor default do sql server


            builder.HasIndex(x => x.Slug, "IX_Post_Slug").IsUnique();

            //Relacionamentos

            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Posts)
                   .HasConstraintName("FK_Post_Author");
            //.OnDelete(DeleteBehavior.Cascade); //apaga todos autores relacionados ao post apagado

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category");

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>("PostTag", post => post.HasOne<Tag>()
                .WithMany()
                .HasForeignKey("PostId")
                .HasConstraintName("FK_PostTag_PostId"),
                 tag => tag.HasOne<Post>()
                .WithMany()
                .HasForeignKey("TagId")
                .HasConstraintName("FK_PostTag_TagId"));



        }
    }
}
