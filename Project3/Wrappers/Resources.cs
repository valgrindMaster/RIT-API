using System.Collections.Generic;

namespace Project3.Wrappers
{
    class StudyAbroad
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<Place> places { get; set; }
    }

    class Place
    {
        public string nameOfPlace { get; set; }
        public string description { get; set; }
    }

    class StudentServices
    {
        public string title { get; set; }
        public AcademicAdvisors academicAdvisors { get; set; }
        public ProfessionalAdvisors professionalAdvisors { get; set; }
        public FacultyAdvisors facultyAdvisors { get; set; }
        public IstMinorAdvising istMinorAdvising { get; set; }
    }

    class AcademicAdvisors
    {
        public string title { get; set; }
        public string description { get; set; }
        public Faq faq { get; set; }
    }

    class Faq
    {
        public string title { get; set; }
        public string contentHref { get; set; }
    }

    class ProfessionalAdvisors
    {
        public string title { get; set; }
        public List<AdvisorInformation> advisorInformation { get; set; }
    }

    class AdvisorInformation
    {
        public string name { get; set; }
        public string department { get; set; }
        public string email { get; set; }
    }

    class FacultyAdvisors
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    class IstMinorAdvising
    {
        public string title { get; set; }
        public List<MinorAdvisingInfo> minorAdvisingInfo { get; set; }
    }

    class MinorAdvisingInfo
    {
        public string title { get; set; }
        public string advisor { get; set; }
        public string email { get; set; }
    }

    class TutorsAndLabInfo
    {
        public string title { get; set; }
        public string description { get; set; }
        public string tutoringLabHoursLink { get; set; }
    }

    class StudentAmbassadors
    {
        public string title { get; set; }
        public string ambassadorsImageSource { get; set; }
        public List<SubSectionContent> subSectionContent { get; set; }
        public string applicationFormLink { get; set; }
        public string note { get; set; }
    }

    class SubSectionContent
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    class Forms
    {
        public List<GraduateForms> graduateForms { get; set; }
        public List<UndergraduateForms> undergraduateForms { get; set; }
    }

    class GraduateForms
    {
        public string formName { get; set; }
        public string href { get; set; }
    }

    class UndergraduateForms
    {
        public string formName { get; set; }
        public string href { get; set; }
    }

    class CoopEnrollment
    {
        public string title { get; set; }
        public List<EnrollmentInfoContent> enrollmentInfoContent { get; set; }
        public string ritJobZoneGuidelink { get; set; }
    }

    class EnrollmentInfoContent
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    class Resources
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public StudyAbroad studyAbroad { get; set; }
        public StudentServices studentServices { get; set; }
        public TutorsAndLabInfo tutorsAndLabInfo { get; set; }
        public StudentAmbassadors studentAmbassadors { get; set; }
        public Forms form { get; set; }
        public CoopEnrollment coopEnrollment { get; set; }
    }
}
