using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Project3.Views
{
    public sealed partial class ResearchDetail : Page
    {
        public string Title { set; get; }

        public ResearchDetail()
        {
            DataContext = this;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter.GetType() == typeof(Wrappers.ByInterestArea))
            {
                Wrappers.ByInterestArea area = (Wrappers.ByInterestArea)e.Parameter;
                TextBlock citation;
                Title = "Area of Interest: " + area.areaName;
                foreach (string cit in area.citations)
                {
                    if (cit != null)
                    {
                        citation = new TextBlock();
                        citation.TextWrapping = TextWrapping.WrapWholeWords;
                        citation.Padding = new Thickness(10);
                        citation.Text = cit;
                        Citations.Items.Add(citation);
                    }
                }
            }

            if (e.Parameter.GetType() == typeof(Wrappers.ByFaculty))
            {
                Wrappers.ByFaculty fac = (Wrappers.ByFaculty)e.Parameter;
                TextBlock citation;
                Title = "Faculty Member: " + fac.facultyName + "( " + fac.username + " )";
                foreach (string cit in fac.citations)
                {
                    if (cit != null)
                    {
                        citation = new TextBlock();
                        citation.TextWrapping = TextWrapping.WrapWholeWords;
                        citation.Padding = new Thickness(10);
                        citation.Text = cit;
                        Citations.Items.Add(citation);
                    }
                }
            }
        }
    }


}
