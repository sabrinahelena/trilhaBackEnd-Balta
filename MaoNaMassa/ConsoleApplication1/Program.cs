using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ContentContext.Enums;
using SubscriptionContext;

namespace ContentContext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var course = new Course();
            // var career = new Career();
            
            // career.Items.Add(new CareerItem());
            // Console.WriteLine(career.TotalCourses);


            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));


            foreach (var a in articles)
            {
                Console.WriteLine($"{a.Id} - {a.Title} - {a.Url}");
            }

            var courses = new List<Course>();

            var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
            var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
            var courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-aspnet");
            
            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            var career = new Career("Especialista .NET", "especialista-dotnet");
            var careerItem3 = new CareerItem(3, "AspNet", "", null);
            var careerItem1 = new CareerItem(1, "Comece por aqui", "", null);
            var careerItem2 = new CareerItem(2, "POO", "", null);

            var careers = new List<Career>();
            career.Items.Add((careerItem3));
            career.Items.Add((careerItem1));
            career.Items.Add((careerItem2));
            careers.Add((career));
            

            foreach (var c in careers)
            {
                Console.WriteLine(career.Title);
                foreach (var i in career.Items.OrderBy(x => x.Order)) //colocar na ordem
                {
                    Console.WriteLine($"{i.Order} - {i.Title}");
                    Console.WriteLine($"{i.Course?.Title} - {i.Course?.Level}");

                    foreach (var notification in i.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }

            var payPal = new PayPalSubscription();
            var payPal2 = new PayPalSubscription();

            var student = new Student();
            student.CreateSubscription(payPal);

            foreach (var x in student.Subscriptions)
            {
                foreach (var b in student.Notifications)
                {
                    Console.WriteLine($"{b.Property} - {b.Message}");
                }
            }


        }
    }
}