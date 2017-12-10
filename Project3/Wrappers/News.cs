using System.Collections.Generic;

namespace Project3.Wrappers
{
    class Older
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    class News
    {
        public List<Older> older { get; set; }
    }
}
