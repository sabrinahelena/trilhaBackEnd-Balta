using System.Collections.Generic;
using ContentContext.Enums;

namespace ContentContext
{
    public class Course : Content
    {
        public Course(string title, string url) : base(title, url)
        {
            Modules = new List<Module>(); //sempre inicializar as listas
        }
        public string Tag { get; set; } //tag do curso
        public IList<Module> Modules { get; set; } //um curso com uma lista de módulos
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }

    }
}