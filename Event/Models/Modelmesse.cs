using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Models
{
    class Modelmesse
    {
    }

    public class Here
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<double> location { get; set; }
        public string body { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public string publishedAt { get; set; }
    }

    public class VeryClose
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<double> location { get; set; }
        public string body { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public string publishedAt { get; set; }
    }

    public class AroundYou
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<double> location { get; set; }
        public string body { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public string publishedAt { get; set; }
    }

    public class ThisCity
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<double> location { get; set; }
        public string body { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public string publishedAt { get; set; }
    }


    public class ModelMesseEvent
    {
        public List<Here> here { get; set; }
        public List<VeryClose> veryClose { get; set; }
        public List<AroundYou> aroundYou { get; set; }
        public List<ThisCity> thisCity { get; set; }
    }

}
