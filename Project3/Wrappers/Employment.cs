using System.Collections.Generic;

namespace Project3.Wrappers
{
    class Introduction
    {
        public string title { get; set; }
        public List<Content> content { get; set; }
    }

    class Content
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    class DegreeStatistics
    {
        public string title { get; set; }
        public List<Statistic> statistics { get; set; }
    }

    class Statistic
    {
        public string value { get; set; }
        public string description { get; set; }
    }

    class Employers
    {
        public string title { get; set; }
        public List<string> employerNames { get; set; }
    }

    class Careers
    {
        public string title { get; set; }
        public List<string> careerNames { get; set; }
    }

    class CoopTable
    {
        public string title { get; set; }
        public List<CoopInformation> coopInformation { get; set; }
    }

    class CoopInformation
    {
        public string employer { get; set; }
        public string degree { get; set; }
        public string city { get; set; }
        public string term { get; set; }
    }

    class EmploymentTable
    {
        public string title { get; set; }
        public List<ProEmploymentInfo> proEmploymentInfo { get; set; }
    }

    class ProEmploymentInfo
    {
        public string employer { get; set; }
        public string degree { get; set; }
        public string city { get; set; }
        public string title { get; set; }
        public string startDate { get; set; }
    }

    class Employment
    {
        public Introduction introduction { get; set; }
        public DegreeStatistics degreeStatistics { get; set; }
        public Employers employers { get; set; }
        public Careers careers { get; set; }
        public CoopTable coopTable { get; set; }
        public EmploymentTable employmentTable { get; set; }
    }
}
