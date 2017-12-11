using System.Collections.Generic;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project3
{
    public sealed partial class Resources : Page
    {
        private const string API_RESOURCES = "http://ist.rit.edu/api/resources/";
        static HttpClient client = new HttpClient();
        Wrappers.Resources resources;
        Wrappers.StudyAbroad studyAbroad;
        Wrappers.StudentServices studentServices;
        Wrappers.TutorsAndLabInformation tutorsAndLabInfo;
        Wrappers.StudentAmbassadors studentAmbassadors;

        public Resources()
        {
            DataContext = this;
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            populateRecoursesAsync(sender);
        }

        private async void populateRecoursesAsync(object sender)
        {
            HttpResponseMessage response = await client.GetAsync(API_RESOURCES);
            if (response.IsSuccessStatusCode)
            {
                resources = await response.Content.ReadAsAsync<Wrappers.Resources>();
                studyAbroad = resources.studyAbroad;
                studentServices = resources.studentServices;
                tutorsAndLabInfo = resources.tutorsAndLabInformation;
                studentAmbassadors = resources.studentAmbassadors;

                MainHeader.Text = resources.title;
                StudyAbroadTitle.Text = studyAbroad.title;
                StudentServicesTitle.Text = studentServices.title;
                TutorsAndLabInfoTitle.Text = tutorsAndLabInfo.title;
                StudentAmbassadorsTitle.Text = studentAmbassadors.title;

                populateStudyAbroadSection(studyAbroad);
                populateStudentServicesSection(studentServices);
                populateTutorsAndLabInfo(tutorsAndLabInfo);
            }
        }

        private void populateStudyAbroadSection(Wrappers.StudyAbroad sa)
        {
            StudyAbroadTitle.Text = sa.title;
            StudyAbroadDescription.Text = sa.description;

            int count = 0;
            TextBlock tb1;
            TextBlock tb2;
            RowDefinition rd;
            Grid gr = new Grid();
            ColumnDefinition cd1 = new ColumnDefinition();
            ColumnDefinition cd2 = new ColumnDefinition();
            cd1.Width = new GridLength(1, GridUnitType.Star);
            cd2.Width = new GridLength(1, GridUnitType.Star);
            gr.ColumnDefinitions.Add(cd1);
            gr.ColumnDefinitions.Add(cd2);
            Thickness thickness = new Thickness(5);
            foreach (Wrappers.Place place in sa.places)
            {
                rd = new RowDefinition();
                rd.Height = new GridLength(1, GridUnitType.Star);
                gr.RowDefinitions.Add(rd);

                tb1 = new TextBlock();
                tb2 = new TextBlock();

                tb1.Text = place.nameOfPlace;
                tb2.Text = place.description;
                tb1.Padding = thickness;
                tb2.Padding = thickness;

                tb1.TextWrapping = TextWrapping.WrapWholeWords;
                tb2.TextWrapping = TextWrapping.WrapWholeWords;

                Grid.SetColumn(tb1, 0);
                Grid.SetColumn(tb2, 1);
                Grid.SetRow(tb1, count);
                Grid.SetRow(tb2, count++);

                gr.Children.Add(tb1);
                gr.Children.Add(tb2);

                StudyAbroadScrollViewer.Content = gr;
            }
        }

        private void populateStudentServicesSection(Wrappers.StudentServices ss)
        {
            StudentServicesTitle.Text = ss.title;
            Wrappers.AcademicAdvisors academicAdvisors = ss.academicAdvisors;
            Wrappers.ProfessonalAdvisors professonalAdvisors = ss.professonalAdvisors;
            Wrappers.FacultyAdvisors facultyAdvisors = ss.facultyAdvisors;
            Wrappers.IstMinorAdvising istMinorAdvising = ss.istMinorAdvising;

            popAcademicAdvisors(academicAdvisors);
            popProfessionalAdvisors(professonalAdvisors);
            popFacultyAdvisors(facultyAdvisors);
            popIstMinorAdvising(istMinorAdvising);
        }

        private void populateTutorsAndLabInfo(Wrappers.TutorsAndLabInformation info)
        {
            StudentAmbassadorsTitle.Text = info.title;
            StudentAmbassadorsDescription.Text = info.description;
            SATHrefLink.Content = "Lab Hours";
            SATHrefLink.NavigateUri = new System.Uri(info.tutoringLabHoursLink);
        }

        private void popAcademicAdvisors(Wrappers.AcademicAdvisors advisors)
        {
            AASubtitle.Text = advisors.title;
            AADescription.Text = advisors.description;
            AAFaqSubtitle.Text = "FAQ";
            AAFaqContentHrefLink.Content = advisors.faq.title;
            AAFaqContentHrefLink.NavigateUri = new System.Uri(advisors.faq.contentHref);
        }

        private void popProfessionalAdvisors(Wrappers.ProfessonalAdvisors advisors)
        {
            TutorsAndLabInfoTitle.Text = advisors.title;

            int count = 0;
            TextBlock tb1;
            TextBlock tb2;
            HyperlinkButton hl3;
            RowDefinition rd;
            Grid gr = new Grid();
            ColumnDefinition cd1 = new ColumnDefinition();
            ColumnDefinition cd2 = new ColumnDefinition();
            ColumnDefinition cd3 = new ColumnDefinition();
            cd1.Width = new GridLength(1, GridUnitType.Star);
            cd2.Width = new GridLength(1, GridUnitType.Star);
            cd3.Width = new GridLength(1, GridUnitType.Star);
            gr.ColumnDefinitions.Add(cd1);
            gr.ColumnDefinitions.Add(cd2);
            gr.ColumnDefinitions.Add(cd3);
            Thickness thickness = new Thickness(5);

            foreach (Wrappers.AdvisorInformation info in advisors.advisorInformation)
            {
                rd = new RowDefinition();
                rd.Height = new GridLength(1, GridUnitType.Star);
                gr.RowDefinitions.Add(rd);

                tb1 = new TextBlock();
                tb2 = new TextBlock();
                hl3 = new HyperlinkButton();

                tb1.Text = info.name;
                tb2.Text = info.department;
                hl3.Content = "Contact";
                hl3.NavigateUri = new System.Uri("mailto:" + info.email);
                tb1.Padding = thickness;
                tb2.Padding = thickness;
                hl3.Padding = thickness;

                tb1.TextWrapping = TextWrapping.WrapWholeWords;
                tb2.TextWrapping = TextWrapping.WrapWholeWords;

                Grid.SetColumn(tb1, 0);
                Grid.SetColumn(tb2, 1);
                Grid.SetColumn(hl3, 2);
                Grid.SetRow(tb1, count);
                Grid.SetRow(tb2, count);
                Grid.SetRow(hl3, count++);

                gr.Children.Add(tb1);
                gr.Children.Add(tb2);
                gr.Children.Add(hl3);

                TALIScrollViewer.Content = gr;
            }
        }

        private void popFacultyAdvisors(Wrappers.FacultyAdvisors advisors)
        {
            FacultyAdvisorsSubtitle.Text = advisors.title;
            FacultyAdvisorsDescription.Text = advisors.description;
        }

        private void popIstMinorAdvising(Wrappers.IstMinorAdvising advisors)
        {
            IstMinorAdvisingSubtitle.Text = advisors.title;

            int count = 0;
            TextBlock tb1;
            TextBlock tb2;
            HyperlinkButton hl3;
            RowDefinition rd;
            Grid gr = new Grid();
            ColumnDefinition cd1 = new ColumnDefinition();
            ColumnDefinition cd2 = new ColumnDefinition();
            ColumnDefinition cd3 = new ColumnDefinition();
            cd1.Width = new GridLength(1, GridUnitType.Star);
            cd2.Width = new GridLength(1, GridUnitType.Star);
            cd3.Width = new GridLength(1, GridUnitType.Star);
            gr.ColumnDefinitions.Add(cd1);
            gr.ColumnDefinitions.Add(cd2);
            gr.ColumnDefinitions.Add(cd3);
            Thickness thickness = new Thickness(5);

            foreach (Wrappers.MinorAdvisorInformation info in advisors.minorAdvisorInformation)
            {
                rd = new RowDefinition();
                rd.Height = new GridLength(1, GridUnitType.Star);
                gr.RowDefinitions.Add(rd);

                tb1 = new TextBlock();
                tb2 = new TextBlock();
                hl3 = new HyperlinkButton();

                tb1.Text = info.title;
                tb2.Text = info.advisor;
                hl3.Content = "Contact";
                hl3.NavigateUri = new System.Uri("mailto:" + info.email);
                tb1.Padding = thickness;
                tb2.Padding = thickness;
                hl3.Padding = thickness;

                tb1.TextWrapping = TextWrapping.WrapWholeWords;
                tb2.TextWrapping = TextWrapping.WrapWholeWords;

                Grid.SetColumn(tb1, 0);
                Grid.SetColumn(tb2, 1);
                Grid.SetColumn(hl3, 2);
                Grid.SetRow(tb1, count);
                Grid.SetRow(tb2, count);
                Grid.SetRow(hl3, count++);

                gr.Children.Add(tb1);
                gr.Children.Add(tb2);
                gr.Children.Add(hl3);

                ISTMAScrollViewer.Content = gr;
            }
        }
    }
}
