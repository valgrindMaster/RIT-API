using System.Collections.Generic;

namespace Project3.Wrappers
{
    public class UgMinors
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> courses { get; set; }
        public string note { get; set; }
    }

    class Minors
    {
        public List<UgMinors> ugMinors { get; set; }
    }
}
