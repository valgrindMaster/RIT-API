using System.Collections.Generic;

namespace Project3.Wrappers
{
    class Year
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    class Older
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    class News
    {
        public List<Year> years { get; set; }
        public List<Older> olders { get; set; }
    }
}
