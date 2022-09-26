using System.Collections.Generic;

namespace ContentContext
{
    public class Module : Base
    {
        public Module()
        {
            Lectures = new List<Lecture>();
        }
        public int Order { get; set; }
        public string Title { get; set; }
        
        public IList<Lecture> Lectures { get; set; } //um curso com uma lista de módulos

        
    }
}