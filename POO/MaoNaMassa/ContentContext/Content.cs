using System;

namespace ContentContext
{
    public abstract class Content : Base //pra não ser instanciada
    {//Colocamos tudo que teramos em comum, para herdar.
        public Content(string title, string url)
        {
            Title = title;
            Url = url;
        }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}