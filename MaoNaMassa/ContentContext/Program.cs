using System;
using ContentContext.Enums;

namespace ContentContext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var course = new Course();
            var career = new Career();
            
            career.Items.Add(new CareerItem());
            Console.WriteLine(career.TotalCourses);
        }
    }
}