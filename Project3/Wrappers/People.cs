using System.Collections.Generic;

namespace Project3.Wrappers
{
    public abstract class Person
    {
        public abstract string getUsername();
        public abstract string getName();
        public abstract string getTagline();
        public abstract string getImagePath();
        public abstract string getTitle();
        public abstract string getInterestArea();
        public abstract string getOffice();
        public abstract string getWebsite();
        public abstract string getPhone();
        public abstract string getEmail();
        public abstract string getTwitter();
        public abstract string getFacebook();
    }
    public class Faculty : Person
    {
        public string username { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string imagePath { get; set; }
        public string title { get; set; }
        public string interestArea { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }

        public override string getUsername()
        {
            return username;
        }
        public override string getName()
        {
            return name;
        }
        public override string getTagline()
        {
            return tagline;
        }
        public override string getImagePath()
        {
            return imagePath;
        }
        public override string getTitle()
        {
            return title;
        }
        public override string getInterestArea()
        {
            return interestArea;
        }
        public override string getOffice()
        {
            return office;

        }
        public override string getWebsite()
        {
            return website;

        }
        public override string getPhone()
        {
            return phone;

        }
        public override string getEmail()
        {
            return email;

        }
        public override string getTwitter()
        {
            return twitter;

        }
        public override string getFacebook()
        {
            return facebook;

        }
    }

    public class Staff : Person
    {
        public string username { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string imagePath { get; set; }
        public string title { get; set; }
        public string interestArea { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }

        public override string getUsername()
        {
            return username;
        }
        public override string getName()
        {
            return name;
        }
        public override string getTagline()
        {
            return tagline;
        }
        public override string getImagePath()
        {
            return imagePath;
        }
        public override string getTitle()
        {
            return title;
        }
        public override string getInterestArea()
        {
            return interestArea;
        }
        public override string getOffice()
        {
            return office;

        }
        public override string getWebsite()
        {
            return website;

        }
        public override string getPhone()
        {
            return phone;

        }
        public override string getEmail()
        {
            return email;

        }
        public override string getTwitter()
        {
            return twitter;

        }
        public override string getFacebook()
        {
            return facebook;

        }
    }

    public class People
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public List<Faculty> faculty { get; set; }
        public List<Staff> staff { get; set; }
    }
}
