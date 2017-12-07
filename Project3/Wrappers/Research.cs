using System.Collections.Generic;

namespace Project3.Wrappers
{
    class ByInterestArea
    {
        public string areaName { get; set; }
        public List<string> citations { get; set; }
    }

    class ByFaculty
    {
        public string facultyName { get; set; }
        public string username { get; set; }
        public List<string> citations { get; set; }
    }

    class Research
    {
        public List<ByInterestArea> byInterestArea { get; set; }
        public List<ByFaculty> byFaculty { get; set; }
    }
}
