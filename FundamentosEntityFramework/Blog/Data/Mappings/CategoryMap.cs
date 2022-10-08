using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //Chave primária
        builder.HasKey(x => x.Id);
        
        
        //Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd() //toda vez que eu adicionar um novo item vais er gerado
            .UseIdentityColumn();
        
        //Propriedades

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(80);
        builder.Property(x => x.Slug)
            .IsRequired()
            .HasMaxLength(80);

        //Índices

        builder.HasIndex(x => x.Slug, "IX_Category_Slug").IsUnique();

    }
}