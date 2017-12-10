using System.Collections.Generic;

namespace Project3.Wrappers
{
    public abstract class Program
    {
        public abstract string getDegreeName();
        public abstract string getTitle();
        public abstract string getDescription();
        public abstract List<string> getConcentations();
        public abstract string getProgramType();
        public abstract List<string> getAvailableCertificates();
    }

    public class Undergraduate : Program
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }

        public override string getDegreeName()
        {
            return degreeName;
        }

        public override string getTitle()
        {
            return title;
        }

        public override string getDescription()
        {
            return description;
        }

        public override List<string> getConcentations()
        {
            return concentrations;
        }

        public override List<string> getAvailableCertificates()
        {
            return null;
        }

        public override string getProgramType()
        {
            return "Undergrad";
        }
    }

    public class Graduate : Program
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
        public List<string> availableCertificates { get; set; }

        public override string getDegreeName()
        {
            return degreeName;
        }

        public override string getTitle()
        {
            return title;
        }

        public override string getDescription()
        {
            return description;
        }

        public override List<string> getConcentations()
        {
            return concentrations;
        }

        public override List<string> getAvailableCertificates()
        {
            return availableCertificates;
        }

        public override string getProgramType()
        {
            return "Grad";
        }
    }

    class Degrees
    {
        public List<Undergraduate> undergraduate { get; set; }
        public List<Graduate> graduate { get; set; }
    }
}
