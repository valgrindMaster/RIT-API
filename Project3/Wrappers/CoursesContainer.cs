using System.Collections.Generic;

namespace Project3.Wrappers
{
    class Courses
    {
        public string degreeName { get; set; }
        public string semester { get; set; }
        public List<string> courses { get; set; }
    }

    class CoursesContainer
    {
        public List<Courses> courses { get; set; }
    }
}
