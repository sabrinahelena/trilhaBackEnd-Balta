// See https://aka.ms/new-console-template for more information
using System;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {

            //INSERT
            var context = new BlogDataContext();
            
                var tag = new Tag { Id = 1, Name = "ASP.NET", Slug = "aspnet" };
                context.Tags.Add(tag);
                context.SaveChanges();
            
            Console.WriteLine(tag.Name);

            //UPDATE
            
            var tagAtt = context.Tags.FirstOrDefault(x => x.Id == 1);
            tagAtt.Name = "DOTNET";
            tagAtt.Slug = "dotnet";
            context.Tags.Update(tagAtt);
            context.SaveChanges();
            Console.WriteLine(tagAtt.Name);
            
            
            // //DELETE
            
            var tagDelete = context.Tags.FirstOrDefault(x => x.Id == 1);
            context.Tags.Remove(tagDelete);
            context.SaveChanges();
            
            
            //TO LIST

            var tag2 = new Tag()
            {
                Id = 2,
                Name = "APIREST",
                Slug = "apirest"
            };
            context.Tags.Add(tag2);
            context.SaveChanges();
            var tags = context.Tags.Where(x => x.Name.Contains("DOTNET")).ToList();
            
            foreach(var t in tags)
            {
                Console.WriteLine($"{t.Id} -- {t.Name}");
            }
            
            var tags2 = context.Tags.AsNoTracking().ToList(); //ajuda na performance. AsNoTracking desabilita o traking na consulta do BD
            foreach(var t in tags2)
            {
                Console.WriteLine($"{t.Id} -- {t.Name}");
            }

            //GET BY ID

            var findTag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 1); //firstordefault permite retonar nulo caso nao exista.
            // var findTag = context.Tags.AsNoTracking().SingleOrDefault(x => x.Id == 1); //firstordefault permite retonar nulo caso nao exista.

            //Se tiver mais de um item com o mesmo id, e usar o firstordefault, ele vai retornar o primeiro que achar. Já o single, ele dá erro se tiver mais de um item com mesmo id.
            Console.WriteLine(findTag?.Name);


        }
    }
}