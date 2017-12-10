using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Project3.Views
{
    public sealed partial class MinorsDetail : Page
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public MinorsDetail()
        {
            DataContext = this;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Wrappers.UgMinors param = (Wrappers.UgMinors)e.Parameter;
            Title = param.name + " - " + param.title;
            Description = param.description;
            Note = param.note;

            TextBlock headerBlock = new TextBlock();
            headerBlock.Text = "Courses:";
            FontWeight fw = new FontWeight();
            fw.Weight = 20;
            headerBlock.FontWeight = fw;
            headerBlock.Padding = new Thickness(10);
            CourseList.Items.Add(headerBlock);
            TextBlock course;
            foreach (string c in param.courses)
            {
                if (c != null)
                {
                    course = new TextBlock();
                    course.TextWrapping = TextWrapping.WrapWholeWords;
                    course.Padding = new Thickness(10);
                    course.Text = c;
                    CourseList.Items.Add(course);
                }
            }
        }
    }
}
